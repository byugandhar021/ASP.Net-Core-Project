namespace Fitness.Web.ViewModels.Category
{
    using Fitness.Data.Models;
    using Fitness.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public CategoryType CategoryType { get; set; }
    }
}
