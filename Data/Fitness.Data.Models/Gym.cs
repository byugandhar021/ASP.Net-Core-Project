namespace Fitness.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Fitness.Data.Common;
    using Fitness.Data.Common.Models;

    public class Gym : BaseDeletableModel<string>
    {
        public Gym()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [StringLength(30, ErrorMessage = Constants.ErrorMessageName, MinimumLength = 3)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime WorkTime { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
