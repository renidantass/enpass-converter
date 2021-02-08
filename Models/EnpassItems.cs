using System.Collections.Generic;

namespace parser_enpass_passwords.Models
{
    public class EnpassItems
    {
        public List<EnpassItem> Items { get; set; }

        public static implicit operator ChromePasswords(EnpassItems enpassItems) {
            ChromePasswords chromePasswords = new ChromePasswords();

            foreach (EnpassItem item in enpassItems.Items) {

                string username = item.fields[0].value;
                string password = item.fields[2].value;
                string url = item.fields[3].value;

                ChromePassword chromePassword = new ChromePassword(item.title, url, username, password);
                chromePasswords.Add(chromePassword);
            }

            return chromePasswords;
        }
    }
}