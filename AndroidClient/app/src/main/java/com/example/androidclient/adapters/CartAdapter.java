package com.example.androidclient.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.androidclient.CartFragment;
import com.example.androidclient.R;
import com.example.androidclient.objects.ProductObject;
import com.example.androidclient.ui.ICartClickHandler;
import com.example.androidclient.ui.IRecyclerViewClickHandler;

import java.util.ArrayList;

public class CartAdapter extends RecyclerView.Adapter<CartAdapter.ViewHolder>{

    private final ArrayList<ProductObject> localDataSet;
//    private final IRecyclerViewClickHandler recyclerViewClickHandler;
    private final ICartClickHandler iclickHandler;
    Context mContext;




    public static class ViewHolder extends RecyclerView.ViewHolder {
        private final TextView txtName;
        private final TextView txtCategory;
        private final TextView txtPrice;
        private final ImageView imgCart;
        EditText txtQuantity;


        public ViewHolder(View view, ICartClickHandler recyclerViewClickHandler) {
            super(view);
            // Define click listener for the ViewHolder's View

            view.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    if(recyclerViewClickHandler!=null){
                        int pos = getBindingAdapterPosition();

                        if(pos!= RecyclerView.NO_POSITION){
                            recyclerViewClickHandler.OncartClickListener(pos);
                        }

                    }
                }
            });
            txtName = (TextView) view.findViewById(R.id.cartNameItem);
            txtCategory = (TextView) view.findViewById(R.id.cartCategoryItem);
            txtPrice = (TextView) view.findViewById(R.id.cartPriceItem);
            txtQuantity = (EditText) view.findViewById(R.id.txtQuantityNum);
            imgCart = (ImageView) view.findViewById(R.id.imgCart);
        }

        public EditText getTxtQuantity() {
            return txtQuantity;
        }

        public TextView getNameView() {
            return txtName;
        }

        public TextView getPriceView() {
            return txtPrice;
        }

        public TextView getCategoryView() {
            return txtCategory;
        }

        public ImageView getCartImageView() {
            return imgCart;
        }


    }

    public CartAdapter(ArrayList<ProductObject> dataSet,Context context , ICartClickHandler clickHandler) {
        this.iclickHandler=clickHandler;
        this.localDataSet = dataSet;
        this.mContext = context;
    }



    // Create new views (invoked by the layout manager)
    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(ViewGroup viewGroup, int viewType) {
        // Create a new view, which defines the UI of the list item
        View view = LayoutInflater.from(viewGroup.getContext())
                .inflate(R.layout.recycler_cart_item, viewGroup, false);

        return new CartAdapter.ViewHolder(view,iclickHandler);
    }


    @Override
    public void onBindViewHolder(ViewHolder viewHolder, final int position) {

        // Get element from your dataset at this position and replace the
        // contents of the view with that element


        String imageName = localDataSet.get(position).getImage();
        String result = imageName.substring(0, imageName.indexOf("."));
        int drawableId = mContext.getResources().getIdentifier(result, "drawable", mContext.getPackageName());
        viewHolder.getCartImageView().setImageResource(drawableId);
        viewHolder.getNameView().setText((CharSequence) localDataSet.get(position).getName());
        viewHolder.getCategoryView().setText((CharSequence) localDataSet.get(position).getCategory());
        viewHolder.getPriceView().setText("R"+ localDataSet.get(position).getPrice());
       String x = viewHolder.getTxtQuantity().getText().toString();

    }


    @Override
    public int getItemCount() { return localDataSet.size(); }



}
