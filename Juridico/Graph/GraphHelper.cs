using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Juridico.Graph;
using Microsoft.Graph.Extensions;
using Microsoft.Graph;
using System.IO;
using System.Text;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Authorization;



namespace Juridico.Graph
{
    public class GraphHelper
    {
        private static GraphServiceClient _graphClient;



        //Todos los permisos necesarios en Graph
        public readonly static string[] Scopes =
       {

          "Directory.Read.All",
          "Mail.Send",
          "People.Read",
          "User.Read.All",
          "User.Read"
        };

        public static void Initialize(GraphServiceClient graphClient)
        {
            _graphClient = graphClient;
        }

        //Datos del usuario firmado
        //graph.microsoft.com/v1.0/me/
        [Authorize]
        public static async Task<User> ConsultaUsuario()
        {

            return await _graphClient.Me.Request().GetAsync();
        }

        //Listado de usuarios 
        //graph.microsoft.com/v1.0/users
        //[Authorize]
        public static async Task<IGraphServiceUsersCollectionPage> ConsultaListaUsuarios()
        {
            return await _graphClient.Users.Request()
                .Select("id,displayName")
                .OrderBy("displayName")
                .Top(600).GetAsync();
        }

    }
}
