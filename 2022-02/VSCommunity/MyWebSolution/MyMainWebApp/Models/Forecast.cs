using System;

namespace MyMainWebApp.Models
{
    [Serializable]
    public class Forecast
    {
        public string Location { get; set; }
        public string Label { get; set; }
        public decimal TempC { get; set; }
    }
}
