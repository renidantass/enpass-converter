using System;
using System.Diagnostics;
using parser_enpass_passwords.Models;
using parser_enpass_passwords.Services;

namespace parser_enpass_passwords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToJson = string.Empty, pathToCsv = string.Empty;


            if (Debugger.IsAttached)
            {
                pathToJson = @"C:\Users\Reni Alkimim\Desktop\pm_export.json";
                pathToCsv = @"C:\Users\Reni Alkimim\Desktop\dados.csv";
            } else
            {
                if (args.Length < 2)
                {
                    throw new ArgumentException("É necessário informar o arquivo de origem e de destino");
                }

                pathToJson = args[0];
                pathToCsv = args[1];
            }

            EnpassParser enpassParser = new EnpassParser(pathToJson);
            string content = enpassParser.Read();
            ChromePasswords chromePasswords = enpassParser.Parse(content);
            chromePasswords.Save(pathToCsv);
        }
    }
}
