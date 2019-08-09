// MediaPlayer.java

package com.yousi.lib;

import java.io.IOException;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.content.res.AssetFileDescriptor;
import android.media.AudioManager;
import android.media.MediaPlayer;
import android.media.MediaPlayer.OnCompletionListener;
import android.media.MediaPlayer.OnErrorListener;
import android.net.Uri;
import android.util.Log;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import android.view.View;
import android.widget.MediaController;
import android.widget.MediaController.MediaPlayerControl;

public class MoviePlayer extends SurfaceView implements MediaPlayerControl {

  final static String TAG = "MoviePlayer";

  private static MoviePlayer instance = null;
  private static boolean isPlayingVideo = false;

  public static MoviePlayer getInstance() {
    if (instance == null) {
      instance = new MoviePlayer(AndroidUtils.getContext());
    }

    return instance;
  }

  public static boolean isPlayingVideo() {
    return isPlayingVideo;
  }

  public static void play(final String url, final float x, final float y,
    final float width, final float height, final int onComplete, final int onTouchCallback) {

    isPlayingVideo = true;

    AndroidUtils.runOnUiThread(new Runnable() {
      @Override
      public void run() {
        Log.d(TAG, "play url=" + url);

        if (AndroidUtils.isEmulator()) {
          LuaUtils.invokeLuaCallback(onComplete, "");
          return;
        }

        // set complete listener
        instance.setOnCompletionListener(new OnCompletionListener() {
          @Override
          public void onCompletion(MediaPlayer p) {
            Log.d(TAG, "onCompletion");
            if (isPlayingVideo) {
              LuaUtils.invokeLuaCallback(onComplete, "");
              LuaUtils.releaseLuaCallback(onTouchCallback);
              isPlayingVideo = false;
            }
          }
        });

        // working onTouch for android video
        instance.setOnTouchListener(new View.OnTouchListener() {
          @Override
          public boolean onTouch(View v, MotionEvent event) {

            // these data are used in ACTION_MOVE and ACTION_CANCEL
            final float xs = event.getRawX();
            final float ys = event.getRawY();

            switch (event.getAction() & MotionEvent.ACTION_MASK) {
            case MotionEvent.ACTION_UP:
                final Float xUp = xs;
                final Float yUp = mHeight - ys;

                //if(xUp <= mArrowUpX && xUp >= mArrowLowX && yUp <= mArrowUpY && yUp >= mArrowLowY)
                //{
                LuaUtils.invokeLuaCallbackNoRelease(onTouchCallback, "");
                //}
                break;
            }

            return true;
          }
        });

        // play video
        String path = url;
        int k = url.indexOf("assets/");
        if (k == 0) {
          path = url.substring(7);
          Log.d(TAG, "asset path=" + path);
          instance.resetVideo();
          instance.setVideoAssetPath(path);
        } else {
          instance.resetVideo();
          instance.setVideoPath(url);
        }
      }
    });
  }

  public static void stop() {
    AndroidUtils.runOnUiThread(new Runnable() {
      @Override
      public void run() {
        Log.d(TAG, "stop");
        if (isPlayingVideo) {
          instance.stopPlayback();
          instance.resetVideo();
          instance.hideVideoView();
          isPlayingVideo = false;
        }
      }
    });
  }

  ////////////////////////////////////////
  //
  // Video SurfaceView Implementation
  // Copied from VideoView.java
  //
  ////////////////////////////////////////

  // settable by the client
  private Uri         mUri;
  private String      mAssetPath;
  private Context     mContext;

  private SurfaceHolder mSurfaceHolder = null;
  private MediaPlayer mMediaPlayer = null;
  private boolean     mIsPrepared;
  private int         mVideoWidth;
  private int         mVideoHeight;
  private int         mSurfaceWidth;
  private int         mSurfaceHeight;
  private MediaController mMediaController;
  private OnCompletionListener mOnCompletionListener;
  private MediaPlayer.OnPreparedListener mOnPreparedListener;
  private int         mCurrentBufferPercentage;
  private OnErrorListener mOnErrorListener;
  private boolean     mStartWhenPrepared;
  private int         mSeekWhenPrepared;

  private static int         mArrowLowX;
  private static int         mArrowLowY;
  private static int         mArrowUpX;
  private static int         mArrowUpY;
  private static int         mHeight;


