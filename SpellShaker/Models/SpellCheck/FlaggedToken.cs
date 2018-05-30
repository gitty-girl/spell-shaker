using System.Collections.Generic;

namespace SpellChecker.Models.SpellCheck
{
    public class FlaggedToken
    {
        public int Offset { get; set; }

        public List<TokenSuggestion> Suggestions { get; set; }

        public string Token { get; set; }

        public string Type { get; set; }
    }
}