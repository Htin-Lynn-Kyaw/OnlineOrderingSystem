using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineOrderingSystem.Models.Entities;

[Table("Tbl_Address")]
public class Address
{
    [Key]
    public Guid AddressID { get; set; }
    [StringLength(50)]
    public string City { get; set; } = string.Empty;
    [StringLength(50)]
    public string Street { get; set; } = string.Empty;
    [StringLength(50)]
    public string Township { get; set; } = string.Empty;
    [StringLength(100)]
    public string Details { get; set; } = string.Empty;

    //public Restaurant? Restaurant { get; set; }
    public AppUser? AppUser { get; set; }
}
