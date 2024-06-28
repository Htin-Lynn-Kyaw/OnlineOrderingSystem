using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineOrderingSystem.Models.Entities;

[Table("Tbl_Restaurant")]
public class Restaurant
{
    [Key]
    public Guid RestaurantID { get; set; }
    [StringLength(50)]
    public string ResName { get; set; } = string.Empty;
    [StringLength(50)]
    public string ResEmail { get; set; } = string.Empty;
    [StringLength(50)]
    public string Phone { get; set; } = string.Empty;
    [StringLength(50)]
    public string OpeningHour { get; set; } = string.Empty;
    [StringLength(50)]
    public string ClosingHour { get; set; } = string.Empty;
    public ICollection<Category> Categories { get; set; }

    [StringLength(200)]
    public string Location { get; set; }
    //public ICollection<Order> Orders { get; set; } = new List<Order>();

    //public Guid? AddressID { get; set; }
    //[ForeignKey("AddressID")]
    //public Address? Address { get; set; }
}
