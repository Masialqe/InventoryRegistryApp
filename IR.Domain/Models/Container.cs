using IR.Domain.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IR.Domain.Enums;

namespace IR.Domain.Models
{
    public class Container : IModelBase
    {
        [Key]
        [Column("ContainerId")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("ContainerName")]
        public string Name { get; set; }

        [Required]
        [Column("ContainerMeasureType")]
        public MeasureTypes MeasureType { get; set; }

        [Required]
        [Column("ContainerCapacity")]
        public double Capacity { get; set; }

        [Required]
        [Column("ContainerCreated")]
        public DateOnly Created { get; set; }

        //navigation property 
        ICollection<Item> Items { get; set; }

        /// <summary>
        /// Adds Item to collection.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            if(Items == null)
                throw new ArgumentNullException();

            Items.Add(item);
        }
    }
}
