using System.ComponentModel.DataAnnotations;

namespace FolderTestApp.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Path { get; set; }
    }
}
