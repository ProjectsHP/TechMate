using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_Service_Server_
{
    public class OrderClass
    {
        int orderId;
        int cardNumber;
        string orderDate;
        int totalPrice;
        int totalItems;
        string paymentMade;
        string orderStatus;
        DeliveryAddress deliveryAddress;
        User user;
        List<CartItem> listOfCartObj;
        List<Component> listOfComponents;

      
        public OrderClass() { }

        public OrderClass(int orderId, int cardNumber, string orderDate, int totalPrice, int totalItems, string paymentMade, string orderStatus, DeliveryAddress deliveryAddress, User user, List<CartItem> listOfCartObj, List<Component> listOfComponents)
        {
            this.OrderId = orderId;
            this.CardNumber = cardNumber;
            this.OrderDate = orderDate;
            this.TotalPrice = totalPrice;
            this.TotalItems = totalItems;
            this.PaymentMade = paymentMade;
            this.OrderStatus = orderStatus;
            this.DeliveryAddress = deliveryAddress;
            this.User = user;
            this.ListOfCartObj = listOfCartObj;
            this.ListOfComponents = listOfComponents;
        }

        public int OrderId { get => orderId; set => orderId = value; }
        public int CardNumber { get => cardNumber; set => cardNumber = value; }
        public string OrderDate { get => orderDate; set => orderDate = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int TotalItems { get => totalItems; set => totalItems = value; }
        public string PaymentMade { get => paymentMade; set => paymentMade = value; }
        public string OrderStatus { get => orderStatus; set => orderStatus = value; }
        public DeliveryAddress DeliveryAddress { get => deliveryAddress; set => deliveryAddress = value; }
        public User User { get => user; set => user = value; }
        public List<CartItem> ListOfCartObj { get => listOfCartObj; set => listOfCartObj = value; }
        public List<Component> ListOfComponents { get => listOfComponents; set => listOfComponents = value; }
    }
}