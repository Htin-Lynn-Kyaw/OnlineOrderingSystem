using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineOrderingSystem.Models.Entities;

[Table("Tbl_OrderItem")]
public class OrderItem
{
    [Key]
    public Guid OrderItemID { get; set; }

    public Guid OrderID { get; set; }
    [ForeignKey("OrderID")]
    public Order Order { get; set; }

    public Guid MenuItemID { get; set; }
    [ForeignKey("MenuItemID")]
    public MenuItem MenuItem { get; set; }

    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
}
