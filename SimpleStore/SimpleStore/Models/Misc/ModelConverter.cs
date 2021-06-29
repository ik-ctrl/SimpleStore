using System.Collections.Generic;
using SimpleStore.Database.DAL;
using SimpleStore.ViewModels.StoreViewModels;

namespace SimpleStore.Models.Misc
{
    /// <summary>
    /// Конвертер модель в модель представления
    /// </summary>
    public static class ModelConverter
    {

        /// <summary>
        /// Конвертирует список моделей продукта в список моделей представления продукта 
        /// </summary>
        /// <param name="products"> Список моделей продуктов</param>
        /// <returns></returns>
        public static IEnumerable<ProductViewModel> ProductsToProductViewModels(IEnumerable<Product> products)
        {
            var productsVM = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsVM.Add(new ProductViewModel(product));
            }
            return productsVM;
        }
    }
}
