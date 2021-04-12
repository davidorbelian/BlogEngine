using System.Linq;
using BlogEngine.Domain.ValueObjects;
using Xunit;

namespace BlogEngine.Domain.Tests
{
    public sealed class RegexHashTagParserTests
    {
        [Fact]
        public void ParseMultiple()
        {
            const string text = "This text contains #Multiple #HashTags!.";

            var hashTags = HashTag.Parse(text).ToArray();
            var length = hashTags.Length;

            Assert.Equal(2, length);
            Assert.Equal("Multiple", hashTags[0].Id);
            Assert.Equal("HashTags", hashTags[1].Id);
        }

        [Fact]
        public void ParseNone()
        {
            const string text = "This text does not contain any HashTags.";
            
            var hashTags = HashTag.Parse(text).ToArray();
            var length = hashTags.Length;

            Assert.Equal(0, length);
        }

        [Fact]
        public void ParseSingle()
        {
            const string text = "This text contains a #Single HashTag.";

            var hashTags = HashTag.Parse(text).ToArray();
            var length = hashTags.Length;

            Assert.Equal(1, length);
            Assert.Equal("Single", hashTags[0].Id);
        }
    }
}