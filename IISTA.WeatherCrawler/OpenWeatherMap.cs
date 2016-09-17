using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;

using Newtonsoft.Json;

using IISTA.Models.Weather;

namespace IISTA.WeatherCrawler
{
    public class OpenWeatherMap
    {
        private WeatherInformationCombined _informationCombined = null;

        public OpenWeatherMap(string city)
        {
            this._informationCombined = new WeatherInformationCombined();

            WebRequest request = WebRequest.Create(
                    "http://api.openweathermap.org/data/2.5/weather?APPID=ace78c00fca00f0a73ff1e970c2055fb&q="
                    + city.ToLower()
                    + "&units=metric");

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();

            if (dataStream != null)
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                this._informationCombined = JsonConvert.DeserializeObject<WeatherInformationCombined>(responseFromServer);


                reader.Close();
            }

            response.Close();
        }


        public WeatherInformationCombined WeatherInformationCombined
        {
            get
            {
                return this._informationCombined;
            }
        }

        public double Temperature
        {
            get
            {
                return this._informationCombined.Main.Temp;

            }
        }
    }
}
