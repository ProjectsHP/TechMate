package com.example.androidclient.login;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.os.Handler;
import android.text.TextWatcher;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.ProgressBar;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.fragment.app.Fragment;
import androidx.viewpager.widget.ViewPager;

import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.StringRequest;
import com.example.androidclient.MainActivity;
import com.example.androidclient.R;
import com.example.androidclient.objects.UserObject;
import com.example.androidclient.databinding.FragmentSignInBinding;
import com.example.androidclient.network.URLGenerator;
import com.example.androidclient.network.VolleyCallBack;
import com.example.androidclient.network.VolleySingleton;
import com.example.androidclient.ui.UIComponents;
import com.google.android.material.tabs.TabLayout;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import org.json.JSONObject;

import java.util.concurrent.atomic.AtomicBoolean;


public class SignInFragment extends Fragment implements URLGenerator {

    RequestQueue requestQueue;
    StringRequest stringRequest;
    UserObject userObject;
    UIComponents uiComponents;
    String serverResponseCode;
    ProgressBar progressBar;
    ConstraintLayout loginActivityConstraintLayout;
    TabLayout tabLayout;
    ViewPager viewPager;
    TextWatcher textWatcher;
    private FragmentSignInBinding binding;
    SharedPreferences userSharedPreferences;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requireActivity().getWindow()
                .setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_ADJUST_NOTHING);

    }

    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState) {
        binding = FragmentSignInBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        uiComponents = new UIComponents(getActivity());
        loginActivityConstraintLayout = getActivity().findViewById(R.id.layout_activityLogin);
        viewPager = getActivity().findViewById(R.id.viewPager);
        getActivity().getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_ADJUST_RESIZE);
        userSharedPreferences = requireContext().getSharedPreferences("userPref", Context.MODE_PRIVATE);


        binding.btnSignIn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (flag_textFormat()) {
                    requestQueue = VolleySingleton.getVolleyInstance(getContext()).getRequestQueue();
                    uiComponents.disableLayoutAndChildren(binding.layoutSignIn, false);
                    uiComponents.disableLayoutAndChildren(loginActivityConstraintLayout, false);
                    binding.progressBarLogin.setVisibility(View.VISIBLE);
                    binding.txtEmail.setErrorEnabled(false);
                    binding.txtPassword.setErrorEnabled(false);
                    viewPager.beginFakeDrag();


                    GETLoginRequest(new VolleyCallBack() {
                        @Override
                        public void OnSuccess() {


                                    if (serverResponseCode != null) {
                                        if (serverResponseCode.equals("200")) {
                                           createSharedPreferences();
                                            Log.e("RESPONSE CODE 200: ", serverResponseCode);
                                            Intent intent = new Intent(getActivity(), MainActivity.class);
                                            intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                            startActivity(intent);
                                            requireActivity().finish();
                                        } else if (serverResponseCode.equals("202")) {

                                            uiComponents.disableLayoutAndChildren(binding.layoutSignIn, true);
                                            uiComponents.disableLayoutAndChildren(loginActivityConstraintLayout, true);
                                            binding.progressBarLogin.setVisibility(View.GONE);
                                            viewPager.endFakeDrag();
                                            uiComponents.alertDialog_DefaultNoCancel("Username or password is incorrect", "Sign In Failed", "GOT IT");
                                            binding.txtPasswordEditor.setText("");
                                            binding.txtPasswordEditor.requestFocus();

                                        }
                                    } else {
                                        uiComponents.disableLayoutAndChildren(binding.layoutSignIn, true);
                                        uiComponents.disableLayoutAndChildren(loginActivityConstraintLayout, true);
                                        binding.progressBarLogin.setVisibility(View.GONE);
                                        viewPager.endFakeDrag();
                                        uiComponents.alertDialog_DefaultNoCancel("Server is temporarily down. Please try again later", "Error", "Ok");
                                    }
                                    serverResponseCode = null;


                        }
                    });

                }
            }
        });
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

    @Override
    public String generateURL() {
        String cleanUrl = getResources().getString(R.string.WCF_URL);
        return cleanUrl + "LoginURI/" + binding.txtEmailEditor.getText() + "/" + binding.txtPasswordEditor.getText();
    }

    public void GETLoginRequest(final VolleyCallBack callBack) {

        //JSONObject Request initialized

        JsonObjectRequest JsonObjectRequest = new JsonObjectRequest(Request.Method.GET, generateURL(), null,
                new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {

                        String jsonObj = response.toString();

                        if(!jsonObj.contains("def")){
                            Log.e("Contains def obj",jsonObj.toString());
                            if (jsonObj.contains("Id")) {
                                GsonBuilder builder = new GsonBuilder();
                                builder.serializeNulls();
                                Gson gson = builder.setPrettyPrinting().create();
                                userObject = gson.fromJson(jsonObj, UserObject.class);
                                serverResponseCode = getResources().getString(R.string.response_success);
                            }else{
                                serverResponseCode =getResources().getString(R.string.response_login_error);
                            }
                        }else{
                            serverResponseCode = getResources().getString(R.string.response_object_not_found);
                        }


                        callBack.OnSuccess();
                    }
                },
                new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        String body = "";
                        serverResponseCode = null;
                        Log.e("Eror response",error.toString());

                        callBack.OnSuccess();
                    }
                }
        );
        JsonObjectRequest.setRetryPolicy(new DefaultRetryPolicy(3000, 3, DefaultRetryPolicy.DEFAULT_BACKOFF_MULT));

        requestQueue.add(JsonObjectRequest);
    }

    public boolean flag_textFormat() {

        AtomicBoolean mFlag = new AtomicBoolean(false);
        if (binding.txtEmailEditor.length() <= 0) {
            binding.txtEmail.setError("Please enter valid email");
            binding.txtEmail.setErrorEnabled(true);
            mFlag.set(false);
        } else {
            mFlag.set(true);
        }
        if (binding.txtPasswordEditor.length() <= 2) {
            binding.txtPassword.setError("Password must be 6 to 12 characters");
            binding.txtPassword.setErrorEnabled(true);
            mFlag.set(false);
        } else {
            mFlag.set(true);
        }

        return mFlag.get();

    }

    public void createSharedPreferences(){
       SharedPreferences userSharedPreferences = requireContext().getSharedPreferences("userPref", Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = userSharedPreferences.edit();
        editor.clear().apply();
        editor.putString("pref_FirstName",userObject.getName());
        editor.putString("pref_LastName",userObject.getSurname());
        editor.putString("pref_Gender",userObject.getGender());
        editor.putString("pref_Email",userObject.getEmail());
        editor.putString("pref_Phone", String.valueOf(userObject.getPhoneNo()));
        editor.putString("pref_Id",String.valueOf(userObject.getId()));
        editor.putString("pref_UserType",userObject.getUserType());
        editor.commit();
    }


}