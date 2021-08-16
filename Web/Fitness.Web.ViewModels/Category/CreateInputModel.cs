namespace Fitness.Web.ViewModels.Category
{
    using System.ComponentModel.DataAnnotations;

    public class CreateInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string CategoryType { get; set; }
    }
}
