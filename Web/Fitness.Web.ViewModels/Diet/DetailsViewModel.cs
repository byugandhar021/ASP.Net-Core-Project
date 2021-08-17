namespace Fitness.Web.ViewModels.Diet
{
    using System;

    using Fitness.Data.Models;
    using Fitness.Services.Mapping;

    public class DetailsViewModel : IMapFrom<Diet>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Duration { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserEmail { get; set; }
    }
}
