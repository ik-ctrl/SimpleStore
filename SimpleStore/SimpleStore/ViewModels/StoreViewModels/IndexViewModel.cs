using System.Collections.Generic;
using System.Linq;

namespace SimpleStore.ViewModels.StoreViewModels
{
    /// <summary>
    /// Модель представления для Index.html
    /// </summary>
    public class IndexViewModel
    {

        public IndexViewModel(IEnumerable<ProductViewModel> productViewModels,int currentPageNumber,int finalPageNumber)
        {
            //todo: может стоит сразу передавать  лист?
            var viewModels = productViewModels.ToList();
            Products = viewModels;
            ProductsCount = viewModels.Count();
            CurrentPageNumber = currentPageNumber;
            FinalPageNumber = finalPageNumber;
        }

        /// <summary>
        /// Список отображаемых продуктов
        /// </summary>
        public IEnumerable<ProductViewModel> Products { get; }

        /// <summary>
        /// Количество продуктов для отображения
        /// </summary>
        public int ProductsCount { get; }

        /// <summary>
        /// Номер текущей страницы
        /// </summary>
        public int CurrentPageNumber { get; }
        
        /// <summary>
        /// Номер последней страницы
        /// </summary>
        public int FinalPageNumber { get; }

    }
}
