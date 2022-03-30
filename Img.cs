using System.ComponentModel.DataAnnotations;

namespace CanonImgApi
{
    public class Img
    {
        public int Id { get; set; }
        
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;
    }
}
