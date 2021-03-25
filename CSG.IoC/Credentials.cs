namespace CSG.IoC
{
    public class Credentials
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Credentials(string server, string database, string username, string password)
        {
            Server = server;
            Database = database;
            Username = username;
            Password = password;
        }
    }
}
