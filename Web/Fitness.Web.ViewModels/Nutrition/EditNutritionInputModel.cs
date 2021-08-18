namespace Fitness.Web.ViewModels.Nutrition
{
    using System.ComponentModel.DataAnnotations;

    using Fitness.Data.Common;
    using Fitness.Data.Models;
    using Fitness.Services.Mapping;

    public class EditNutritionInputModel : IMapFrom<Nutrition>
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = Constants.NameErrorMessage, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Ingredients { get; set; }

        public int? Calories { get; set; }
    }
}
