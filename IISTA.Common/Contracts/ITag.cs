namespace IISTA.Common.Contracts
{
    public interface ITag
    {
        /// <summary>
        /// Specifies the element inside.
        /// </summary>
        /// <param name="inside">The inside of the HtmlTag.</param>
        ITag With(string inside);

        /// <summary>
        /// Specifies the element inside.
        /// </summary>
        /// <param name="inside">The inside of the HtmlTag.</param>
        ITag With(ITag inside);

        /// <summary>
        /// Renders this instance.
        /// </summary>
        /// <returns></returns>
        string Render();
    }
}
