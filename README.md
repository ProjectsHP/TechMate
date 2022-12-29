# TechMate - Shopping System
## Table of contents
- Introduction
- Motivation
- Project Description
- Use Cases
- Mobile App Demonstration
- Website Demonstration
- Frameworks and Technologies used

## Introduction
TechMate is an e-commerce system that consists of an ASP.NET web application and an Android application that allows users to search and make a computer build from existing components stored in the database, add them to the shopping cart, and then make payments. The guest user can browse, search and add single components to the cart only. Checkout and payment option is available for registered users.

## Motivation
I developed this system as a final-year project to demonstrate my basic understanding of the fundamentals of control structures and problem-solving techniques.
It is often difficult to find specific devices/computers in stores mostly high-end devices, it is rare to find a device with the exact specs that you want, so clients end up settling for something similar and therefore not fully satisfied with their buy. It is costly to look around your local area for an exact spec. With such expensive devices, people want to buy exactly what they want.

## Project Description
A shopping system for an online store, This online store allows users to build their computer based on a set of components available. An administrator can add and manage the specific components that users will be able to use. Each component has a description and a unit price. The administrator then manages the compatibility for each component (i.e. which component can and cannot be used with others). The stock level (number left) for each component is recorded. Managers can add new stock when new stock arrives.

A client can create an order. A single order is made up of single or multiple completed products. During the assembly phase, the system will verify compatibility as well as available stock for each component. Once the client is satisfied, they can place the order. The store clerk can view all orders and products (with the components) within the order. Once the clerk has assembled the order, they can fulfill the order and the stock levels are adjusted accordingly. The order can then be sent or picked up by the client, after the clerk can finalize the order. At any time, the manager is kept informed of stock levels and views the popularity of components to make informed decisions.

### Demo users credentials: 
- Client EMAIL = "user1@user.com", PASSWORD = "user1"
- Manager EMAIL = "manager1@manager.com", PASSWORD = "manager1"
- Admin EMAIL = "admin1@admin.com", PASSWORD = "admin1"
- Clerk EMAIL = "clerk1@clerk.com", PASSWORD = "cleck1"
- Stock Manager EMAIL = "sManager1@manager.com", PASSWORD = "sManager1"

## Use Cases
![Capture](https://user-images.githubusercontent.com/79909042/209935141-019495fb-ad8b-41df-9ec3-5573d4742edf.PNG)

## Mobile App Demonstration
https://user-images.githubusercontent.com/79909042/209938676-cda7b538-f5da-4004-9a87-1d91a34add74.mp4
### Features
- Uses Volley to request to the RESTful WCF Service
- It supports Android 8 and above
- All Products and data is retrieved from the Microsoft SQL Server Database hosted in Azure
- Developed in Java and Material 3 design kit

### Known Bugs
- App does not use dynamic colors at first open, you must close and open again
- If you move to another activity while bottom toolbar is hidden it cannot be retrieved again, you must restart the application
- Login Logo is not Updated
- Certain Activities are not yet implemented

## Website Demonstration
Use link below 
https://techmateweb.azurewebsites.net/Home
### Known buggs
- Certain pages are not yet implemented
- Logos are not consistent

## Frameworks and Technologies used
- The project is a Client-Server application targeting a small user base
- Uses a WCF Service(C#) as a API
- Uses a ASP.Net website(C#, HTML, CSS, Javascript)
- Mobile App(Android Studio-Java) -  Android OS only
- API and Website are hosted in Azure
- Database is an Microsoft SQL Server DB 
- The application include data access with the following conditions:
- Create, Retrieve, Update and Delete functionality

