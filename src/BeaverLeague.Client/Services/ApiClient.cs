using BeaverLeague.Core.Models;
using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BeaverLeague.Client.Services
{
    public class ApiClient
    {
        public ApiClient(HttpClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<Golfer[]> GetAllGolfers()
        {
            return await Client.GetJsonAsync<Golfer[]>("/api/golfers");
        }

        public HttpClient Client { get; }
    }
}
