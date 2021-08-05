// ReSharper disable VirtualMemberCallInConstructor
namespace Fitness.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Fitness.Data.Common;
    using Fitness.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Nutritions = new HashSet<Nutrition>();
            this.Diets = new HashSet<Diet>();
            this.Comments = new HashSet<Comment>();
            this.Exercises = new HashSet<Exercise>();
            this.Gyms = new HashSet<Gym>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = Constants.PasswordErrorMessage, MinimumLength = 3)]
        public string Password { get; set; }

        [Required]
        public string Location { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Diet> Diets { get; set; }

        public ICollection<Nutrition> Nutritions { get; set; }

        public ICollection<Exercise> Exercises { get; set; }

        public ICollection<Gym> Gyms { get; set; }
    }
}
