using DesafioChatBotAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioChatBotAPI.Controllers
{
    public class RepositoriesControllers : ControllerBase
    {
        private readonly RepositoriesServices _repositoriesServices;

        public RepositoriesControllers(RepositoriesServices repositoriesService)
        {
            _repositoriesServices = repositoriesService;
        }

        [HttpGet]
        [Route("api/getrepositories")]
        public string GetRepositories()
        {
            try
            {
                return _repositoriesServices.RepositoriesFilteredByLanguage(Constants.language, Constants.repositoriesQuantity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
