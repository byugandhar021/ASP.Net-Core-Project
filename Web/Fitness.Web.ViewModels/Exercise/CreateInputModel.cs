﻿namespace Fitness.Web.ViewModels.Exercise
{
    using System.ComponentModel.DataAnnotations;

    using Fitness.Data.Common;

    public class CreateInputModel
    {
        [Required]
        [StringLength(30, ErrorMessage = Constants.NameErrorMessage, MinimumLength = 3)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Video { get; set; }
    }
}
