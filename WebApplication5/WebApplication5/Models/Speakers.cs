using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Speakers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile ImgFile { get; set; }
    }
}
