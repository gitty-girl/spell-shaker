using System.Collections.Generic;

namespace SpellChecker.Models.SpellCheck.ErrorResponse
{
    public class ErrorResponse
    {
        public string _type { get; set; }

        public List<Error> Errors { get; set; } = new List<Error>();
    }
}