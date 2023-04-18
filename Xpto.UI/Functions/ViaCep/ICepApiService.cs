using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.UI.Functions.ViaCep
{
    interface ICepApiService
    {
        [Get("/ws/{zipCode}/json")]

        Task<WebResponse> GetAddressAsync(string zipCode);


    }
}
