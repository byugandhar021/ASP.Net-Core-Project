﻿namespace Fitness.Data.Models
{
    using System.Collections.Generic;

    public class RoleEdit
    {
        public ApplicationRole Role { get; set; }

        public IEnumerable<ApplicationUser> Members { get; set; }

        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }
}
