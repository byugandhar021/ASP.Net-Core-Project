namespace Fitness.Web.ViewModels.Gym
{

    using Fitness.Data.Models;

    using Fitness.Services.Mapping;

    public class SingleGymViewModel : IMapFrom<Gym>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string WorkTime { get; set; }

        public string ImageUrl { get; set; }
    }
}
