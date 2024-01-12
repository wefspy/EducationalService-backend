using EducationalWebService.Data.Models;

namespace EducationalWebService.Data.Context;

public static class SignalRContext
{
    public static readonly Dictionary<string, HubSession> Hubs = new Dictionary<string, HubSession>();
}
