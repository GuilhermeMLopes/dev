using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using netUsers.Models;
using netUsers.Repositories;

namespace netUsers.Controllers
{
    public class ServerController : Controller
    {
        private readonly ServerRepository _repository;

        public ServerController(ServerRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/servers")]
        [HttpGet]
        public IEnumerable<Server> Get()
        {
            return _repository.Get();
        }

        [Route("v1/servers/{id}")]
        [HttpGet]
        public Server Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1/servers/{id}/clients")]
        [HttpGet]

        public IEnumerable<Client> GetClients(int id)
        {
            return _repository.GetClients(id);
        }

        [Route("v1/servers")]
        [HttpPost]
        public Server Post([FromBody]Server server)
        {
            _repository.Save(server);
            
            return server;
        }

        [Route("v1/servers")]
        [HttpPut]
        public Server Put([FromBody]Server server)
        {
            _repository.Update(server);

            return server;
        }

        [Route("v1/servers")]
        [HttpDelete]
        public Server Delete([FromBody]Server server)
        {
            _repository.Delete(server);

            return server;
        }
    }
}