package com.example.androidclient.orders;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.telephony.PhoneNumberFormattingTextWatcher;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import com.example.androidclient.databinding.FragmentMakePaymentBinding;

import com.example.androidclient.R;
import com.example.androidclient.network.URLGenerator;

import java.util.concurrent.atomic.AtomicBoolean;


public class MakePaymentFragment extends Fragment implements URLGenerator {

    private FragmentMakePaymentBinding binding;

    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState
    ) {

        binding = FragmentMakePaymentBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.btnSavePayment.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                if(flag_textFormat()){
                    createPaymentSharedPreferences();
                    ((MakeOrderActivity) requireActivity()).getOrderViewPager().setCurrentItem(2,true);
                }

            }
        });

        binding.txtCardNum.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {

                if(s.length()==4 || s.length()==9 || s.length()==14){
                    String text = s.toString();
                    binding.txtCardNum.setText(binding.txtCardNum.getText().toString()+" ");
                            binding.txtCardNum.setSelection(s.length()+1);

                }
            }
        });

        binding.txtExpireDate.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {

                if(s.length()==2 ){
                    binding.txtExpireDate.setText(binding.txtExpireDate.getText().toString()+"/");
                    binding.txtExpireDate.setSelection(s.length()+1);

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
        return null;
    }

    private boolean flag_textFormat() {

        AtomicBoolean mFlag = new AtomicBoolean(false);
        if (binding.txtCardName.length() <= 0) {
            binding.inputLayoutCardName.setError("Field cannot be empty");
            binding.inputLayoutCardName.setErrorEnabled(true);
            mFlag.set(false);
        } else {
            mFlag.set(true);
        }
        if (binding.txtCardNum.length() !=19) {
            binding.inputLayoutCardNum.setError("Card number must be 16 digits");
            binding.inputLayoutCardNum.setErrorEnabled(true);
            mFlag.set(false);
        } else {
            mFlag.set(true);
        }


        if (binding.txtExpireDate.length() <= 0 || binding.txtExpireDate.length()!=5) {
            binding.inputLayoutExpire.setError("Field cannot be empty");
            binding.inputLayoutExpire.setErrorEnabled(true);
            mFlag.set(false);
        } else {
            mFlag.set(true);
        }
        if (binding.txtCVC.length() !=3) {
            binding.inputLayoutCvc.setError("field cannot be empty");
            binding.inputLayoutCvc.setErrorEnabled(true);
            mFlag.set(false);
        } else {
            mFlag.set(true);
        }

        return mFlag.get();

    }

    private void setErrorLabelOff(){
        binding.inputLayoutCardName.setErrorEnabled(false);
        binding.inputLayoutCardNum.setErrorEnabled(false);
        binding.inputLayoutExpire.setErrorEnabled(false);
        binding.inputLayoutCvc.setErrorEnabled(false);
    }

    public void createPaymentSharedPreferences(){

        SharedPreferences userSharedPreferences = requireContext().getSharedPreferences("userOrderSessionPref", Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = userSharedPreferences.edit();
        editor.putString("cardNumber",binding.txtCardNum.getText().toString());
        editor.putString("ExpireDate",binding.txtExpireDate.getText().toString());
        editor.commit();

    }
}