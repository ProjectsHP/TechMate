package com.example.androidclient.orders;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Switch;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentPagerAdapter;
import androidx.fragment.app.FragmentStatePagerAdapter;
import androidx.lifecycle.Lifecycle;
import androidx.recyclerview.widget.RecyclerView;
import androidx.viewpager2.adapter.FragmentStateAdapter;

import com.example.androidclient.R;
import com.example.androidclient.login.SignInFragment;
import com.example.androidclient.login.SignUpFragment;

import java.util.ArrayList;
import java.util.List;

public class OrdersFragmentAdapter extends FragmentPagerAdapter  {

    public OrdersFragmentAdapter(FragmentManager fm) {
        super(fm);
    }

    @Override
    public Fragment getItem(int position) {
        Fragment fragment = null;
        switch(position){
            case 0:
                fragment = new DeliveryDetailsFragment();
                break;
            case 1:
                fragment = new PlaceOrderFragment();
                break;
            case 2:
                fragment = new ConfirmOrderFragment();
                break;
        }
        return fragment;
    }

    @Override
    public int getCount() {
        return 3;
    }

    @Override
    public CharSequence getPageTitle(int position) {
        String title = null;
        if (position == 0) {
            title = "Shipping";
        } else if (position == 1) {
            title = "Payment";
        }else if (position == 2) {
            title = "Confirm";
        }

        return title;
    }
}
