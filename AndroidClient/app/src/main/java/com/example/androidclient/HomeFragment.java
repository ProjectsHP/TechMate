package com.example.androidclient;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import com.example.androidclient.adapters.ProductsAdapter;
import com.example.androidclient.databinding.FragmentHomeBinding;
import com.example.androidclient.ui.IRecyclerViewClickHandler;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.fragment.NavHostFragment;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;

public class HomeFragment extends Fragment implements IRecyclerViewClickHandler {

    private FragmentHomeBinding binding;
    private ImageView toolbarIcon;

    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState) {

        binding = FragmentHomeBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

//        NavController navController = Navigation.findNavController(getActivity(), R.id.nav_host_fragment_content_main);
//        ((MainActivity) getActivity()).getSupportActionBar().setDisplayHomeAsUpEnabled(false);

        ArrayList list = new ArrayList<>();
        list.add("Object 1 if working correct");
        list.add("Object 2 if working correct");
        list.add("Object 3 if working correct");
        list.add("Object 4 if working correct");
        list.add("Object 5 if working correct");
        list.add("Object 6 if working correct");
        ProductsAdapter adapter = new ProductsAdapter(list,this);
        LinearLayoutManager linearLayoutManager=new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.HORIZONTAL,false);
        binding.recyclerPopularProducts.setLayoutManager(linearLayoutManager);
        binding.recyclerPopularProducts.setAdapter(adapter);


        binding.buttonFirst.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
//                NavHostFragment.findNavController(HomeFragment.this)
//                        .navigate(R.id.action_HomeFragment_to_SecondFragment);
            }
        });
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }


    @Override
    public void onResume() {
        super.onResume();
        ((AppCompatActivity)getActivity()).getSupportActionBar().setDisplayShowTitleEnabled(false);

    }

    @Override
    public void onStop() {
        super.onStop();
        ((AppCompatActivity)getActivity()).getSupportActionBar().setDisplayShowTitleEnabled(true);

    }

    @Override
    public void onItemClick(int position) {
      //  NavHostFragment.findNavController(HomeFragment.this)
        //                .navigate(R.id.action_HomeFragment_to_SecondFragment);
    }

//    @Override
//    public boolean onCreateOptionsMenu(Menu menu) {
//        MenuInflater inflater = getMenuInflater();
//        inflater.inflate(R.menu.options_menu, menu);
//
//        return true;
//    }




}