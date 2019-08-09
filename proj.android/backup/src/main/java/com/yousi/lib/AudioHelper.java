package com.yousi.lib;

import java.io.File;
import java.io.IOException;

import android.media.MediaPlayer;
import android.media.MediaPlayer.OnCompletionListener;
import android.media.MediaRecorder;
import android.util.Log;

public class AudioHelper {

    private static final String TAG = "AudioHelper";

    static MyRecorder recorder = null;
    static MediaPlayer mediaPlayer = null;

    public static void startRecording(String outfile, int maxTime, int sampleRate, int channels, int bitRate, MyRecorderListener listener) {
        stopRecording();

        recorder = new MyRecorder(outfile, maxTime, sampleRate, channels, bitRate, listener);
        recorder.start();
    }

    public static void stopRecording() {
        if (recorder != null) {
            recorder.stop();
            recorder = null;
        }
    }

    public static boolean isRecording() {
        return (recorder != null && recorder.isRecording());
    }

    public static int startPlayAudio(String infile, float volume, final MyPlayerListener listener) {
        stopPlayAudio();

        mediaPlayer = new MediaPlayer();

        if (volume > 0) {
            int maxVolume = 50;
            if (volume > maxVolume) volume = maxVolume;
            float log1=(float)(Math.log(maxVolume-volume)/Math.log(maxVolume));
            mediaPlayer.setVolume(1-log1, 1-log1);
        }

        try {
            mediaPlayer.setDataSource(infile);
            mediaPlayer.prepare();
        } catch (IllegalStateException e) {
            Log.e(TAG, "playAudio fail " + e.getMessage());
            e.printStackTrace();
            return -1;
        } catch (IOException e) {
            Log.e(TAG, "playAudio fail " + e.getMessage());
            e.printStackTrace();
            return -2;
        }
        mediaPlayer.setOnCompletionListener(new OnCompletionListener() {

            @Override
            public void onCompletion(MediaPlayer arg0) {
                listener.onPlayFinished(0);
                mediaPlayer = null;
            }

        });

        listener.onPlayStarted();
        mediaPlayer.start();
        return 0;
    }

    public static void stopPlayAudio() {
        if (mediaPlayer != null) {
            mediaPlayer.stop();
            mediaPlayer = null;
        }
    }

    // FIXME multi-threading
    public static class MyRecorder {

        MediaRecorder mediaRecorder = null;
        Thread recordingThread = null;
        boolean stopped = true;
        String outfile = null;
        int maxTime = 0;
        int sampleRate = 0;
        int channels = 0;
        int bitRate = 0;

        MyRecorderListener listener = null;

        public MyRecorder(String outfile, int maxTime, int sampleRate, int channels, int bitRate, MyRecorderListener listener) {
            this.outfile = outfile;
            this.maxTime = maxTime;
            this.sampleRate = sampleRate;
            this.channels = channels;
            this.bitRate = bitRate;
            this.listener = listener;
        }

        public void start() {
            if (recordingThread != null) {
                Log.d(TAG, "start: recording thread is still running");
                return;
            }

            stopped = false;

            // FIXME mediaRecorder racing, no mutex, multi-threading bad practice
            recordingThread = new Thread(new Runnable() {
                public void run() {
                    Log.d(TAG, "recording thread starting...");

                    int status = 0;

                    try {
                        Log.d(TAG, "setup recorder...");

                        mediaRecorder = new MediaRecorder();
                        mediaRecorder.setAudioSource(MediaRecorder.AudioSource.MIC);
                        mediaRecorder.setOutputFormat(MediaRecorder.OutputFormat.MPEG_4);
                        mediaRecorder.setAudioEncoder(MediaRecorder.AudioEncoder.AAC);
                        if (sampleRate > 0) {
                            mediaRecorder.setAudioSamplingRate(sampleRate);
                        }
                        if (channels > 0) {
                            mediaRecorder.setAudioChannels(channels);
                        }
                        if (bitRate > 0) {
                            mediaRecorder.setAudioEncodingBitRate(bitRate);
                        }
                        mediaRecorder.setOutputFile(outfile);

                        Log.d(TAG, "recording started...");

                        mediaRecorder.prepare();
                        mediaRecorder.start();

                        listener.onRecordStarted();

                        long startTime = System.currentTimeMillis();
                        while (! stopped) {
                            long elapsed = System.currentTimeMillis() - startTime;
                            // Log.d(TAG, "recording... elapsed=" + elapsed);
                            if (maxTime > 0 && elapsed >= maxTime) {
                                status = 1;
                                break;
                            }
                            try {
                                Thread.sleep(50);
                            } catch (InterruptedException e) {
                                Log.e(TAG, "interrupted " + e.getMessage());
                                e.printStackTrace();
                            }
                        }
                    } catch (IllegalStateException e1) {
                        status = -3;
                        Log.e(TAG, "recording failed " + e1.getMessage());
                        e1.printStackTrace();
                    } catch (IOException e1) {
                        status = -4;
                        Log.e(TAG, "recording failed " + e1.getMessage());
                        e1.printStackTrace();
                    } catch (RuntimeException e1) {
                        status = -5;
                        Log.e(TAG, "recording failed " + e1.getMessage());
                        e1.printStackTrace();
                    }

                    Log.d(TAG, "recording finished status=" + status);
                    recordingThread = null;
                    stop();
                    listener.onRecordFinished(status);
                }
            });
            recordingThread.start();
        }

        public void stop() {
            if (recordingThread != null) {
                Log.d(TAG, "stop: recording thread is still running");
                stopped = true;
                return;
            }

            if (mediaRecorder != null) {
                try {
                    mediaRecorder.stop();
                } catch (RuntimeException e) {
                    Log.e(TAG, "stop recording failed " + e.getMessage());
                    e.printStackTrace();

                    File file = new File(outfile);
                    if (file.exists()) {
                        Log.d(TAG, "deleting file " + file);
                        file.delete();
                    }
                }

                mediaRecorder.reset();
                mediaRecorder.release();
                mediaRecorder = null;

                stopped = true;
                recordingThread = null;
            }
        }

        public boolean isRecording() {
            return (!stopped);
        }
    }

    public interface MyRecorderListener {

        public void onRecordStarted();

        public void onRecordFinished(int status);

    }

    public interface MyPlayerListener {

        public void onPlayStarted();

        public void onPlayFinished(int status);

    }
}