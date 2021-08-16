namespace Fitness.Web.ViewModels.Gym
{
    using System.ComponentModel.DataAnnotations;

    using Fitness.Data.Common;

    public class CreateInputModel
    {
        [Required]
        [StringLength(30, ErrorMessage = Constants.NameErrorMessage, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        public string WorkTime { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
