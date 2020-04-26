using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SportsStore.Domain
{
    public class DataBaseConfigurationBuilder
    {
        public static IConfiguration GetConfiguration() {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("db-settings.json");
            return builder.Build();
        }
    }
}