  public MoviePlayer(Context context) {
    super(context);
    initVideoView();
    mContext = context;
    Log.d(TAG, "new MoviePlayer");
  }

  @SuppressLint("NewApi")
  @Override
  protected void onMeasure(int widthMeasureSpec, int heightMeasureSpec) {
    Log.d(TAG, "before onMeasure measureSpec=" + widthMeasureSpec + "x" + heightMeasureSpec);
    int originalWidth = getDefaultSize(0, widthMeasureSpec);
    int originalHeight = getDefaultSize(0, heightMeasureSpec);
    Log.d(TAG, "before onMeasure surface window=" + mSurfaceWidth + "x" + mSurfaceHeight);
    Log.d(TAG, "onMeasure window=" + originalWidth + "x" + originalHeight);
    int width = getDefaultSize(mVideoWidth, widthMeasureSpec);
    int height = getDefaultSize(mVideoHeight, heightMeasureSpec);
    Log.d(TAG, "onMeasure size=" + width + "x" + height);
    Log.d(TAG, "onMeasure videoSize=" + mVideoWidth + "x" + mVideoHeight);
    if (mVideoWidth > 0 && mVideoHeight > 0) {
      if ( mVideoWidth * height  > width * mVideoHeight ) {
        Log.d(TAG, "image too tall, correcting");
        width = height * mVideoWidth / mVideoHeight;
      } else if ( mVideoWidth * height  < width * mVideoHeight ) {
        Log.d(TAG, "image too wide, correcting");
        width = height * mVideoWidth / mVideoHeight;
      } else {
        Log.d(TAG, "aspect ratio is correct: " +
                width+"/"+height+"="+
                mVideoWidth+"/"+mVideoHeight);
      }
    }
    int x = (originalWidth - width) / 2;
    int y = (originalHeight - height) / 2;
    Log.d(TAG, "setting size: " + x + "," + y + " " + width + 'x' + height);
    mArrowLowX = x + width - 100;
    mArrowLowY = y - height;
    mArrowUpX = x + width;
    mArrowUpY = y - height + 100;
    mHeight = originalHeight;
    if (android.os.Build.VERSION.SDK_INT >= 11) { // HONEYCOMB
      setX(x);
      setY(y);
    }
    setMeasuredDimension(width, height);
  }

  public int resolveAdjustedSize(int desiredSize, int measureSpec) {
    Log.d("resolveAdjustedSize", "desiredSize: " + desiredSize + ", measureSpec" + measureSpec);
    int result = desiredSize;
    int specMode = MeasureSpec.getMode(measureSpec);
    int specSize =  MeasureSpec.getSize(measureSpec);

    switch (specMode) {
        case MeasureSpec.UNSPECIFIED:
            /* Parent says we can be as big as we want. Just don't be larger
             * than max size imposed on ourselves.
             */
            result = desiredSize;
            break;

        case MeasureSpec.AT_MOST:
            /* Parent says we can be as big as we want, up to specSize.
             * Don't be larger than specSize, and don't be larger than
             * the max size imposed on ourselves.
             */
            result = Math.min(desiredSize, specSize);
            break;

        case MeasureSpec.EXACTLY:
            // No choice. Do what we are told.
            result = specSize;
            break;
    }
    Log.d("resolveAdjustedSize", "result: " + result);
    return result;
  }

  private void initVideoView() {
    Log.d(TAG, "initVideoView");
    mVideoWidth = 0;
    mVideoHeight = 0;
    getHolder().addCallback(mSHCallback);
    getHolder().setType(SurfaceHolder.SURFACE_TYPE_PUSH_BUFFERS);
    setFocusable(false);
    setFocusableInTouchMode(false);
    //requestFocus();
  }

  public void resetVideo() {
    Log.d(TAG, "resetVideo");
    mUri = null;
    mAssetPath = null;
    mStartWhenPrepared = false;
    mSeekWhenPrepared = 0;
  }

  public void setVideoPath(String path) {
    setVideoURI(Uri.parse(path));
  }

  public void setVideoURI(Uri uri) {
    mUri = uri;
    mStartWhenPrepared = true;
    mSeekWhenPrepared = 0;
    showVideoView();
    openVideo();
    requestLayout();
    invalidate();
  }

