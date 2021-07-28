namespace Fitness.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Fitness.Data.Common;
    using Fitness.Data.Common.Models;

    public class Diet : BaseDeletableModel<string>
    {
        public Diet()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [StringLength(30, ErrorMessage = Constants.ErrorMessageName, MinimumLength = 3)]
        public string Name { get; set; }

        public string DateTime { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
