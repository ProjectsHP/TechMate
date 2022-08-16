package com.example.androidclient;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.androidclient.adapters.CartAdapter;
import com.example.androidclient.adapters.CategoryAdapter;
import com.example.androidclient.databinding.FragmentCartBinding;
import com.example.androidclient.databinding.FragmentCategoryBinding;
import com.example.androidclient.ui.IRecyclerViewClickHandler;

import java.util.ArrayList;


public class CartFragment extends Fragment implements IRecyclerViewClickHandler {


    private FragmentCartBinding binding;



    public CartFragment() {
        // Required empty public constructor
    }




    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        binding = FragmentCartBinding.inflate(inflater, container, false);
        return binding.getRoot();
    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        NavController navController = Navigation.findNavController(getActivity(), R.id.nav_host_fragment_content_main);
        ((MainActivity) getActivity()).getSupportActionBar().setDisplayHomeAsUpEnabled(false);
        ((MainActivity) getActivity()).getSupportActionBar().setDisplayShowHomeEnabled(false);



        ArrayList<String> list = new ArrayList<>();
        list.add("Desktops");
        list.add("Laptops");
        list.add("Processors");
        list.add("Graphic cards");
        list.add("Computer memory");
        list.add("Disk storage");
        CartAdapter adapter = new CartAdapter(list,this);
        LinearLayoutManager linearLayoutManager=new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.VERTICAL,false);
        binding.recyclerCart.setLayoutManager(linearLayoutManager);
        binding.recyclerCart.setAdapter(adapter);

    }

    @Override
    public void onItemClick(int position) {

    }
}