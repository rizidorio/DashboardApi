using System;

namespace Dashboard.Domain.Models
{
    public class UserTokenModel
    {
        public string Token { get; set; }
        public Object User { get; set; }
        public DateTime Expiration { get; set; }
    }
}
