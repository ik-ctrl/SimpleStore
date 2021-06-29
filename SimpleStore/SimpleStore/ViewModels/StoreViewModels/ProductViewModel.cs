using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.Database.DAL;

namespace SimpleStore.ViewModels.StoreViewModels
{
    public class ProductViewModel
    {
        public readonly Product _product;
        
        public ProductViewModel(Product product)
        {
            _product = product;
        }

        public double Price => _product.Price;
        public string Name => _product.Name;

        public string Description => _product.Description;

        public double Discount => _product.Discount;

        public double ProductCount => _product.ProductCount;

        public ICollection<ProductImage> Images => _product.Images;

        public override string ToString()
        {
            return $"{_product.Id}|{_product.Name}|{_product.Price}";
        }
    }
}
