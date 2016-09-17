using System;
using System.Collections.Generic;

using IISTA.Common;
using IISTA.Common.Contracts;
using IISTA.Common.Enums;
using IISTA.Models.Weather;
using IISTA.RazorEnginCustom;
using IISTA.RazorEnginCustom.HtmlElements;
using IISTA.WeatherCrawler;

namespace IISTA.RazorViewsCustom
{
    public class SearchPageView : BasePageView, IRenderable
    {
        public SearchPageView(IHttpRequest httpRequestCustom)
            : base(httpRequestCustom)
        {
        }

        /// <summary>
        /// Renders this instance.
        /// </summary>
        /// <returns>The html of the instance in a string format</returns>
        /// <exception cref="ArgumentNullException">The search parameter is missing</exception>
        public override string Render()
        {
            string actionMethod = _httpRequestCustom.Path.ActionMethod;

            if (!_httpRequestCustom.Path.Parameters.ContainsKey(Constants.City))
            {
                throw new ArgumentNullException("The search parameter is missing");
            }

            var cityParam = _httpRequestCustom
                .Path
                .Parameters[Constants.City];

            OpenWeatherMap weatherMap = new OpenWeatherMap(cityParam.ToString());
            WeatherInformationCombined weatherInformation = weatherMap.WeatherInformationCombined;

            HtmlTag formTag = new HtmlTag(TagType.Form);
            formTag.Attributes.Add(new HtmlAttributes(Constants.Action, Constants.Search).ToString());
            formTag.With(
                "Enter a city"
                + new HtmlTag(TagType.Input)
                {
                    Attributes = new List<string>()
                        {
                            new HtmlAttributes(Constants.Type, AttributeType.text).ToString(),
                            new HtmlAttributes(Constants.Name, Constants.City).ToString(),
                            new HtmlAttributes(Constants.Placeholder, Constants.City).ToString()
                        }
                }
                + new HtmlTag(TagType.Input)
                {
                    Attributes = new List<string>()
                        {
                            new HtmlAttributes(Constants.Type, AttributeType.submit).ToString(),
                            new HtmlAttributes(Constants.Value, Constants.Search).ToString()
                        }
                });

            HtmlTag htmlWeaterInfo = new HtmlTag(TagType.Strong);
            htmlWeaterInfo.With(
                "The temperature in "
                + cityParam
                + " is "
                + weatherInformation.Main.Temp 
                + " degrees celsius");

            HtmlTag bodyTag = new HtmlTag(TagType.Body);
            bodyTag.With(formTag.Render() + new HtmlTag(TagType.Br) + htmlWeaterInfo.Render());

            HtmlTag htmlTag = new HtmlTag(TagType.Html);
            htmlTag.With(bodyTag);

            RazorPageConstructor razor = new RazorPageConstructor();

            razor.Add(htmlTag);

            return razor.Render();
        }
    }
}
