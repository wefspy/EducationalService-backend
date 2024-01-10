using Microsoft.AspNetCore.Identity;

namespace EducationalWebService.Logic.DTO.User;

public record UserResponse(Guid id, string token, IEnumerable<IdentityError> ErrorMessages);