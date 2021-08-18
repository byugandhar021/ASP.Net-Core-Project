namespace Fitness.Web.ViewModels.Exercise
{
    using Fitness.Data.Models;
    using Fitness.Services.Mapping;

    public class DetailsViewModel : IMapFrom<Exercise>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Video { get; set; }
    }
}
