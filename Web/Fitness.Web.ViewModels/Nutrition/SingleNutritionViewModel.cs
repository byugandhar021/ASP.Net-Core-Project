namespace Fitness.Web.ViewModels.Nutrition
{
    using Fitness.Data.Models;
    using Fitness.Services.Mapping;

    public class SingleNutritionViewModel : IMapFrom<Nutrition>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }

        public int? Calories { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public string UserId { get; set; }
    }
}
