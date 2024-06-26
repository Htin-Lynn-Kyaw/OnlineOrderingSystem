using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineOrderingSystem.Models.Entities;

[Table("Tbl_Order")]
public class Order
{
    [Key]
    public Guid OrderID { get; set; }

    public Guid UserID { get; set; }
    [ForeignKey("UserID")]
    public AppUser User { get; set; }

    public Guid RestaurantID { get; set; }
    [ForeignKey("RestaurantID")]
    public Restaurant Restaurant { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Total { get; set; }
    public bool IsActive { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

}