  public void setVideoAssetPath(String assetPath) {
    mAssetPath = assetPath;
    mStartWhenPrepared = true;
    mSeekWhenPrepared = 0;
    showVideoView();
    openVideo();
    requestLayout();
    invalidate();
  }

  public void stopPlayback() {
    Log.d(TAG, "stopPlayback");
    if (mMediaPlayer != null) {
      mMediaPlayer.stop();
      mMediaPlayer.release();
      mMediaPlayer = null;
    }
  }

  private void openVideo() {
    Log.d(TAG, "openVideo mUri=" + mUri +
      " mAssetPath=" + mAssetPath + " mSurfaceHolder=" + mSurfaceHolder);
    if ((mUri == null && mAssetPath == null) || mSurfaceHolder == null) {
        // not ready for playback just yet, will try again later
        return;
    }
    // Tell the music playback service to pause
    // TODO: these constants need to be published somewhere in the framework.
    Intent i = new Intent("com.android.music.musicservicecommand");
    i.putExtra("command", "pause");
    mContext.sendBroadcast(i);

    if (mMediaPlayer != null) {
        mMediaPlayer.reset();
        mMediaPlayer.release();
        mMediaPlayer = null;
    }
    try {
        mMediaPlayer = new MediaPlayer();
        mMediaPlayer.setOnPreparedListener(mPreparedListener);
        mIsPrepared = false;
        mMediaPlayer.setOnCompletionListener(mCompletionListener);
        mMediaPlayer.setOnErrorListener(mErrorListener);
        mMediaPlayer.setOnBufferingUpdateListener(mBufferingUpdateListener);
        mCurrentBufferPercentage = 0;
        if (mAssetPath != null) {
          AssetFileDescriptor fd = AndroidUtils.getAssets().openFd(mAssetPath);
          mMediaPlayer.setDataSource(fd.getFileDescriptor(), fd.getStartOffset(), fd.getLength());
        } else {
          mMediaPlayer.setDataSource(mContext, mUri);
        }
        mMediaPlayer.setDisplay(mSurfaceHolder);
        mMediaPlayer.setAudioStreamType(AudioManager.STREAM_MUSIC);
        mMediaPlayer.setScreenOnWhilePlaying(true);
        mMediaPlayer.prepareAsync();
        attachMediaController();
    } catch (IOException ex) {
        Log.w(TAG, "Unable to open content: " + mUri, ex);
        return;
    } catch (IllegalArgumentException ex) {
        Log.w(TAG, "Unable to open content: " + mUri, ex);
        return;
    }
  }

  public void setMediaController(MediaController controller) {
      if (mMediaController != null) {
          mMediaController.hide();
      }
      mMediaController = controller;
      attachMediaController();
  }

  private void attachMediaController() {
      if (mMediaPlayer != null && mMediaController != null) {
          mMediaController.setMediaPlayer(this);
          View anchorView = this.getParent() instanceof View ?
                  (View)this.getParent() : this;
          mMediaController.setAnchorView(anchorView);
          mMediaController.setEnabled(mIsPrepared);
      }
  }

  MediaPlayer.OnPreparedListener mPreparedListener = new MediaPlayer.OnPreparedListener() {
      public void onPrepared(MediaPlayer mp) {
        Log.d(TAG, "onPrepared");
        // briefly show the mediacontroller
        mIsPrepared = true;
        showVideoView();
        if (mOnPreparedListener != null) {
            mOnPreparedListener.onPrepared(mMediaPlayer);
        }
        if (mMediaController != null) {
            mMediaController.setEnabled(true);
        }
        mVideoWidth = mp.getVideoWidth();
        mVideoHeight = mp.getVideoHeight();
        if (mVideoWidth != 0 && mVideoHeight != 0) {
            //Log.i("@@@@", "video size: " + mVideoWidth +"/"+ mVideoHeight);
            getHolder().setFixedSize(mVideoWidth, mVideoHeight);
            if (mSurfaceWidth == mVideoWidth && mSurfaceHeight == mVideoHeight) {
                // We didn't actually change the size (it was already at the size
                // we need), so we won't get a "surface changed" callback, so
                // start the video here instead of in the callback.
                if (mSeekWhenPrepared != 0) {
                    mMediaPlayer.seekTo(mSeekWhenPrepared);
                }
                if (mStartWhenPrepared) {
                    mMediaPlayer.start();
                    if (mMediaController != null) {
                        mMediaController.show();
                    }
               } else if (!isPlaying() && (mSeekWhenPrepared != 0 || getCurrentPosition() > 0)) {
                   if (mMediaController != null) {
                       mMediaController.show(0);   // show the media controls when we're paused into a video and make 'em stick.
                   }
               }
            }
        } else {
            Log.d(TAG, "Couldn't get video size after prepare(): " +
                    mVideoWidth + "/" + mVideoHeight);
            // The file was probably truncated or corrupt. Start anyway, so
            // that we play whatever short snippet is there and then get
            // the "playback completed" event.
            if (mStartWhenPrepared) {
                mMediaPlayer.start();
            }
        }
    }
  };

