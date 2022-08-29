package com.example.androidclient;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import com.example.androidclient.databinding.FragmentProductDetailsBinding;
import com.example.androidclient.objects.ProductObject;

public class ProductDetailsFragment extends Fragment {

    private FragmentProductDetailsBinding binding;
    ProductObject selectedProduct;


    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState
    ) {

        binding = FragmentProductDetailsBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        Bundle bundle = this.getArguments();
        if (bundle != null) {
            selectedProduct = bundle.getParcelable("selectedProduct");
            binding.txtDetName.setText(selectedProduct.getName());
            binding.txtDetCategory.setText(selectedProduct.getCategory());
            binding.txtDetDescription.setText(selectedProduct.getDescription());
            binding.txtDetPrice.setText("R"+selectedProduct.getPrice());

        }



    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

}