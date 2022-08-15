package com.example.androidclient.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.androidclient.R;

import java.util.ArrayList;

public class IconLabelAdapter extends RecyclerView.Adapter{


    ArrayList itemList;
    Context mContext;

    public IconLabelAdapter(ArrayList List, Context context) {
        this.itemList = List;
        this.mContext = context;
    }

    @NonNull
    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
       // View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.symptom_view,parent,false);
        //ViewHolder viewHolder = new ViewHolder(view);
        return null;
    }

    public class ViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener
    {

        //place ur ui controls here
        TextView txtDiagnose;
        OnItmListener onItmListener;
        public ViewHolder(@NonNull View itemView, OnItmListener onItmListener1) {
            super(itemView);
            this.onItmListener =  onItmListener1;
          //  txtDiagnose=itemView.findViewById(R.id.txtSymptomID);
            itemView.setTag(itemView);
            itemView.setOnClickListener(this); // bind the listener

        }

        @Override
        public void onClick(View v) {

            onItmListener.onItmCLick(getBindingAdapterPosition());
        }
    }

    @Override
    public void onBindViewHolder(@NonNull RecyclerView.ViewHolder holder, int position) {

    }

    public interface OnItmListener{
        void onItmCLick(int position);
    }

    @Override
    public int getItemCount() {
        return itemList.size();
    }
}
