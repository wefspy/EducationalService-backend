using System.ComponentModel.DataAnnotations;

namespace EducationalWebService.Logic.DTO.Topic;

public class TopicDTO
{
    [Required]
    public Guid TopicID { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public int Round { get; set; }
}
