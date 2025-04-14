using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonKillerBack.Models;

public class ReviewContent
{
    [Required]
    [StringLength(40, MinimumLength = 10)]
    public string Article { get; set; }

    [Required]
    [StringLength(400, MinimumLength = 20)]
    public string Message { get; set; }
    
    [NotMapped] 
    public ICollection<IFormFile> UploadedFiles { get; set; } = new List<IFormFile>();
    
    public List<string> FilePaths { get; set; } = [];
}