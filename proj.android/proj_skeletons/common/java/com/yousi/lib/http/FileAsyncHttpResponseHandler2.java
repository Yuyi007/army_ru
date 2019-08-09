/*
    Android Asynchronous Http Client
    Copyright (c) 2011 James Smith <james@loopj.com>
    http://loopj.com

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

        http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
*/

package com.yousi.lib.http;

import android.content.Context;
import android.util.Log;

import org.apache.http.Header;
import org.apache.http.HttpEntity;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;

import java.util.zip.Inflater;
import java.util.zip.InflaterInputStream;

// 2017-7-14 lt: add inflate to FileAsyncHttpResponseHandler

public abstract class FileAsyncHttpResponseHandler2 extends AsyncHttpResponseHandler {

    protected final File mFile;
    protected final boolean append;
    private static final String LOG_TAG = "FileAsyncHttpResponseHandler2";

    protected boolean inflate = false;

    /**
     * Obtains new FileAsyncHttpResponseHandler2 and stores response in passed file
     *
     * @param file   File to store response within, must not be null
     * @param append whether data should be appended to existing file
     */
    public FileAsyncHttpResponseHandler2(File file, boolean append, boolean inflate) {
        super();
        AssertUtils.asserts(file != null, "File passed into FileAsyncHttpResponseHandler2 constructor must not be null");
        this.mFile = file;
        this.append = append;
        this.inflate = inflate;
    }

    /**
     * Obtains new FileAsyncHttpResponseHandler2 against context with target being temporary file
     *
     * @param context Context, must not be null
     */
    public FileAsyncHttpResponseHandler2(Context context) {
        super();
        this.mFile = getTemporaryFile(context);
        this.append = false;
    }

    /**
     * Attempts to delete file with stored response
     *
     * @return false if the file does not exist or is null, true if it was successfully deleted
     */
    public boolean deleteTargetFile() {
        return getTargetFile() != null && getTargetFile().delete();
    }

    /**
     * Used when there is no file to be used when calling constructor
     *
     * @param context Context, must not be null
     * @return temporary file or null if creating file failed
     */
    protected File getTemporaryFile(Context context) {
        AssertUtils.asserts(context != null, "Tried creating temporary file without having Context");
        try {
            // not effective in release mode
            assert context != null;
            return File.createTempFile("temp_", "_handled", context.getCacheDir());
        } catch (IOException e) {
            Log.e(LOG_TAG, "Cannot create temporary file", e);
        }
        return null;
    }

    /**
     * Retrieves File object in which the response is stored
     *
     * @return File file in which the response is stored
     */
    protected File getTargetFile() {
        assert (mFile != null);
        return mFile;
    }

    @Override
    public final void onFailure(int statusCode, Header[] headers, byte[] responseBytes, Throwable throwable) {
        onFailure(statusCode, headers, throwable, getTargetFile());
    }

    /**
     * Method to be overriden, receives as much of file as possible Called when the file is
     * considered failure or if there is error when retrieving file
     *
     * @param statusCode http file status line
     * @param headers    file http headers if any
     * @param throwable  returned throwable
     * @param file       file in which the file is stored
     */
    public abstract void onFailure(int statusCode, Header[] headers, Throwable throwable, File file);

    @Override
    public final void onSuccess(int statusCode, Header[] headers, byte[] responseBytes) {
        onSuccess(statusCode, headers, getTargetFile());
    }

    /**
     * Method to be overriden, receives as much of response as possible
     *
     * @param statusCode http response status line
     * @param headers    response http headers if any
     * @param file       file in which the response is stored
     */
    public abstract void onSuccess(int statusCode, Header[] headers, File file);

    @Override
    protected byte[] getResponseData(HttpEntity entity) throws IOException {
        if (entity != null) {
            InputStream instream = entity.getContent();
            long contentLength = entity.getContentLength();
            FileOutputStream buffer = new FileOutputStream(getTargetFile(), this.append);

            Inflater inflater = null;
            if (this.inflate) {
                inflater = new Inflater();
                // instream = new InflaterInputStream(instream);
            }

            if (instream != null) {
                try {
                    byte[] tmp = new byte[BUFFER_SIZE];
                    byte[] tmp2 = new byte[BUFFER_SIZE * 8];
                    int l, count = 0;
                    // do not send messages if request has been cancelled
                    while ((l = instream.read(tmp)) != -1 && !Thread.currentThread().isInterrupted()) {
                        count += l;
                        // count += l / 4;
                        // count = (count > contentLength ? (int) contentLength : count);
                        if (inflater != null) {
                            inflater.setInput(tmp, 0, l);
                            int l2 = 0;
                            while ((l2 = inflater.inflate(tmp2)) > 0) {
                                buffer.write(tmp2, 0, l2);
                            }
                        } else {
                            buffer.write(tmp, 0, l);
                        }
                        sendProgressMessage(count, (int) contentLength);
                    }
                } catch (java.io.UnsupportedEncodingException e) {
                    Log.e(LOG_TAG, "getResponseData: " + e.getMessage());
                } catch (java.util.zip.DataFormatException e) {
                    Log.e(LOG_TAG, "getResponseData: " + e.getMessage());
                } finally {
                    AsyncHttpClient.silentCloseInputStream(instream);
                    buffer.flush();
                    AsyncHttpClient.silentCloseOutputStream(buffer);
                    if (inflater != null) inflater.end();
                }
            }
        }
        return null;
    }

}
