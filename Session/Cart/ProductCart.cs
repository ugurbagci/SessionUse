using Session.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Session.Cart
{
    public class ProductCart
    {
        private Dictionary<int, ProductVM> _cart = null;

        public List<ProductVM> CartProductList
        {
            get
            {
                return _cart.Values.ToList();
            }

        }
        public ProductCart()
        {
            _cart = new Dictionary<int, ProductVM>();
        }
        public void AddCart(ProductVM item)
        {
            // eğer bu ürün sepete ilk defa geliyorsa
            if (!_cart.ContainsKey(item.Id))
            {
                _cart.Add(item.Id, item);
            }
            else
            {
                _cart[item.Id].Quantity++;
            }
        }
        public void RemoveCart(int id)
        {
            _cart.Remove(id);
        }
        public void DecreaseCart(int id)
        {
            _cart[id].Quantity--;
            if (_cart[id].Quantity <= 0) _cart.Remove(id);            
        }
        public void IncreaseCart(int id)
        {
            _cart[id].Quantity++;
        }
    }
}