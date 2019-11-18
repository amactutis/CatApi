using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly ILogger<CatController> logger;

        public CatController(ILogger<CatController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization
                    = new System.Net.Http.Headers.AuthenticationHeaderValue("x-api-key", "8dff2456-79f1-433b-bc26-ee4d5a4df877");


            var breedResponse = await httpClient.GetAsync("https://api.thecatapi.com/v1/breeds");
            var breedInfo = breedResponse.Content.ReadAsStringAsync();

            return Ok(breedInfo);

        }
    }
}