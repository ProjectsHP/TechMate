package com.example.androidclient;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;

import android.os.Handler;
import android.util.Log;
import android.view.ContextThemeWrapper;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import com.example.androidclient.databinding.FragmentUserProfileBinding;
import com.example.androidclient.network.VolleyCallBack;
import com.example.androidclient.network.VolleySingleton;
import com.example.androidclient.ui.UIComponents;
import com.google.android.material.appbar.AppBarLayout;
import com.google.android.material.appbar.MaterialToolbar;


public class UserProfileFragment extends Fragment {

    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    private String mParam1;
    private String mParam2;
    private UIComponents uiComponents;
    private AppBarLayout mAppBarLayout;
    private MaterialToolbar mMaterialToolbar;
    private FragmentUserProfileBinding binding;


    public UserProfileFragment() {
        // Required empty public constructor
    }


    public static UserProfileFragment newInstance(String param1, String param2) {
        UserProfileFragment fragment = new UserProfileFragment();
        Bundle args = new Bundle();
        args.putString(ARG_PARAM1, param1);
        args.putString(ARG_PARAM2, param2);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mParam1 = getArguments().getString(ARG_PARAM1);
            mParam2 = getArguments().getString(ARG_PARAM2);
        }

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
      //  binding = FragmentUserProfileBinding.inflate(inflater, container, false);
        //return binding.getRoot();

        // create ContextThemeWrapper from the original Activity Context with the custom theme
        final Context contextThemeWrapper = new ContextThemeWrapper(getActivity(), R.style.Theme_AndroidClient_NoActionBar);

        // clone the inflater using the ContextThemeWrapper
        LayoutInflater localInflater = inflater.cloneInContext(contextThemeWrapper);

        // inflate the layout using the cloned inflater, not default inflater
        return localInflater.inflate(R.layout.fragment_user_profile, container, false);
      //  return inflater.inflate(R.layout.fragment_user_profile, container, false);
    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        uiComponents = new UIComponents(getActivity());
       // loginActivityConstraintLayout = getActivity().findViewById(R.id.layout_activityLogin);
        getActivity().getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_ADJUST_RESIZE);
      //  mAppBarLayout = (AppBarLayout) getActivity().findViewById(R.id.mainAppBarLayout);
        //mMaterialToolbar = (MaterialToolbar) getActivity().findViewById(R.id.mainToolbar);
        //mAppBarLayout.setVisibility(View.GONE);
        //mMaterialToolbar.setVisibility(View.GONE);






    }
}