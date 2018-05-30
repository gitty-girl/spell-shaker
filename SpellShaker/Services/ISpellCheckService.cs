using System.Threading.Tasks;
using SpellChecker.Models.SpellCheck;

namespace SpellChecker.Services
{
    public interface ISpellCheckService
    {
        Task<SpellCheckDto> SpellCheck(string text);
    }
}