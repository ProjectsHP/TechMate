package com.example.androidclient.login;

import android.content.Context;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentPagerAdapter;
import androidx.lifecycle.Lifecycle;
import androidx.viewpager2.adapter.FragmentStateAdapter;

public class FragmentAdapter extends FragmentPagerAdapter {


    private Context context;
    private int totTabs;

    public FragmentAdapter(@NonNull FragmentManager fm, Context myContext, int totalTabs) {
        super(fm);
        this.context=myContext;
        this.totTabs=totalTabs;


    }

    @NonNull
    @Override
    public Fragment getItem(int position) {
        switch (position){
            case 0:
                SignInFragment signInFragment = new SignInFragment();

                return signInFragment;
            case 1:
                SignUpFragment signUpFragment = new SignUpFragment();
                return signUpFragment;
            default:
                return null;

        }

    }

    @Override
    public int getCount() {
        return totTabs;
    }
}
