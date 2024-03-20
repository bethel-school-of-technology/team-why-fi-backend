using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class Post
{
    public int PostId { get; set; }
    [Required]
    public string? locationId { get; set; }
    [Required]
    public string? Message { get; set; }
    public string? ImgUrl { get; set; }
    
}