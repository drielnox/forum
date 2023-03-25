using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace drielnox.Forum.Business.Entities
{
    public sealed class User : IdentityUser
    {
        [Column("FirstName"), MaxLength(50)]
        public string FirstName { get; set; }
        [Column("LastName"), MaxLength(50)]
        public string LastName { get; set; }
    }
}
