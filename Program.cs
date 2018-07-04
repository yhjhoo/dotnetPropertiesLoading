using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace dotnetcore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


//            readJson();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddIniFile("appsettings.ini")
                .AddIniFile("appsettings-dev.ini")
                .AddEnvironmentVariables();
            var configuration = builder.Build();
            
            Console.WriteLine(configuration["name"]);
            Console.WriteLine(configuration["section:name"]);
        }

        private static void readJson()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            Console.WriteLine($"option1 = {configuration["Option1"]}");
            Console.WriteLine($"option2 = {configuration["option2"]}");
            Console.WriteLine(
                $"suboption1 = {configuration["subsection:suboption1"]}");
            Console.WriteLine();

            Console.WriteLine("Wizards:");
            Console.Write($"{configuration["wizards:0:Name"]}, ");
            Console.WriteLine($"age {configuration["wizards:0:Age"]}");
            Console.Write($"{configuration["wizards:1:Name"]}, ");
            Console.WriteLine($"age {configuration["wizards:1:Age"]}");
            Console.WriteLine();

            Console.WriteLine("Press a key...");
            Console.ReadKey();
        }
    }
}