using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BlogEngine.Domain.Core;

namespace BlogEngine.Domain.Common.ValueObjects
{
    public sealed record HashTag(string Id) : ValueObject
    {
        private const string RegexPattern = @"#(\w+)";

        public static IEnumerable<HashTag> Parse(string input)
        {
            return Regex.Matches(input, RegexPattern)
                .Select(m => new HashTag(m.Groups[1].Value));
        }
    }
}