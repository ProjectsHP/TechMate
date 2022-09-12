package com.example.androidclient.objects;

import android.os.Parcel;
import android.os.Parcelable;

import java.text.ParseException;

public class UserAddressObject implements Parcelable {

    String userId;
    String userName;
    String userSurname;
    String userCellNo;
    String userEmail;
    String country;
    String province;
    String city;
    String streetUnit;

    public UserAddressObject() {
    }

    public UserAddressObject(String userId, String userName, String userSurname, String userCellNo, String userEmail, String country, String province, String city, String streetUnit) {
        this.userId = userId;
        this.userName = userName;
        this.userSurname = userSurname;
        this.userCellNo = userCellNo;
        this.userEmail = userEmail;
        this.country = country;
        this.province = province;
        this.city = city;
        this.streetUnit = streetUnit;
    }

    protected UserAddressObject(Parcel in) {
        userId = in.readString();
        userName = in.readString();
        userSurname = in.readString();
        userCellNo = in.readString();
        userEmail = in.readString();
        country = in.readString();
        province = in.readString();
        city = in.readString();
        streetUnit = in.readString();
    }

    public static final Creator<UserAddressObject> CREATOR = new Creator<UserAddressObject>() {
        @Override
        public UserAddressObject createFromParcel(Parcel in) {
            return new UserAddressObject(in);
        }

        @Override
        public UserAddressObject[] newArray(int size) {
            return new UserAddressObject[size];
        }
    };

    public String getUserId() {
        return userId;
    }

    public void setUserId(String userId) {
        this.userId = userId;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getUserSurname() {
        return userSurname;
    }

    public void setUserSurname(String userSurname) {
        this.userSurname = userSurname;
    }

    public String getUserCellNo() {
        return userCellNo;
    }

    public void setUserCellNo(String userCellNo) {
        this.userCellNo = userCellNo;
    }

    public String getUserEmail() {
        return userEmail;
    }

    public void setUserEmail(String userEmail) {
        this.userEmail = userEmail;
    }

    public String getCountry() {
        return country;
    }

    public void setCountry(String country) {
        this.country = country;
    }

    public String getProvince() {
        return province;
    }

    public void setProvince(String province) {
        this.province = province;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public String getStreetUnit() {
        return streetUnit;
    }

    public void setStreetUnit(String streetUnit) {
        this.streetUnit = streetUnit;
    }


    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(userId);
        dest.writeString(userName);
        dest.writeString(userSurname);
        dest.writeString(userCellNo);
        dest.writeString(userEmail);
        dest.writeString(country);
        dest.writeString(province);
        dest.writeString(city);
        dest.writeString(streetUnit);
    }
}
