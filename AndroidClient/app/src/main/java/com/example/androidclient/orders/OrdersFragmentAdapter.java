package com.example.androidclient.orders;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentPagerAdapter;

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
                fragment = new MakePaymentFragment();
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
