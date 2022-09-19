using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_Service_Server_
{
    public class CartItemClass
    {
        int productId;
        int userId;
        int orderId;
        int quantity;
        int productPrice;
        int buildId;

        public CartItemClass()
        {
        }

        public CartItemClass(int productId, int userId, int orderId, int quantity, int productPrice, int buildId)
        {
            this.ProductId = productId;
            this.UserId = userId;
            this.OrderId = orderId;
            this.Quantity = quantity;
            this.ProductPrice = productPrice;
            this.BuildId = buildId;
        }

        public int ProductId { get => productId; set => productId = value; }
        public int UserId { get => userId; set => userId = value; }
        public int OrderId { get => orderId; set => orderId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int ProductPrice { get => productPrice; set => productPrice = value; }
        public int BuildId { get => buildId; set => buildId = value; }
    }
}