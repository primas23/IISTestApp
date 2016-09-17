using Microsoft.VisualStudio.TestTools.UnitTesting;

using IISTA.Common.Enums;
using IISTA.RazorEnginCustom;
using IISTA.RazorEnginCustom.HtmlElements;

namespace IISTA.Tests
{
    [TestClass]
    public class RazorPageConstructorTests
    {
        [TestMethod]
        public void PageConstructorShouldAddHtmlElementWhenAddValidHtmlElement()
        {
            RazorPageConstructor constructor = new RazorPageConstructor();
            HtmlTag tag = new HtmlTag(TagType.Br);

            constructor.Add(tag);

            string tagString = tag.Render();
            string constructorString = constructor.Render();

            Assert.IsTrue(constructorString.Contains(tagString));
        }

        [TestMethod]
        public void PageConstructorShouldNotRenderHtmlElementWhenNoHtmlElementIsAdded()
        {
            RazorPageConstructor constructor = new RazorPageConstructor();
            HtmlTag tag = new HtmlTag(TagType.Br);

            string tagString = tag.Render();
            string constructorString = constructor.Render();

            Assert.IsFalse(constructorString.Contains(tagString));
        }

        [TestMethod]
        public void PageConstructorShouldReturnEmptyStringWhenThereAreNoElementsToRender()
        {
            RazorPageConstructor constructor = new RazorPageConstructor();
            string constructorString = constructor.Render();

            Assert.IsTrue(string.Compare(constructorString, string.Empty) == 0);
        }

        [TestMethod]
        public void PageConstructorShouldAddHtmlElementsWhenAddValidHtmlElements()
        {
            RazorPageConstructor constructor = new RazorPageConstructor();

            HtmlTag tag1 = new HtmlTag(TagType.Input);
            constructor.Add(tag1);

            HtmlTag tag2 = new HtmlTag(TagType.Br);
            constructor.Add(tag2);

            HtmlTag tag3 = new HtmlTag(TagType.Span);
            constructor.Add(tag3);

            string tagString1 = tag1.Render();
            string tagString2 = tag2.Render();
            string tagString3 = tag3.Render();

            string constructorString = constructor.Render();

            bool shouldContainAllTags = false;

            shouldContainAllTags = constructorString.Contains(tagString1)
                                && constructorString.Contains(tagString2)
                                && constructorString.Contains(tagString3);

            Assert.IsTrue(shouldContainAllTags);
        }
    }
}
