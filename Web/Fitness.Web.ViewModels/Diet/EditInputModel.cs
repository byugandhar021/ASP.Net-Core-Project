﻿namespace Fitness.Web.ViewModels.Diet
{
    using System.ComponentModel.DataAnnotations;

    using Fitness.Data.Common;
    using Fitness.Data.Models;
    using Fitness.Services.Mapping;

    public class EditInputModel : IMapFrom<Diet>
    {
        public string Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = Constants.NameErrorMessage, MinimumLength = 3)]
        public string Name { get; set; }

        public string Duration { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
