using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.Graph;

namespace Juridico.Graph
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
            var userList = graphServiceClient.Users.Request().Select(u => new
            {
                u.Id,
                u.DisplayName,
                u.Mail
            }).OrderBy("displayName").Top(999).GetAsync().Result.ToList();
            return userList;
        }

        public static string GetUserMail(this GraphServiceClient graphServiceClient, string userId)
        {
            var user = graphServiceClient.Users[userId].Request().GetAsync().Result;
            var mail = user.Mail ?? user.DisplayName;
            return mail;
        }

        public static string GetRoleValue(this ClaimsPrincipal user)
        {
            var role = user.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Role))?.Value;
            return role;
        }


    }
}
