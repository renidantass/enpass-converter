using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace parser_enpass_passwords.Models
{
    public class ChromePasswords
    {

        public List<ChromePassword> Passwords { get;set; }

        public ChromePasswords()
        {
            Passwords = new List<ChromePassword>();
        }   

        public void Add(ChromePassword chromePassword) {
            Passwords.Add(chromePassword);
        }

        public bool Save(string filename) {

            if (string.IsNullOrEmpty(filename)) {
                throw new ArgumentException("Filename deve estar preenchido");
            }

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            using(FileStream fs = new FileStream(filename, FileMode.CreateNew)) {
                string header, line;
                
                header = "name,url,username,password\n";
                fs.Write(Encoding.UTF8.GetBytes(header));

                foreach (ChromePassword password in Passwords) {
                    line = password.ToString();
                    fs.Write(Encoding.UTF8.GetBytes(line));
                }
            }

            return File.Exists(filename);
        }
    }
}