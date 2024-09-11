using Bootcamp.Data.Interface;
using Bootcamp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace Bootcamp.Data.Services
{

    public class AuthUser : IAuthUser
    {

        private readonly string _jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "C:\\Users\\divyansh.jain\\Code\\NVProject\\DotNet\\Bootcamp.Data\\Data", "userList.json");
        private readonly string _jsonFilePathRegister = Path.Combine(Directory.GetCurrentDirectory(), "C:\\Users\\divyansh.jain\\Code\\NVProject\\DotNet\\Bootcamp.Data\\Data", "RegisterUser.json");



        // Helper method to read JSON data from file frpm register json
        private List<Users> ReadProductsFromFile()
        {
            if (!System.IO.File.Exists(_jsonFilePathRegister))
            {
                Console.WriteLine("File not found.");
                return new List<Users>();
            }

            try
            {
                var jsonData = System.IO.File.ReadAllText(_jsonFilePathRegister);
                Console.WriteLine($"JSON Data: {jsonData}");  // Log the raw JSON data

                return JsonSerializer.Deserialize<List<Users>>(jsonData) ?? new List<Users>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                return new List<Users>();
            }
        }

        public void SaveData(List<Users> data)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true // This makes the output JSON indented
            };

            var jsonData = JsonSerializer.Serialize(data, options);
            File.WriteAllText(_jsonFilePathRegister, jsonData);
        }


        public List<Users> GetAuthUsers()
        {
            if (!System.IO.File.Exists(_jsonFilePath))
            {
                Console.WriteLine("File not found.");
                return new List<Users>();
            }

            try
            {
                var jsonData = System.IO.File.ReadAllText(_jsonFilePath);
                Console.WriteLine($"JSON Data: {jsonData}");  // Log the raw JSON data

                return JsonSerializer.Deserialize<List<Users>>(jsonData) ?? new List<Users>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                return new List<Users>();
            }
        }

        public async Task<Users> GetLogInUserName(string UserName)
        {
            var userList = ReadProductsFromFile();
            // Filter the user by name (case-insensitive)
            var user = userList.FirstOrDefault(p => p.UserName.ToLower() == UserName?.ToLower());
            if (user == null)
            {
                // Returning null if the user is not found
                return null;
            }
            return user;
        }

        public async Task<Users> GetLogInUserName(string UserName, string Password)
        {
            var userList = new Users();
            return userList;
        }


        public void AddData(Users user)
        {
            var data = ReadProductsFromFile();

            // Generate new Id
            user.Id = data.Any() ? data.Max(x => x.Id) + 1 : 1;

            data.Add(user);
            SaveData(data);
        }
    }
}
