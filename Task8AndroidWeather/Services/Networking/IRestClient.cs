using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8AndroidWeather.Services.Networking
{
    public interface IRestClient
    {
        Task<string> GetAsync(string uri);
    }
}