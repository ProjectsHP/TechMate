package com.example.androidclient.ui;

import android.app.Activity;
import android.content.DialogInterface;
import android.view.View;
import android.view.ViewGroup;

import androidx.appcompat.app.AlertDialog;

public class UIComponents {

    private final Activity myActivity;
    public UIComponents(Activity mActivity){
        this.myActivity = mActivity;
    }

    public void alertDialog_DefaultNoCancel(String msg, String title, String OKBtn) {
        AlertDialog.Builder dialog=new AlertDialog.Builder(myActivity);
        dialog.setMessage(msg);
        dialog.setTitle(title);
        dialog.setPositiveButton(OKBtn,
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog,
                                        int which) {
                    }
                });
        AlertDialog alertDialog=dialog.create();
        alertDialog.show();
    }

    public void disableLayoutAndChildren(ViewGroup layout, boolean enable) {
        for (int i = 0; i < layout.getChildCount(); i++) {
            View child = layout.getChildAt(i);
            child.setEnabled(enable);
            if (child instanceof ViewGroup) {
                ViewGroup group = (ViewGroup) child;
                for (int j = 0; j < group.getChildCount(); j++) {
                    group.getChildAt(j).setEnabled(enable);
                    group.getChildAt(j).setClickable(enable);
                }
            }

        }
    }


}
