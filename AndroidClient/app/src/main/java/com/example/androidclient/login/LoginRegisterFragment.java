package com.example.androidclient.login;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.androidclient.R;
import com.example.androidclient.databinding.FragmentLoginRegisterBinding;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link LoginRegisterFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class LoginRegisterFragment extends Fragment {

    private FragmentLoginRegisterBinding binding;

    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";


    private String mParam1;
    private String mParam2;

    public LoginRegisterFragment() {
        // Required empty public constructor
    }


    public static LoginRegisterFragment newInstance(String param1, String param2) {
        LoginRegisterFragment fragment = new LoginRegisterFragment();
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
        binding = FragmentLoginRegisterBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.btnLoginRedirect.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                NavHostFragment.findNavController(LoginRegisterFragment.this)
                        .navigate(R.id.action_loginRegisterFragment_to_SingInFragment);
            }
        });


        binding.btnRegisterRedirect.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                NavHostFragment.findNavController(LoginRegisterFragment.this)
                        .navigate(R.id.action_loginRegisterFragment_to_SignUpFragment);
            }
        });

    }



    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

}