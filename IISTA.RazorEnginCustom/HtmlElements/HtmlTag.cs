using System;
using System.Collections.Generic;

using IISTA.Common.Contracts;
using IISTA.Common.Enums;

namespace IISTA.RazorEnginCustom.HtmlElements
{
    /// <summary>
    /// Html Tag
    /// </summary>
    /// <seealso cref="IISTA.Common.Contracts.IRenderable" />
    /// <seealso cref="IISTA.Common.Contracts.ITag" />
    public class HtmlTag : IRenderable, ITag
    {
        private string tagTemplate = "<{0} {2}>{1}</{0}>";
        private string tagTemplateSingle = "<{0} {2}/>";
        private TagType tagType;
        private string text = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlTag"/> class.
        /// </summary>
        public HtmlTag()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlTag"/> class.
        /// </summary>
        /// <param name="tagType">Type of the tag.</param>
        public HtmlTag(TagType tagType)
        {
            this.tagType = tagType;
            this.Attributes = new List<string>();
        }

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        public IList<string> Attributes { get; set; }

        /// <summary>
        /// Specifies the text inside.
        /// </summary>
        /// <param name="inside">The inside.</param>
        /// <returns>The Html Tag class</returns>
        public ITag With(string inside)
        {
            this.text += inside;

            return this;
        }

        /// <summary>
        /// Specifies the text inside.
        /// </summary>
        /// <param name="tagInside">The tag inside.</param>
        /// <returns>The Html Tag class</returns>
        /// <exception cref="System.ArgumentNullException">HTML tag is null!</exception>
        public ITag With(ITag tagInside)
        {
            if (tagInside == null)
            {
                throw new ArgumentNullException("HTML tag is null!");
            }
            
            this.text += tagInside.Render();

            return this;
        }

        /// <summary>
        /// Renders this HtmlTag.
        /// </summary>
        /// <returns>Returns a string</returns>
        public string Render()
        {
            string currentTemplate;

            switch (this.tagType)
            {
                case TagType.Input:
                    currentTemplate = this.tagTemplateSingle;
                    break;
                case TagType.Br:
                    currentTemplate = this.tagTemplateSingle;
                    break;
                default:
                    currentTemplate = this.tagTemplate;
                    break;
            }

            return string.Format(
                currentTemplate,
                this.tagType,
                this.text,
                string.Join(" ", this.Attributes));
        }

        /// <summary>
        /// Adds the attribute to the Html attributes collection.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Sorry, the attribute is null</exception>
        public HtmlTag AddAttribute(HtmlAttributes attribute)
        {
            if (attribute == null)
            {
                throw new ArgumentNullException("Sorry, the attribute is null");
            }

            this.Attributes.Add(attribute.ToString());

            return this;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Render();
        }
    }
}
