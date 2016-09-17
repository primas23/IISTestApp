using IISTA.Common.Contracts;
using IISTA.RazorEnginCustom;

namespace IISTA.RazorViewsCustom
{
    public abstract class BasePageView
    {
        internal IHttpRequest _httpRequestCustom = null;

        public BasePageView(IHttpRequest httpRequestCustom)
        {
            this._httpRequestCustom = httpRequestCustom;
        }

        public virtual string Render(){

            RazorPageConstructor razor = new RazorPageConstructor();

            return razor.Render();
        }
    }
}
