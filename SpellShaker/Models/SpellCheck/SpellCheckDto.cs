using System.Linq;
using static System.String;

namespace SpellChecker.Models.SpellCheck
{
    public class SpellCheckDto
    {
        public string Input { get; set; }

        public string CorrectedInput { get; set; }

        public SpellCheck SpellCheck { get; set; } = new SpellCheck();

        public ErrorResponse.ErrorResponse ErrorResponse { get; set; } = new ErrorResponse.ErrorResponse();

        public string FormatScoreToPercent(double score) =>
            Format("{0:P2}", score);

        public void Correct()
        {
            var correctedInput = Input;

            foreach (var flaggedToken in SpellCheck.FlaggedTokens)
            {
                correctedInput =
                    correctedInput.Replace(flaggedToken.Token, flaggedToken.Suggestions.First().Suggestion);
            }

            CorrectedInput = correctedInput;
        }
    }
}