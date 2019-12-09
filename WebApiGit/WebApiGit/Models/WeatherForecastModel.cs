using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiGit.Models
{
    public class WeatherForecastModel
    {
        public enum SummaryEnum
        {
            Freezing,
            Bracing,
            Chilly,
            Cool,
            Mild,
            Warm,
            Balmy,
            Hot,
            Sweltering,
            Scorching
        }

        [Required]
        [Key]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public double Lat { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        public double Lon { get; set; }

        [Required]
        [Display(Name = "Temperature in celsius")]
        public int TemperatureC { get; set; }

        [Required]
        [Display(Name = "Humidity")]
        public int Humidity
        {
            get; set;
        }

        [Required]
        [Display(Name = "Pressure")]
        public int Pressure { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [Required]
        [Display(Name = "Summary")]
        public SummaryEnum Summary { get; set; }
    }
}
