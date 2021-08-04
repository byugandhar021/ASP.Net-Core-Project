namespace Fitness.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RoleModification
    {
        [Required]
        public string RoleName { get; set; }

        public string RoleId { get; set; }

        public string[] AddedIds { get; set; }

        public string[] DeletedIds { get; set; }

    }
}
