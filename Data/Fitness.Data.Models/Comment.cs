namespace Fitness.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Fitness.Data.Common.Models;

    public class Comment : BaseDeletableModel<string>
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string PostId { get; set; }

        [Required]
        public string DietId { get; set; }

        public Diet Diet { get; set; }

        [Required]
        public string ExerciseId { get; set; }

        public Exercise Exercise { get; set; }

        [Required]
        public string NutritionId { get; set; }

        public Nutrition Nutrition { get; set; }

        [Required]
        public string GymId { get; set; }

        public Gym Gym { get; set; }
    }
}
