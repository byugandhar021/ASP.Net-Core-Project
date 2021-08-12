namespace Fitness.Web.ViewModels.Diet
{
    using Fitness.Data.Models;
    using Fitness.Services.Mapping;

    public class SingleDietViewModel : IMapFrom<Diet>
    {
        public string Name { get; set; }

        public string Duration { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
