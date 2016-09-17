using IISTA.Common.Contracts;
using IISTA.Common.Enums;
using IISTA.RazorEnginCustom;
using IISTA.RazorEnginCustom.HtmlElements;

namespace IISTA.RazorViewsCustom
{
    public class PageNotFoundPageView : BasePageView
    {
        public PageNotFoundPageView(IHttpRequest httpRequestCustom)
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
            //spantagNEw.With(this._httpRequestCustom.Path);

            HtmlTag spanTagasdsa = new HtmlTag(TagType.Span);
            spanTagasdsa.With(" but there is <strong>NO</strong> such page !");

            HtmlTag bodyTag = new HtmlTag(TagType.Body);
            bodyTag.With(spanTag.Render() + spantagNEw.Render() + spanTagasdsa.Render());

            HtmlTag htmlTag = new HtmlTag(TagType.Html);
            htmlTag.With(bodyTag.Render());

            RazorPageConstructor razor = new RazorPageConstructor();

            razor.Add(htmlTag);

            return razor.Render();
        }
    }
}
