using System.ComponentModel.DataAnnotations;

namespace EducationalWebService.Logic.DTO.Topic;

public class TopicUpdateRequest
{
    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public int Round { get; set; }
}
