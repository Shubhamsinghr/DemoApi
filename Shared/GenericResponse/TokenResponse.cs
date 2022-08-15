using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.GenericResponse
{
    public class TokenResponse : CustomApiError
    {
        public string access_token { get; set; } = default!;
    }
}
