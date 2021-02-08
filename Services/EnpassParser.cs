using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using parser_enpass_passwords.Models;

namespace parser_enpass_passwords.Services
{
    public class EnpassParser
    {
        public string Filename { get; set; }
        private List<string> Content { get;set; }

        public EnpassParser(string filename)
        {
            if (string.IsNullOrEmpty(filename)) {
                throw new ArgumentException("Filename deve estar preenchido");
            }

            Filename = filename;
            Content = new List<string>();
        }

        public string Read() {
            using (StreamReader sr = File.OpenText(Filename)) {
                string line = string.Empty;
                while ((line = sr.ReadLine()) != null) {
                    Content.Add(line);
                }
            }

            return string.Join(string.Empty, Content);
        }

        public ChromePasswords Parse(string content)
        {
            EnpassItems enpassItems = JsonConvert.DeserializeObject<EnpassItems>(content);
            return (ChromePasswords)enpassItems;
        }
    }
}