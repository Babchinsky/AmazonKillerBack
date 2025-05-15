using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Domain.Entities.Reviews;

public class ReviewContent
{
    public Guid Id { get; init; }

    [Required]
    [StringLength(40, MinimumLength = 10)]
    public string Article { get; set; }

    [Required]
    [StringLength(400, MinimumLength = 20)]
    public string Message { get; set; }

    [NotMapped] public ICollection<IFormFile> UploadedFiles { get; init; } = new List<IFormFile>();

    public List<string> FilePaths { get; set; } = [];
}