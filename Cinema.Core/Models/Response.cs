using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Core.Models
{
    public class ResponseToken
    {
        public string JwtToken { get; set; }
        public string Error { get; set; }
        public int Code { get; set; }

        public ResponseToken(string token)
        {
            JwtToken = token;
            Code = 200;
        }

        public ResponseToken(int code, string error)
        {
            Code = code;
            Error = error;
        }

        public bool Succeeded()
        {
            return Code == 200 && Error == null;
        }
    }
}
