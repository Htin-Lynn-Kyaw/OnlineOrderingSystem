using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineOrderingSystem.Models.Entities;

[Table("Tbl_MenuItem")]
public class MenuItem
{
    [Key]
    public Guid MenuID { get; set; }
    [StringLength(50)]
    public string MenuName { get; set; } = string.Empty;
    [StringLength(50)]
    public string Image { get; set; } = string.Empty;
    [StringLength(50)]
    public bool IsActive { get; set; }
    [StringLength(50)]
    public string Description { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public Guid CategoryID { get; set; }
    [ForeignKey("CategoryID")]
    public Category Category { get; set; }
}
