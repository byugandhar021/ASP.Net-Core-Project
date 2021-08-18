namespace Fitness.Web.ViewModels.Nutrition
{
    using System.ComponentModel.DataAnnotations;

    using Fitness.Data.Common;
    using Fitness.Data.Models;

    public class CreateNutritionInputModel 
    {
        [Required]
        [StringLength(30, ErrorMessage = Constants.NameErrorMessage, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Ingredients { get; set; }

        public int? Calories { get; set; }

        public string CategoryId { get; set; }

        public string Category { get; set; }

        public string UserId { get; set; }
    }
}
