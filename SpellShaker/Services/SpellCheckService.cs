using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SpellChecker.Models.SpellCheck;
using SpellChecker.Models.SpellCheck.ErrorResponse;
using SpellChecker.Startup;

namespace SpellChecker.Services
{
    public class SpellCheckService : ISpellCheckService
    {
        private readonly string _host;
        private readonly string _path;
        private readonly string _params;
        private readonly string _key;

        public SpellCheckService(IOptions<BingSpellCheckApiOptions> options)
        {
            _host = options.Value.Host;
            _path = options.Value.Path;
            _params = options.Value.Params;
            _key = options.Value.Key;
        }

        public async Task<SpellCheckDto> SpellCheck(string text)
        {
            var contentString = await SetUpConnectionAndGetResponse(text);

            var dto = new SpellCheckDto
            {
                Input = text
            };

            var spellCheck = JsonConvert.DeserializeObject<SpellCheck>(contentString);

            if (string.IsNullOrWhiteSpace(spellCheck._type))
            {
                var errorResponse = JsonConvert.DeserializeObject<Error>(contentString);
                dto.ErrorResponse.Errors.Add(errorResponse);
            }
            else
            {
                dto.SpellCheck = spellCheck;
                dto.Correct();
            }

            return dto;
        }

        private async Task<string> SetUpConnectionAndGetResponse(string text)
        {
            HttpResponseMessage response;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _key);
            var uri = _host + _path + _params;
            var values = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("text", text) };

            using (var content = new FormUrlEncodedContent(values))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                response = await client.PostAsync(uri, content);
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}