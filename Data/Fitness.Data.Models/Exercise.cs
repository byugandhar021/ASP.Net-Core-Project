namespace Fitness.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Fitness.Data.Common;
    using Fitness.Data.Common.Models;

    public class Exercise : BaseDeletableModel<string>
    {
        public Exercise()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [StringLength(30, ErrorMessage = Constants.ErrorMessageName, MinimumLength = 3)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Video { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
