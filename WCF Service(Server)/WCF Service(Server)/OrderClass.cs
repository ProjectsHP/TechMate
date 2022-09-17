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
        int cardId;
        int paymentId;
        int userAddressId;
        int userId;
        int totalPrice;
        int totalItems;
        string paymentMade;
        string orderStatus;
        ArrayList listOfCartItemId;

        public OrderClass() { }

        public OrderClass(int orderId, int cardId, int paymentId, int userAddressId, int userId, int totalPrice, int totalItems, string paymentMade, string orderStatus, ArrayList listOfCartItemId)
        {
            this.OrderId = orderId;
            this.CardId = cardId;
            this.PaymentId = paymentId;
            this.UserAddressId = userAddressId;
            this.UserId = userId;
            this.TotalPrice = totalPrice;
            this.TotalItems = totalItems;
            this.PaymentMade = paymentMade ?? throw new ArgumentNullException(nameof(paymentMade));
            this.OrderStatus = orderStatus ?? throw new ArgumentNullException(nameof(orderStatus));
            this.ListOfCartItemId = listOfCartItemId ?? throw new ArgumentNullException(nameof(listOfCartItemId));
        }

        public int OrderId { get => orderId; set => orderId = value; }
        public int CardId { get => cardId; set => cardId = value; }
        public int PaymentId { get => paymentId; set => paymentId = value; }
        public int UserAddressId { get => userAddressId; set => userAddressId = value; }
        public int UserId { get => userId; set => userId = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int TotalItems { get => totalItems; set => totalItems = value; }
        public string PaymentMade { get => paymentMade; set => paymentMade = value; }
        public string OrderStatus { get => orderStatus; set => orderStatus = value; }
        public ArrayList ListOfCartItemId { get => listOfCartItemId; set => listOfCartItemId = value; }
    }
}