using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name="Product Category")]
        public string Name { get; set; }

    }
}