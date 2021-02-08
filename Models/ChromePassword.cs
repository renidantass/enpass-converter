namespace parser_enpass_passwords.Models
{
    public class ChromePassword
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ChromePassword(string name, string url, string username, string password) {
            Name = name;
            Url = url;
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            return $"{Name},{Url},{Username},{Password}\n";
        }
    }
}