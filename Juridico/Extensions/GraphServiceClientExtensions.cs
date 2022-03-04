using System.Collections.Generic;
using System.Linq;
using Microsoft.Graph;

namespace Juridico.Extensions
{
    public static class GraphServiceClientExtensions
    {
        public static string GetUserDisplayName(this GraphServiceClient graphServiceClient, string userId)
        {
            var displayName = graphServiceClient.Users[userId].Request().GetAsync().Result.DisplayName;
            return displayName;
        }

        public static List<User> GetUserList(this GraphServiceClient graphServiceClient)
        {
            var users = graphServiceClient.Users.Request().Select(u => new
            {
                u.Id,
                u.DisplayName,
                u.Mail
            }).OrderBy("displayName").Top(999).GetAsync().Result.ToList();
            return users;
        }

        
    }
}