using System.Collections.Generic;
using System.Text;

using IISTA.RazorEnginCustom.HtmlElements;

namespace IISTA.RazorEnginCustom
{
    /// <summary>
    /// Constructor for imitating Razor page view
    /// </summary>
    public class RazorPageConstructor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RazorPageConstructor"/> class.
        /// </summary>
        public RazorPageConstructor()
        {
            this.HtmlElements = new List<HtmlTag>();
        }

        /// <summary>
        /// Gets or sets the HTML elements.
        /// </summary>
        /// <value>
        /// The HTML elements.
        /// </value>
        private IList<HtmlTag> HtmlElements { get; set; }

        /// <summary>
        /// Adds the specified tag to add.
        /// </summary>
        /// <param name="tagToAdd">The tag to the HtmlElements inside.</param>
        /// <returns>The class instance for chaining</returns>
        public RazorPageConstructor Add(HtmlTag tagToAdd)
        {
            this.HtmlElements.Add(tagToAdd);

            return this;
        }

        /// <summary>
        /// Renders this instance.
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.HtmlElements.Count; i++)
            {
                HtmlTag currentHtmlTag = this.HtmlElements[i];

                sb.Append(currentHtmlTag.Render());
            }

            return sb.ToString();
        }
    }
}
