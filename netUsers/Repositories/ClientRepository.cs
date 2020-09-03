using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using netUsers.Data;
using netUsers.Models;
using netUsers.ViewModels.ClientViewModels;

namespace netUsers.Repositories
{
    public class ClientRepository
    {
        private readonly StoreDataContext _context;

        public ClientRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<ListClientViewModels> Get() 
        {
            return _context.Clients
            .Include(x => x.Server)
            .Select(x => new ListClientViewModels
            {
                Id = x.Id,
                codCliente = x.codCliente,
                Nome = x.Nome,
                Login = x.Login,
                Password = x.Password,
                Email = x.Email,
                precisouAjuda = x.precisouAjuda,
                Ativo = x.Ativo,
                Migrado = x.Migrado,
                Server = x.Server.dnsNovo
            })
            .AsNoTracking()
            .ToList();
        }
        public Client Get(int id)
        {
            return _context.Clients.Find(id);
        }
        public void Save(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }
        public void Update (Client client)
        {
            _context.Entry<Client>(client).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(Client client)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }
    }
}
