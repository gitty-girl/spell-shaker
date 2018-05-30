using System.Collections.Generic;

namespace SpellChecker.Models.SpellCheck
{
    public class SpellCheck
    {
        public string _type { get; set; }

        public List<FlaggedToken> FlaggedTokens { get; set; } = new List<FlaggedToken>();
    }
}