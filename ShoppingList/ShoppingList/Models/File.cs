using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class File
    {
        public int FileId { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }
        
        public FileType FileType { get; set; }

        public int ShoppingListItemId { get; set; }

        public virtual ShoppingListItem ShoppingListItem { get; set; }
    }
}