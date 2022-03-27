// See https://aka.ms/new-console-template for more information

using ConfigurationGetter;
using Microsoft.Extensions.Configuration;

var conf = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Development.json")
    .Build();

var confString = conf.GenerateConfigurationString(5);

Console.WriteLine(confString);
