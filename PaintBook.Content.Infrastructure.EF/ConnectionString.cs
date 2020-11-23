
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PaintBook.Content.Infrastructure.EF
{
    public sealed class CommandsConnectionString:IConnectionString
    {
        //private readonly string Value { get; }

        private  string Value { get; }
        public static string connectionString { get;private set; }

        public CommandsConnectionString()
        {
            connectionString = GetConnectionString();
        }

        public static string GetConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration["ContentConnectionString"];
        }
        public CommandsConnectionString(string value)
        {
            Value = value;
        }
    }

    public sealed class QueriesConnectionString
    {
        public string Value { get; }

        public QueriesConnectionString(string value)
        {
            Value = value;
        }
    }
}
