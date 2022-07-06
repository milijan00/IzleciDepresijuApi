﻿namespace IzleciDepresiju.Api.Core
{
    public class AppSettings
    {
        public JwtSettings JwtSettings { get; set; }
        public EmailOptions EmailOptions { get; set; }
    }

    public class EmailOptions
    {
        public string FromEmail { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
    }
}
