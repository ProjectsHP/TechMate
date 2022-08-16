package com.example.androidclient;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;
import androidx.recyclerview.widget.GridLayoutManager;

import com.example.androidclient.adapters.ItemListAdapter;
import com.example.androidclient.databinding.FragmentItemsListBinding;
import com.example.androidclient.ui.IRecyclerViewClickHandler;

import java.util.ArrayList;

public class ItemsListFragment extends Fragment implements IRecyclerViewClickHandler {

    private FragmentItemsListBinding binding;

    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState
    ) {

        binding = FragmentItemsListBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        ArrayList list = new ArrayList<>();
        list.add("Object 1 if working correct");
        list.add("Object 2 if working correct");
        list.add("Object 3 if working correct");
        list.add("Object 4 if working correct");
        list.add("Object 5 if working correct");
        list.add("Object 6 if working correct");
        list.add("Object 7 if working correct");
        list.add("Object 8 if working correct");
        ItemListAdapter adapter = new ItemListAdapter(list,this);
        //LinearLayoutManager linearLayoutManager=new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.HORIZONTAL,false);
        binding.recyclerListItems.setLayoutManager(new GridLayoutManager(getContext(),2));
        binding.recyclerListItems.setAdapter(adapter);


    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

    @Override
    public void onItemClick(int position) {

        NavHostFragment.findNavController(ItemsListFragment.this)
                        .navigate(R.id.action_ItemsListFragment_to_ProductDetailsFragment);


    }

}