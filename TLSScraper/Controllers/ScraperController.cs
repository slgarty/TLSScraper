using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLSScraper.Data;

namespace TLSScraper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        [Route("scrape")]
        public List<TLSResult> Scrape(string query)
        {
            return Scraper.ScrapeTLS(query);
        }
    }
}
