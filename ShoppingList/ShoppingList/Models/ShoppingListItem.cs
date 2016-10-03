using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ShoppingList.Models
{
    public class ShoppingListItem
    {
        [Key]
        public int ShoppingListItemId { get; set; }

        [ForeignKey("ShoppingList")]
        public int ShoppingListId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string Content { get; set; }

        public Priority Priority { get; set; }
        
        [MinLength(2)]
        [MaxLength(25)]
        public string Note { get; set; }

        [Display(Name = "Purchased")]
        public bool IsChecked { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        //[DataType(DataType.Upload)]
        //public sbyte Image { get; set; }

        //public ImageList SmallImageList Image { get; set; }

        public override string ToString()
        {
            return $"[{ShoppingListItemId}]";
        }
        
        public virtual ShoppingList ShoppingList { get; set; }

        public virtual ICollection<File> Files { get; set; }

    }
}
