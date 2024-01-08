using System.ComponentModel.DataAnnotations;

namespace EducationalWebService.Logic.DTO.Topic;

public class TopicDTO : TopicRequest
{
    [Required]
    public Guid TopicID { get; set; }
}
