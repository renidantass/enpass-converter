namespace parser_enpass_passwords.Models
{
    public class EnpassField
    {
        public string label { get; set; }
        public int order { get; set; }
        public int sensitive { get; set; }
        public string type { get; set; }
        public int uid { get; set; }
        public long updated_at { get; set; }
        public string value { get; set; }
        public long value_updated_at { get; set; }
    }
}