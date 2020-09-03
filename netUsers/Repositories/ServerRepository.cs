using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using netUsers.Data;
using netUsers.Models;

namespace netUsers.Repositories
{
    public class ServerRepository
    {
        private readonly StoreDataContext _context;

        public ServerRepository(StoreDataContext context)
        {
            _context = context;
        }
        public IEnumerable<Server> Get()
        {
            return _context.Servers.AsNoTracking().ToList();
        }
        public Server Get(int id)
        {
            return _context.Servers.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }
        public IEnumerable<Client> GetClients(int id)
        {
            return _context.Clients.AsNoTracking().Where(x => x.ServerId == id).ToList();
        }
        public void Save(Server server)
        {
            _context.Servers.Add(server);
            _context.SaveChanges();
        }
        public void Update(Server server)
        {
            _context.Entry<Server>(server).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(Server server)
        {
            _context.Servers.Remove(server);
            _context.SaveChanges();
        }
    }
}