using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Security.Api.Interfaces
{
    public class GenerateTokenResult
    {
        public string Token { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
