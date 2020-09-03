namespace netUsers.ViewModels.ClientViewModels
{
    public class ListClientViewModels
    {
        public int Id { get; set; }
        public string codCliente { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool precisouAjuda { get; set; }
        public bool Ativo { get; set; }
        public bool Migrado { get; set; }
        public int ServerId { get; set; }
        public string Server { get; set; }
    }
}