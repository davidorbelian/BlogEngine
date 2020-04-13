using System.Collections.Generic;

namespace BlogEngine.Application.Abstractions
{
    public interface IHashTagParser
    {
        IEnumerable<string> Parse(string text);
    }
}