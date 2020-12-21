namespace Entidad
{
    public class Auth
    {


        public int client_id { get; }

        public string client_secret { get; }
        public string grant_type { get; }
        public string username { get; }
        public string password { get; }

        public Auth(string username = "", string password = "")
        {
            client_id = 1;
            client_secret = "bBv3eJYSQ2TMfVlnXWedL36KXIMfyEnLSTD30quq";
            this.grant_type = "password";
            this.username = username;
            this.password = password;

        }

    }
}
