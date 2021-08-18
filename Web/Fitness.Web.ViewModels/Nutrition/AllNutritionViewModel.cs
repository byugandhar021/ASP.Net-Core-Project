namespace Fitness.Web.ViewModels.Nutrition
{
    using System.Collections.Generic;

    public class AllNutritionViewModel
    {
        public IEnumerable<SingleNutritionViewModel> Nutritions { get; set; }
    }
}
