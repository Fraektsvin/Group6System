﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseTier.Models
{
    public class User
    {
        [Required, Key]
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
        
        public override string ToString()
        {
            return "User{" +
                   "username=" + Username +
                   "password=" + Password +
                   '}';
        }
    }
}