using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineOrderingSystem.Models.Entities;

[Table("Tbl_Category")]
public class Category
{
    [Key]
    public Guid CategoryID { get; set; }
    [StringLength(50)]
    public string CategoryName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    public Guid RestaurantID { get; set; }
    [ForeignKey("RestaurantID")]
    public Restaurant Restaurant { get; set; }

}
