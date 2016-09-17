namespace IISTA.Common.Contracts
{
    public interface IWebVerb
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        string Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this WebVerb is get.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is get; otherwise, <c>false</c>.
        /// </value>
        bool IsGet { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this WebVerb is post.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is post; otherwise, <c>false</c>.
        /// </value>
        bool IsPost { get; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents the value of the verb.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        string ToString();
    }
}