  private MediaPlayer.OnCompletionListener mCompletionListener =
    new MediaPlayer.OnCompletionListener() {
    public void onCompletion(MediaPlayer mp) {
      Log.d(TAG, "onCompletion");
      hideVideoView();

      if (mMediaController != null) {
        mMediaController.hide();
      }

      if (mOnCompletionListener != null) {
        mOnCompletionListener.onCompletion(mMediaPlayer);
      }
    }
  };

  private MediaPlayer.OnErrorListener mErrorListener =
    new MediaPlayer.OnErrorListener() {
    public boolean onError(MediaPlayer mp, int a, int b) {
      Log.d(TAG, "onError: " + a + "," + b);
      hideVideoView();

      if (mMediaController != null) {
        mMediaController.hide();
      }

      /* If an error handler has been supplied, use it and finish. */
      if (mOnErrorListener != null) {
        if (mOnErrorListener.onError(mMediaPlayer, a, b)) {
          return true;
        }
      }

      /* Otherwise, pop up an error dialog so the user knows that
       * something bad has happened. Only try and pop up the dialog
       * if we're attached to a window. When we're going away and no
       * longer have a window, don't bother showing the user an error.
       */
      /*if (getWindowToken() != null) {
          Resources r = mContext.getResources();
          new AlertDialog.Builder(mContext)
                  .setTitle(com.android.internal.R.string.VideoView_error_title)
                  .setMessage(com.android.internal.R.string.VideoView_error_text_unknown)
                  .setPositiveButton(com.android.internal.R.string.VideoView_error_button,
                          new DialogInterface.OnClickListener() {
                              public void onClick(DialogInterface dialog, int whichButton) {
                                  /* If we get here, there is no onError listener, so
                                   * at least inform them that the video is over.
                                   *
                                  if (mOnCompletionListener != null) {
                                      mOnCompletionListener.onCompletion(mMediaPlayer);
                                  }
                              }
                          })
                  .setCancelable(false)
                  .show();
      }*/
      return true;
    }
  };

  private MediaPlayer.OnBufferingUpdateListener mBufferingUpdateListener =
    new MediaPlayer.OnBufferingUpdateListener() {
    public void onBufferingUpdate(MediaPlayer mp, int percent) {
      mCurrentBufferPercentage = percent;
    }
  };

  /**
   * Register a callback to be invoked when the media file
   * is loaded and ready to go.
   *
   * @param l The callback that will be run
   */
  public void setOnPreparedListener(MediaPlayer.OnPreparedListener l)
  {
      mOnPreparedListener = l;
  }

  /**
   * Register a callback to be invoked when the end of a media file
   * has been reached during playback.
   *
   * @param l The callback that will be run
   */
  public void setOnCompletionListener(OnCompletionListener l)
  {
      mOnCompletionListener = l;
  }

  /**
   * Register a callback to be invoked when an error occurs
   * during playback or setup.  If no listener is specified,
   * or if the listener returned false, VideoView will inform
   * the user of any errors.
   *
   * @param l The callback that will be run
   */
  public void setOnErrorListener(OnErrorListener l)
  {
      mOnErrorListener = l;
  }

