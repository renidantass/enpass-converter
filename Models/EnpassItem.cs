using System.Collections.Generic;

namespace parser_enpass_passwords.Models
{
    public class EnpassItem
    {
        public int auto_submit { get; set; }
        public string category { get; set; }
        public int favorite { get; set; }
        public List<EnpassField> fields { get; set; }
        public string title { get; set; }
    }
}