using IR.Domain.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IR.Domain.Enums;

namespace IR.Domain.Models
{
    public class Item : IModelBase
    {
        [Key]
        [Column("ItemId")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("ItemName")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column("ItemType")]
        public ItemTypes Type { get; set; }

        [Required]
        [Column("ItemQuantity")]
        public int Quantity { get; set; }

        [Required]
        [Column("ItemMade")]
        public DateOnly Made {  get; set; }

        [Column("ItemCreated")]
        public DateOnly Created { get; set; }

        // Navigation property
        public Container Container { get; set; }
    }
}
