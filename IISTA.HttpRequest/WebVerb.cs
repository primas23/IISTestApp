using IISTA.Common.Contracts;
using IISTA.Common.Enums;
using IISTA.Common.ExtentionMethods;

namespace IISTA.HttpRequest
{
    /// <summary>
    /// The Web verb
    /// </summary>
    public class WebVerb : IWebVerb
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this WebVerb is get.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is get; otherwise, <c>false</c>.
        /// </value>
        public bool IsGet
        {
            get
            {
                return Value.CustomStringCompareTo(HttpVerbs.GET);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this WebVerb is post.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is post; otherwise, <c>false</c>.
        /// </value>
        public bool IsPost
        {
            get
            {
                return Value.CustomStringCompareTo(HttpVerbs.POST);
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents the value of the verb.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Value;
        }
    }
}
