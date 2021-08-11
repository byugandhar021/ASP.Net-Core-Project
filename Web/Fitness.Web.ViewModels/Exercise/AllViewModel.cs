namespace Fitness.Web.ViewModels.Exercise
{
    using Fitness.Data.Models;
    using Fitness.Services.Mapping;

    public class AllViewModel : IMapFrom<Exercise>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Video { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string CategoryId { get; set; }
    }
}
