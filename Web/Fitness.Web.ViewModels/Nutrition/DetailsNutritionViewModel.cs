namespace Fitness.Web.ViewModels.Nutrition
{
    using Fitness.Data.Models;
    using Fitness.Services.Mapping;
    using System;

    public class DetailsNutritionViewModel : IMapFrom<Nutrition>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }

        public int Calories { get; set; }

        public string Category { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserEmail { get; set; }
    }
}
