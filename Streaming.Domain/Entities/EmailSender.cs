namespace Streaming.Domain.Entities
{
    public class EmailSender
    {
        public EmailSender(int idEmailSender, string email, string password, string smtp, short port, bool ssl)
        {
            IdEmailSender = idEmailSender;
            Email = email;
            Password = password;
            Smtp = smtp;
            Port = port;
            Ssl = ssl;
        }

        public int IdEmailSender { get; set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Smtp { get; private set; }
        public short Port { get; private set; }
        public bool Ssl { get; private set; }
    }
}
