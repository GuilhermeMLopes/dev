using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using netUsers.Models;
using netUsers.Repositories;
using netUsers.ViewModels.ClientViewModels;
using NetUsers.ViewModels.ClientViewModels;

namespace netUsers.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientRepository _repository;

        public ClientController(ClientRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/clients")]
        [HttpGet]
        public IEnumerable<ListClientViewModels> Get()
        {
            return _repository.Get();
        }

        [Route("v1/clients/{id}")]
        [HttpGet]
        public Client Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1/clients")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorClientViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o cliente",
                    Data = model.Notifications
                };

            var client = new Client();
            client.codCliente = model.codCliente;
            client.Nome = model.Nome;
            client.Login = model.Login;
            client.Password = model.Password;
            client.Email = model.Email;
            client.precisouAjuda = model.precisouAjuda;
            client.Ativo = model.Ativo;
            client.Migrado = model.Migrado;
            client.ServerId = model.ServerId;
            client.LastUpdateDate = DateTime.Now;
            client.CreateDate = DateTime.Now;
            

            _repository.Save(client);
            
            return new ResultViewModel
                {
                    Success = true,
                    Message = "Cliente cadastrado com sucesso!",
                    Data = client
                };
        }

        [Route("v1/clients")]
        [HttpPut]
        public ResultViewModel Put([FromBody]EditorClientViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o cliente",
                    Data = model.Notifications
                };

            var client = _repository.Get(model.Id);
            client.codCliente = model.codCliente;
            client.Nome = model.Nome;
            client.Login = model.Login;
            client.Password = model.Password;
            client.Email = model.Email;
            client.precisouAjuda = model.precisouAjuda;
            client.Ativo = model.Ativo;
            client.Migrado = model.Migrado;
            client.ServerId = model.ServerId;
            client.LastUpdateDate = DateTime.Now;

            _repository.Update(client);

            return new ResultViewModel
                {
                    Success = true,
                    Message = "Cliente alterado com sucesso!",
                    Data = client
                };
        }

        [Route("v1/clients")]
        [HttpDelete]
        public ResultViewModel Delete([FromBody]EditorClientViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível remover o cliente",
                    Data = model.Notifications
                };

            var client = _repository.Get(model.Id);

            _repository.Delete(client);

            return new ResultViewModel
                {
                    Success = true,
                    Message = "Cliente removido com sucesso!",
                    Data = client
                };
        }
    }
}