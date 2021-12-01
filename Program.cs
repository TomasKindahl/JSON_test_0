using System;
using System.IO;
using System.Text.Json;

// Source: https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-6-0

namespace JSON_test_0
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /******************************/
            /**** Generate a JSON file ****/
            /******************************/
            WeatherForecast weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(weatherForecast, options);
            string fileName = "WeatherForecast.json";
            File.WriteAllText(fileName, jsonString);

            Console.WriteLine(jsonString);

            /**************************/
            /**** Read a JSON file ****/
            /**************************/
            using(StreamReader reader = new StreamReader("WeatherForecast.json"))
            {
                string forecastString = reader.ReadToEnd();
                WeatherForecast forecast = JsonSerializer.Deserialize<WeatherForecast>(forecastString);
                Console.WriteLine($"Date: {forecast.Date}");
                Console.WriteLine($"TemperatureCelsius: {forecast.TemperatureCelsius}");
                Console.WriteLine($"Summary: {forecast.Summary}");
            }
        }
    }
}
