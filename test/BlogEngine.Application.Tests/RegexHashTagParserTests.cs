using System.Linq;
using BlogEngine.Application.Services;
using Xunit;

namespace BlogEngine.Application.Tests
{
    public sealed class RegexHashTagParserTests
    {
        private static RegexHashTagParser HashTagParser => new RegexHashTagParser();

        [Fact]
        public void ParseMultiple()
        {
            const string text = "This text contains #Multiple #HashTags!.";

            var hashTags = HashTagParser.Parse(text).ToArray();
            var length = hashTags.Length;

            Assert.Equal(2, length);
            Assert.Equal("Multiple", hashTags[0]);
            Assert.Equal("HashTags", hashTags[1]);
        }

        [Fact]
        public void ParseNone()
        {
            const string text = "This text does not contain any HashTags.";

            var hashTags = HashTagParser.Parse(text).ToArray();
            var length = hashTags.Length;

            Assert.Equal(0, length);
        }

        [Fact]
        public void ParseSingle()
        {
            const string text = "This text contains a #Single HashTag.";

            var hashTags = HashTagParser.Parse(text).ToArray();
            var length = hashTags.Length;

            Assert.Equal(1, length);
            Assert.Equal("Single", hashTags[0]);
        }
    }
}