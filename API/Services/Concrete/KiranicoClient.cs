using System.Net.Http;
using System.Threading.Tasks;
using API.DTOs;
using API.Exceptions.Concrete;
using API.Services.Abstract;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace API.Services.Concrete
{
    public class KiranicoClient :IKiranicoClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<KiranicoClient> _logger;
        
        public KiranicoClient(IHttpClientFactory httpClientFactory, ILogger<KiranicoClient> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        
        public async Task<MonsterDto> GetMonster(int id)
        {
            using HttpClient httpClient = _httpClientFactory.CreateClient();
            
            HttpResponseMessage httpResponseMessage = await  httpClient.GetAsync($"https://mhw-db.com/monsters/{id.ToString()}");
            
            _logger.Log(LogLevel.Information,$"StatusCode {httpResponseMessage.StatusCode}");
            
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new DataNotFoundException((int)httpResponseMessage.StatusCode);
            }

            string content = await httpResponseMessage.Content.ReadAsStringAsync();

            MonsterDto data = JsonConvert.DeserializeObject<MonsterDto>(content);

            return data;
        }
    }
}