using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class PType
    {
        public int Id { get; set; }
        [Display(Name = "Product Type")]
        public string Name { get; set; }

    }
}