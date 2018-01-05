package com.example.rafal.carfinancemanager;

import android.app.DownloadManager;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.app.Activity;
import android.widget.Toast;
import okhttp3.*;
import org.json.JSONException;
import org.json.JSONObject;

import javax.net.ssl.HttpsURLConnection;
import java.io.DataOutput;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.LinkedHashMap;
import java.util.Map;

public class SignIn extends Activity {

    Button button;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sign_in);

        View textView = (TextView) findViewById(R.id.link_login);
        button = (Button) findViewById(R.id.btn_signup);

        textView.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                Intent intent = new Intent(SignIn.this,MainActivity.class);
                startActivity(intent);


            }
        });

       button.setOnClickListener(new View.OnClickListener()
        {
            public void onClick(View v)
            {
                OkHttpClient client = new OkHttpClient();

                MediaType mediaType = MediaType.parse("application/json");
                RequestBody body = RequestBody.create(mediaType, "{\n\t\"email\": \"mariusz.wnek@fp.com\",\n\t\"name\": \"Mariusz\",\n\t\"surename\": \"Wnek\",\n\t\"password\": \"Q1wertyuiop;\",\n\t\"confirmPassword\": \"Q1wertyuiop;\"\n}");
                Request request = new Request.Builder()
                        .url("http://localhost:59028/api/account/register")
                        .post(body)
                        .addHeader("content-type", "application/json")
                        .addHeader("cache-control", "no-cache")
                        .build();
                try {
                    Response response = client.newCall(request).execute();
                }
                catch (IOException e) {
                    e.printStackTrace();
                }
            }
        });
    }
}

