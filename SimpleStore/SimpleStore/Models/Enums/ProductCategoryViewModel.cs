using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Models.Enums
{
    /// <summary>
    /// Представление товаров для фильтрации 
    /// </summary>
    public enum ProductCategoryViewModel
    {
        [Display(Name = "Все")]
        All =0,
        [Display(Name = "Книги")]
        Books = 10,
        [Display(Name = "Электроника")]
        Electronics = 20,
        [Display(Name = "Одежда")]
        Wear = 30,
        [Display(Name = "Спорт")]
        Sports = 40,
        [Display(Name = "Обувь")]
        Footwear = 50,
    }
}