  SurfaceHolder.Callback mSHCallback = new SurfaceHolder.Callback()
  {
    public void surfaceChanged(SurfaceHolder holder, int format,
                                int w, int h)
    {
      Log.d(TAG, "surface changed");
      mSurfaceWidth = w;
      mSurfaceHeight = h;
      if (mIsPrepared && mVideoWidth == w && mVideoHeight == h) {
        if (mSeekWhenPrepared != 0) {
          mMediaPlayer.seekTo(mSeekWhenPrepared);
        }
        mMediaPlayer.start();
        if (mMediaController != null) {
          mMediaController.show();
        }
      }
    }

    public void surfaceCreated(SurfaceHolder holder)
    {
      Log.d(TAG, "surface created");
      mSurfaceHolder = holder;
      openVideo();
    }

    public void surfaceDestroyed(SurfaceHolder holder)
    {
      Log.d(TAG, "surface destroyed");
      // after we return from this we can't use the surface any more
      mSurfaceHolder = null;
      if (mMediaController != null) mMediaController.hide();
      if (mMediaPlayer != null) {
        mMediaPlayer.reset();
        mMediaPlayer.release();
        mMediaPlayer = null;
      }
    }
  };

  @Override
  public boolean onTouchEvent(MotionEvent ev) {
      // if (mIsPrepared && mMediaPlayer != null && mMediaController != null) {
      //     toggleMediaControlsVisiblity();
      // }
      // return false;
      return true;
  }

  @Override
  public boolean onTrackballEvent(MotionEvent ev) {
      if (mIsPrepared && mMediaPlayer != null && mMediaController != null) {
          toggleMediaControlsVisiblity();
      }
      return false;
  }

  @Override
  public boolean onKeyDown(int keyCode, KeyEvent event)
  {
    if (mIsPrepared &&
            keyCode != KeyEvent.KEYCODE_BACK &&
            keyCode != KeyEvent.KEYCODE_VOLUME_UP &&
            keyCode != KeyEvent.KEYCODE_VOLUME_DOWN &&
            keyCode != KeyEvent.KEYCODE_MENU &&
            keyCode != KeyEvent.KEYCODE_CALL &&
            keyCode != KeyEvent.KEYCODE_ENDCALL &&
            mMediaPlayer != null &&
            mMediaController != null) {
        if (keyCode == KeyEvent.KEYCODE_HEADSETHOOK) {
            if (mMediaPlayer.isPlaying()) {
                pause();
                mMediaController.show();
            } else {
                start();
                mMediaController.hide();
            }
            return true;
        } else {
            toggleMediaControlsVisiblity();
        }
    }

    //return super.onKeyDown(keyCode, event);
    return true;
  }

  private void toggleMediaControlsVisiblity() {
      if (mMediaController.isShowing()) {
          mMediaController.hide();
      } else {
          mMediaController.show();
      }
  }

  public void start() {
      if (mMediaPlayer != null && mIsPrepared) {
              mMediaPlayer.start();
              mStartWhenPrepared = false;
      } else {
          mStartWhenPrepared = true;
      }
  }

  public void pause() {
      if (mMediaPlayer != null && mIsPrepared) {
          if (mMediaPlayer.isPlaying()) {
              mMediaPlayer.pause();
          }
      }
      mStartWhenPrepared = false;
  }

  public int getDuration() {
      if (mMediaPlayer != null && mIsPrepared) {
          return mMediaPlayer.getDuration();
      }
      return -1;
  }

  public int getCurrentPosition() {
      if (mMediaPlayer != null && mIsPrepared) {
          return mMediaPlayer.getCurrentPosition();
      }
      return 0;
  }

  public void seekTo(int msec) {
      if (mMediaPlayer != null && mIsPrepared) {
          mMediaPlayer.seekTo(msec);
      } else {
          mSeekWhenPrepared = msec;
      }
  }

  public boolean isPlaying() {
      if (mMediaPlayer != null && mIsPrepared) {
          return mMediaPlayer.isPlaying();
      }
      return false;
  }

  public int getBufferPercentage() {
      if (mMediaPlayer != null) {
          return mCurrentBufferPercentage;
      }
      return 0;
  }

  @Override
  public boolean canSeekForward() {
    return false;
  }

  @Override
  public boolean canSeekBackward() {
    return false;
  }

  @Override
  public boolean canPause() {
    return false;
  }

  public void showVideoView() {
    Log.d(TAG, "showVideoView");
    setVisibility(View.VISIBLE);
    AndroidUtils.hideAllViews();
    requestLayout();
    invalidate();
  }

  public void hideVideoView() {
    Log.d(TAG, "hideVideoView");
    setVisibility(View.INVISIBLE);
    AndroidUtils.showAllViews();
    requestLayout();
    invalidate();
  }
	
	@Override
	public int getAudioSessionId() {
		return 0;
	}
}
