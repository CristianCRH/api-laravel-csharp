using Entidad;

namespace Datos
{
    public class Token
    {
        public bool GetToken()
        {
            var token = new APIHelper<Entidad.Token>();
            var client = token.Client("/oauth/token");
            Auth auth = new Auth("cristian@gmail.com", "123123");
            var request = token.Request(auth, "POST");
            var respose = token.Response(client, request);
            Entidad.Token content = token.Content<Entidad.Token>(respose);

            if (content.access_token != ""&& content.access_token!=null)
            {
                new Session()
                {
                    Token_type = content.token_type,
                    Expires_in = content.expires_in,
                    Access_token = content.access_token,
                    Refresh_token = content.refresh_token
                };
                return true;
            }

            return false;

        }
    }
}
