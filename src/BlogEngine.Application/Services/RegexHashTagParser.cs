using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BlogEngine.Application.Abstractions;

namespace BlogEngine.Application.Services
{
    public sealed class RegexHashTagParser : IHashTagParser
    {
        private const string RegexPattern = @"#(\w+)";

        public IEnumerable<string> Parse(string text)
        {
            return Regex.Matches(text, RegexPattern)
                .Select(m => m.Groups[1].Value);
        }
    }
}