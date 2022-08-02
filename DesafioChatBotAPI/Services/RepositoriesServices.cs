using DesafioChatBotAPI.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace DesafioChatBotAPI.Services
{
    public class RepositoriesServices
    {
        public async Task<List<Repositories>> GetAllRepositoriesAsync()
        {
            try
            {
                List<Repositories> repositoryCollection = null;

                using (var baseHeaders = new HttpClient())
                {
                    baseHeaders.BaseAddress = new Uri(Constants.url);
                    baseHeaders.DefaultRequestHeaders.Accept.Clear();
                    baseHeaders.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.returnMediaType));
                    baseHeaders.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(Constants.productName, Constants.productVer));

                    var address = await baseHeaders.GetAsync(Constants.repositoriesAddress);

                    if (address.IsSuccessStatusCode)
                    {
                        var data = address.Content.ReadAsStringAsync();
                        repositoryCollection = JsonConvert.DeserializeObject<List<Repositories>>(data.Result);
                    }
                }

                return repositoryCollection;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string RepositoriesFilteredByLanguage(string language, int quantity)
        {
            try
            {
                var specificRepositories = GetAllRepositoriesAsync().Result.FindAll(x => x.Language == language).OrderBy(x => x.Created_At).ToList();

                List<Repositories> repositoriesList = new List<Repositories>();

                for (int i = 0; i < quantity; i++)
                {
                    repositoriesList.Add(specificRepositories[i]);
                }

                string jsonRepositories;

                using (var webClient = new WebClient())
                {
                    jsonRepositories = JsonConvert.SerializeObject(repositoriesList);

                }

                jsonRepositories = jsonRepositories.ToLower().Replace(@"\", "-");

                return jsonRepositories;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
