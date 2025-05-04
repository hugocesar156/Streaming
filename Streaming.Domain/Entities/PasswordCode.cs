using System.Net;

namespace Streaming.Domain.Entities
{
    public class PasswordCode
    {
        public PasswordCode(int idUser, string code)
        {
            IdUser = idUser;
            Code = code;
        }

        public int IdPasswordCode { get; private set; }
        public int IdUser { get; private set; }
        public string Code { get; private set; }
        public bool Verified { get; private set; }
        public DateTime CreationDate { get; private set; }
    }
}
