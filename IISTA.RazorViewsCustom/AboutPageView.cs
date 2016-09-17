using IISTA.Common.Contracts;
using IISTA.Common.Enums;
using IISTA.RazorEnginCustom;
using IISTA.RazorEnginCustom.HtmlElements;

namespace IISTA.RazorViewsCustom
{
    public class AboutPageView : BasePageView
    {
        public AboutPageView(IHttpRequest httpRequestCustom)
            : base(httpRequestCustom)
        {
        }

        /// <summary>
        /// Renders this instance.
        /// </summary>
        /// <returns></returns>
        public override string Render()
        {
            HtmlTag spanTag = new HtmlTag(TagType.Span);
            spanTag.With("Hello you requested ");

            HtmlTag spantagNEw = new HtmlTag(TagType.Strong);

            HtmlTag spanTagasdsa = new HtmlTag(TagType.Span);
            spanTagasdsa.With(" using verb ");

            HtmlTag spanTagasdsaasdasd = new HtmlTag(TagType.Strong);
            spanTagasdsaasdasd.With(this._httpRequestCustom.Verb.Value);

            HtmlTag bodyTag = new HtmlTag(TagType.Body);
            bodyTag.With(spanTag.Render() + spantagNEw.Render() + spanTagasdsa.Render() + spanTagasdsaasdasd.Render());

            HtmlTag htmlTag = new HtmlTag(TagType.Html);
            htmlTag.With(bodyTag.Render());
            
            RazorPageConstructor razor = new RazorPageConstructor();
            
            razor.Add(htmlTag);

            return razor.Render();
        }
    }
}
