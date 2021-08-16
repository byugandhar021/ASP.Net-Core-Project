namespace Fitness.Web.ViewModels.Gym
{
    using Fitness.Data.Models;
    using Fitness.Services.Mapping;

    public class DetailsViewModel : IMapFrom<Gym>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string WorkTime { get; set; }

        public string ImageUrl { get; set; }
    }
}
