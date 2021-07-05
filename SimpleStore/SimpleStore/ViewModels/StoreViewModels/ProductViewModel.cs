using System.Collections.Generic;
using SimpleStore.Database.DAL;

namespace SimpleStore.ViewModels.StoreViewModels
{
    public class ProductViewModel
    {
        private readonly Product _product;
        
        public ProductViewModel(Product product)
        {
            _product = product;
        }

        /// <summary>
        /// Цена товара
        /// </summary>
        public double Price => _product.Price;

        /// <summary>
        /// Название товара
        /// </summary>
        public string Name => _product.Name;

        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description => _product.Description;

        /// <summary>
        /// Скидка на товар
        /// </summary>
        public double Discount => _product.Discount;


        /// <summary>
        /// Оставшееся количество товара
        /// </summary>
        public double ProductCount => _product.ProductCount;

        /// <summary>
        /// Изобращения товара
        /// </summary>
        public ICollection<ProductImage> Images => _product.Images;

        public override string ToString()
        {
            return $"{_product.Id}|{_product.Name}|{_product.Price}";
        }
    }
}
