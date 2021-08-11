namespace Fitness.Web.ViewModels.Diet
{
    using System.ComponentModel.DataAnnotations;

    using Fitness.Data.Common;

    public class EditInputModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = Constants.NameErrorMessage, MinimumLength = 3)]
        public string Name { get; set; }

        public string Duration { get; set; }

        [Required]
        public string Description { get; set; }

        public string UserId { get; set; }
    }
}
