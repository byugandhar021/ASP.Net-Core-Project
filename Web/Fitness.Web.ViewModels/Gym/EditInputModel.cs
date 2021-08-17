namespace Fitness.Web.ViewModels.Gym
{
    using System.ComponentModel.DataAnnotations;

    using Fitness.Data.Common;
    using Fitness.Data.Models;
    using Fitness.Services.Mapping;

    public class EditInputModel : IMapFrom<Gym>
    {
        public string Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = Constants.NameErrorMessage, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string WorkTime { get; set; }

        public string ImageUrl { get; set; }
    }
}
