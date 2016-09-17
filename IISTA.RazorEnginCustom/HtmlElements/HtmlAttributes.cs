using IISTA.Common.Enums;

namespace IISTA.RazorEnginCustom.HtmlElements
{
    public class HtmlAttributes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlAttributes"/> class.
        /// </summary>
        public HtmlAttributes()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlAttributes"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public HtmlAttributes(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlAttributes"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public HtmlAttributes(string key, AttributeType value)
        {
            this.Key = key;
            this.Value = value.ToString();
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }
        
        public override string ToString()
        {
            return this.Key + @"=" + "\"" +  this.Value + "\"";
        }
    }
}
