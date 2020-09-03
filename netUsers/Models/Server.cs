using System;
using System.Collections.Generic;

namespace netUsers.Models
{
    public class Server
    {
        public int Id { get; set; }
        public string dnsAntigo { get; set; }
        public string dnsNovo { get; set; }
        public DateTime dataMigracao{ get; set; }
        public DateTime CreateDate { get; set; }
        public IEnumerable<Client> Client { get; set; }
    }
}