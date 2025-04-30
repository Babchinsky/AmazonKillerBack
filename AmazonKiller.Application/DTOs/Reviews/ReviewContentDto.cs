namespace AmazonKiller.Application.DTOs.Reviews;

public class ReviewContentDto
{
    public string Article { get; set; }
    public string Message { get; set; }
    public List<string> FilePaths { get; set; }
}