package com.example.androidclient.objects;

import android.os.Parcel;
import android.os.Parcelable;

import java.lang.reflect.Array;
import java.util.ArrayList;

public class OrderObject implements Parcelable {
    int orderId;
    int cardId;
    int paymentId;
    int userAddressId;
    int userId;
    int totalPrice;
    int totalItems;
    String paymentMade;
    String orderStatus;
    ArrayList<Integer> listOfCartItemId;

    public OrderObject() {
    }

    public OrderObject(int orderId, int cardId, int paymentId, int userAddressId, int userId, int totalPrice, int totalItems, String paymentMade, String orderStatus, ArrayList<Integer> listOfCartItemId) {
        this.orderId = orderId;
        this.cardId = cardId;
        this.paymentId = paymentId;
        this.userAddressId = userAddressId;
        this.userId = userId;
        this.totalPrice = totalPrice;
        this.totalItems = totalItems;
        this.paymentMade = paymentMade;
        this.orderStatus = orderStatus;
        this.listOfCartItemId = listOfCartItemId;
    }


    protected OrderObject(Parcel in) {
        orderId = in.readInt();
        cardId = in.readInt();
        paymentId = in.readInt();
        userAddressId = in.readInt();
        userId = in.readInt();
        totalPrice = in.readInt();
        totalItems = in.readInt();
        paymentMade = in.readString();
        orderStatus = in.readString();
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(orderId);
        dest.writeInt(cardId);
        dest.writeInt(paymentId);
        dest.writeInt(userAddressId);
        dest.writeInt(userId);
        dest.writeInt(totalPrice);
        dest.writeInt(totalItems);
        dest.writeString(paymentMade);
        dest.writeString(orderStatus);
    }

    @Override
    public int describeContents() {
        return 0;
    }

    public static final Creator<OrderObject> CREATOR = new Creator<OrderObject>() {
        @Override
        public OrderObject createFromParcel(Parcel in) {
            return new OrderObject(in);
        }

        @Override
        public OrderObject[] newArray(int size) {
            return new OrderObject[size];
        }
    };

    public int getOrderId() {
        return orderId;
    }

    public void setOrderId(int orderId) {
        this.orderId = orderId;
    }

    public int getCardId() {
        return cardId;
    }

    public void setCardId(int cardId) {
        this.cardId = cardId;
    }

    public int getPaymentId() {
        return paymentId;
    }

    public void setPaymentId(int paymentId) {
        this.paymentId = paymentId;
    }

    public int getUserAddressId() {
        return userAddressId;
    }

    public void setUserAddressId(int userAddressId) {
        this.userAddressId = userAddressId;
    }

    public int getUserId() {
        return userId;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }

    public int getTotalPrice() {
        return totalPrice;
    }

    public void setTotalPrice(int totalPrice) {
        this.totalPrice = totalPrice;
    }

    public int getTotalItems() {
        return totalItems;
    }

    public void setTotalItems(int totalItems) {
        this.totalItems = totalItems;
    }

    public String getPaymentMade() {
        return paymentMade;
    }

    public void setPaymentMade(String paymentMade) {
        this.paymentMade = paymentMade;
    }

    public String getOrderStatus() {
        return orderStatus;
    }

    public void setOrderStatus(String orderStatus) {
        this.orderStatus = orderStatus;
    }

    public ArrayList<Integer> getListOfCartItemId() {
        return listOfCartItemId;
    }

    public void setListOfCartItemId(ArrayList<Integer> listOfCartItemId) {
        this.listOfCartItemId = listOfCartItemId;
    }

}
