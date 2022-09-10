package com.example.androidclient.objects;

import android.os.Parcel;
import android.os.Parcelable;

public class CartItemObject implements Parcelable {

    int productId;
    int userId;
    int orderId;
    int quantity;
    int productPrice;
    int buildId;

    public CartItemObject() {
    }

    public CartItemObject(int productId, int userId, int orderId, int quantity, int productPrice, int buildId) {
        this.productId = productId;
        this.userId = userId;
        this.orderId = orderId;
        this.quantity = quantity;
        this.productPrice = productPrice;
        this.buildId = buildId;
    }

    protected CartItemObject(Parcel in) {
        productId = in.readInt();
        userId = in.readInt();
        orderId = in.readInt();
        quantity = in.readInt();
        productPrice = in.readInt();
        buildId = in.readInt();
    }

    public static final Creator<CartItemObject> CREATOR = new Creator<CartItemObject>() {
        @Override
        public CartItemObject createFromParcel(Parcel in) {
            return new CartItemObject(in);
        }

        @Override
        public CartItemObject[] newArray(int size) {
            return new CartItemObject[size];
        }
    };

    public int getProductId() {
        return productId;
    }

    public void setProductId(int productId) {
        this.productId = productId;
    }

    public int getUserId() {
        return userId;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }

    public int getOrderId() {
        return orderId;
    }

    public void setOrderId(int orderId) {
        this.orderId = orderId;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public int getProductPrice() {
        return productPrice;
    }

    public void setProductPrice(int productPrice) {
        this.productPrice = productPrice;
    }

    public int getBuildId() {
        return buildId;
    }

    public void setBuildId(int buildId) {
        this.buildId = buildId;
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(productId);
        dest.writeInt(userId);
        dest.writeInt(orderId);
        dest.writeInt(quantity);
        dest.writeInt(productPrice);
        dest.writeInt(buildId);
    }
}
