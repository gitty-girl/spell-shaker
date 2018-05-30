namespace SpellChecker.Models.SpellCheck.ErrorResponse
{
    public class Error
    {
        public string StatusCode { get; set; }

        public string Message { get; set; }

        public string ModeDetails { get; set; }

        public string Parameter { get; set; }

        public string SubCode { get; set; }

        public string Value { get; set; }
    }
}