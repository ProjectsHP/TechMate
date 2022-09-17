package com.example.androidclient.login;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.viewpager.widget.ViewPager;

import com.android.volley.AuthFailureError;
import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.VolleyLog;
import com.android.volley.toolbox.StringRequest;
import com.example.androidclient.databinding.FragmentSignUpBinding;
import com.example.androidclient.R;
import com.example.androidclient.network.URLGenerator;
import com.example.androidclient.network.VolleyCallBack;
import com.example.androidclient.network.VolleySingleton;
import com.example.androidclient.ui.UIComponents;
import com.google.android.material.snackbar.Snackbar;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.UnsupportedEncodingException;
import java.util.concurrent.atomic.AtomicBoolean;

public class SignUpFragment extends Fragment implements URLGenerator {

    private FragmentSignUpBinding binding;
    RequestQueue requestQueue;
    StringRequest stringRequest;
    private UIComponents uiComponents;
    private View loginActivityConstraintLayout;
    ViewPager viewPager;
    private String serverResponseCode;


    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState) {

        binding = FragmentSignUpBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    @SuppressLint("ClickableViewAccessibility")
    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        uiComponents = new UIComponents(getActivity());
        loginActivityConstraintLayout = getActivity().findViewById(R.id.layout_activityLogin);
        getActivity().getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_ADJUST_RESIZE);
        viewPager = getActivity().findViewById(R.id.viewPager);

            binding.btnSignUp.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {

                    if(flag_textFormat()) {
                        requestQueue = VolleySingleton.getVolleyInstance(getContext()).getRequestQueue();
                        uiComponents.disableLayoutAndChildren(binding.layoutLinearRegister,false);
                        uiComponents.disableLayoutAndChildren((ViewGroup) loginActivityConstraintLayout, false);
                        binding.progressBarRegister.setVisibility(View.VISIBLE);
                        viewPager.beginFakeDrag();
                        try {
                            POSTRegisterRequest(new VolleyCallBack() {
                                @Override
                                public void OnSuccess() {
                                    final Handler handler = new Handler();
                                    handler.postDelayed(new Runnable() {
                                        @Override
                                        public void run() {

                                            if (serverResponseCode != null) {
                                                uiComponents.disableLayoutAndChildren(binding.layoutLinearRegister, true);
                                                uiComponents.disableLayoutAndChildren((ViewGroup) loginActivityConstraintLayout, true);
                                                binding.progressBarRegister.setVisibility(View.GONE);
                                                viewPager.endFakeDrag();

                                                switch(serverResponseCode){
                                                    case "200":
                                                        Log.e("RESPONSE CODE 200: ", serverResponseCode);
                                                        viewPager.setCurrentItem(0,true);
                                                        Snackbar.make(getActivity().findViewById(android.R.id.content),
                                                                "Successfully registered, please sign in", Snackbar.LENGTH_LONG).show();
                                                        break;

                                                    case "201":
                                                        uiComponents.alertDialog_DefaultNoCancel("Email already exist, please try another email", "Sign up Failed", "OK");
                                                        binding.txtEmailEditor.setText("");
                                                        binding.txtEmailEditor.requestFocus();
                                                        binding.txtEmail.setError("Enter new email");
                                                        binding.txtEmail.setErrorEnabled(true);
                                                        break;

                                                    case "202":
                                                        uiComponents.alertDialog_DefaultNoCancel("Internal server error, please try again", "Internal error", "Ok");
                                                        break;

                                                    default:
                                                        uiComponents.alertDialog_DefaultNoCancel("Server is temporarily down. Please try again later", "Error", "Ok");
                                                        break;

                                                }


                                            }
                                            serverResponseCode = null;
                                        }
                                    }, 200);

                                }
                            });
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                    //else{
                     //   Animation shake = AnimationUtils.loadAnimation(getContext(), R.anim.shake_horizontal);
                       // binding.layoutLinearRegister.startAnimation(shake);
                    //}

                }
            });

            binding.layoutLinearRegister.setOnTouchListener(new View.OnTouchListener() {
                @Override
                public boolean onTouch(View v, MotionEvent event) {
                    setErrorLabelOff();
                    return false;
                }
            });
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

    public void POSTRegisterRequest(final VolleyCallBack callBack) throws JSONException {


        JSONObject jsonBody = new JSONObject();

        jsonBody.put("name", binding.txtFNameEditor.getText());
        jsonBody.put("surname", binding.txtSurnameEditor.getText());
        jsonBody.put("email", binding.txtEmailEditor.getText());
        jsonBody.put("password", binding.txtPasswordEditor.getText());
        jsonBody.put("cellNo",5555);
        jsonBody.put("gender","male");
        jsonBody.put("userType","customer");
        final String mRequestBody = jsonBody.toString();

          StringRequest stringRequest = new StringRequest(Request.Method.POST, generateURL(), new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                String jsonObj = response.toString();
                if (jsonObj.contains("1")) {
                    serverResponseCode = getResources().getString(R.string.response_success);
                }else if(jsonObj.contains("0")){
                    serverResponseCode="201";
                }else if(jsonObj.contains("-1")){
                    serverResponseCode="202";
                }else {
                    serverResponseCode = getResources().getString(R.string.response_login_error);
                    Log.e("Inside response", "returned null object from server login");
                }

                callBack.OnSuccess();

            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                VolleyLog.e("Error: ", error.getMessage());
                Log.e("Succes response",error.toString());
                serverResponseCode = null;
                callBack.OnSuccess();
            }
        }){
            @Override
            public String getBodyContentType() {
                return "application/json; charset=utf-8";
            }
            @Override
            public byte[] getBody() throws AuthFailureError {
                try {
                    return mRequestBody == null ? null : mRequestBody.getBytes("utf-8");
                } catch (UnsupportedEncodingException uee) {
                    VolleyLog.wtf("Unsupported Encoding while trying to get the bytes of %s using %s", mRequestBody, "utf-8");
                    return null;
                }
            }

           /* @Override
            protected Response<String> parseNetworkResponse(NetworkResponse response) {
                String responseString = "";
                if (response != null) {
                    responseString = String.valueOf(response.statusCode);
                }
                return Response.success(responseString, HttpHeaderParser.parseCacheHeaders(response));
            }*/
        };

         stringRequest.setRetryPolicy(new DefaultRetryPolicy(3000, 3, DefaultRetryPolicy.DEFAULT_BACKOFF_MULT));

        requestQueue.add(stringRequest);
    }

    @Override
    public String generateURL() {
        return getResources().getString(R.string.WCF_URL)+"RegisterURI";
    }

    private boolean flag_textFormat() {

        AtomicBoolean mFlag = new AtomicBoolean(false);
        if (binding.txtFNameEditor.length() <= 0) {
            binding.txtFName.setError("Field cannot be empty");
            binding.txtFName.setErrorEnabled(true);
            mFlag.set(false);
        } else {
            mFlag.set(true);
        }
        if (binding.txtSurnameEditor.length() <= 0) {
            binding.txtSurname.setError("Field cannot be empty");
            binding.txtSurname.setErrorEnabled(true);
            mFlag.set(false);
        } else {
            mFlag.set(true);
        }
        if (binding.txtEmailEditor.length() <= 0) {
            binding.txtEmail.setError("Field cannot be empty");
            binding.txtEmail.setErrorEnabled(true);
            mFlag.set(false);
        } else {
            mFlag.set(true);
        }
        if (binding.txtPasswordEditor.length() <= 2) {
            binding.txtPassword.setError("Password must be 6 to 12 characters");
            binding.txtPassword.setErrorContentDescription("error what what");
            binding.txtPassword.setErrorEnabled(true);
            mFlag.set(false);
        } else {
            mFlag.set(true);
        }

        return mFlag.get();

    }

    private void setErrorLabelOff(){
            binding.txtFName.setErrorEnabled(false);
            binding.txtSurname.setErrorEnabled(false);
            binding.txtEmail.setErrorEnabled(false);
            binding.txtPassword.setErrorEnabled(false);
    }



}


