using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoParteIII
{
    public class CartItem : IEquatable<CartItem>
    {

        private int _productID;
        private string _productName;
        private int _productQuantity;
        private decimal _productPrice;

        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public int ProductQuantity
        {
            get { return _productQuantity; }
            set { _productQuantity = value; }
        }

        public decimal ProductPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; }
        }


        public CartItem(int productID, string productName, int productQuantity, decimal productPrice)
        {
            _productID = productID;
            _productName = productName;
            _productQuantity = productQuantity;
            _productPrice = productPrice;
        }

        public CartItem(int productID)
        {
            _productID = productID;
        }

        public decimal TotalPrice
        {
            get { return _productPrice * _productQuantity; }
        }

        /**
         * Equals() - Needed to implement the IEquatable interface
         *    Tests whether or not this item is equal to the parameter
         *    This method is called by the Contains() method in the List class
         *    We used this Contains() method in the ShoppingCart AddItem() method
         */
        public bool Equals(CartItem item)
        {
            return item._productID == this._productID;
        }
        

        

        
    }
}