using IISTA.Common;
using IISTA.Common.Contracts;
using IISTA.Common.Enums;
using IISTA.RazorEnginCustom;
using IISTA.RazorEnginCustom.HtmlElements;

namespace IISTA.RazorViewsCustom
{
    public class HomePageView : BasePageView, IRenderable
    {
        public HomePageView(IHttpRequest httpRequestCustom)
            : base(httpRequestCustom)
        {
        }

        /// <summary>
        /// Renders this instance.
        /// </summary>
        /// <returns></returns>
        public override string Render()
        {
            HtmlTag htmlTag = new HtmlTag(TagType.Html);
            htmlTag
                .With(new HtmlTag(TagType.Body)
                    .With(new HtmlTag(TagType.Form)
                        .AddAttribute(new HtmlAttributes(Constants.Action, Constants.Search + "\\" + Constants.Search))
                        .With("Enter a city")
                        .With(new HtmlTag(TagType.Input)
                            .AddAttribute(new HtmlAttributes(Constants.Type, AttributeType.text))
                            .AddAttribute(new HtmlAttributes(Constants.Name, Constants.City))
                            .AddAttribute(new HtmlAttributes(Constants.Placeholder, Constants.City)))
                        .With(new HtmlTag(TagType.Input)
                            .AddAttribute(new HtmlAttributes(Constants.Type, AttributeType.submit))
                            .AddAttribute(new HtmlAttributes(Constants.Value, Constants.Search)))));
            
            return new RazorPageConstructor()
                    .Add(htmlTag)
                    .Render();
        }
    }
}
