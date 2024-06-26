using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineOrderingSystem.Models.Entities;

public class AppUser : IdentityUser<Guid>
{
    [StringLength(50)]
    public string? Nickname { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    public Guid? AddressID { get; set; }
    [ForeignKey("AddressID")]
    public Address? Address { get; set; }
}
