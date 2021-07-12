using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Models.Enums
{
    /// <summary>
    /// Представление товаров для фильтрации 
    /// </summary>
    public enum ProductCategoryViewModel
    {
        [Display(Name = "Все")]
        All =-1,
        [Display(Name = "Книги")]
        Books = 0,
        [Display(Name = "Электроника")]
        Electronics = 10,
        [Display(Name = "Одежда")]
        Wear = 20,
        [Display(Name = "Спорт")]
        Sports = 30,
        [Display(Name = "Обувь")]
        Footwear = 40,
    }
}
