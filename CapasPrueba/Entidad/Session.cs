namespace Entidad
{
    public class Session
    {
        private static string token_type;
        private static int expires_in;
        private static string access_token;
        private static string refresh_token;

        public string Token_type { get => token_type; set => token_type = value; }
        public int Expires_in { get => expires_in; set => expires_in = value; }
        public string Access_token { get => access_token; set => access_token = value; }
        public string Refresh_token { get => refresh_token; set => refresh_token = value; }
    }
}
