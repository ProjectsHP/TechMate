package com.example.androidclient;

public class UserObject {

    private int Id;
    private String Name;
    private String Surname;
    private String Email;
    private int PhoneNo;
    private String Gender;
    private String UserType;

    public UserObject(){};

    public UserObject(int id, String name, String surname, String email, int phoneNo, String gender, String userType) {
        this.Id = id;
        this.Name = name;
        this.Surname = surname;
        this.Email = email;
        this.PhoneNo = phoneNo;
        this.Gender = gender;
        this.UserType = userType;
    }

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getSurname() {
        return Surname;
    }

    public void setSurname(String surname) {
        Surname = surname;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        Email = email;
    }

    public int getPhoneNo() {
        return PhoneNo;
    }

    public void setPhoneNo(int phoneNo) {
        PhoneNo = phoneNo;
    }

    public String getGender() {
        return Gender;
    }

    public void setGender(String gender) {
        Gender = gender;
    }

    public String getUserType() {
        return UserType;
    }

    public void setUserType(String userType) {
        UserType = userType;
    }



}
