using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Artificial_intelligence_games.OnePerson;
using Artificial_intelligence_games.OnePerson.Searchers;

namespace Artificial_intelligence_games.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnePersonController : ControllerBase
    {
        [HttpGet("random")]
        public IEnumerable<Operator> GetRandom()
        {
            AbstractSearch searcher = new RandomSearch();
            return searcher.Search();
        }

        [HttpGet("backtrack")]
        public IEnumerable<Operator> GetBacktrack()
        {
            AbstractSearch searcher = new Backtrack(30);
            return searcher.Search();
        }

        [HttpGet("ag-es-korlat")]
        public IEnumerable<Operator> GetAgEsKorlat()
        {
            AbstractSearch searcher = new AgEsKorlat(30);
            return searcher.Search();
        }

        [HttpGet("width")]
        public IEnumerable<Operator> GetWidth()
        {
            AbstractSearch searcher = new WidthSearch();
            return searcher.Search();
        }

        [HttpGet("depth")]
        public IEnumerable<Operator> GetDepth()
        {
            AbstractSearch searcher = new DepthSearch();
            return searcher.Search();
        }

        [HttpGet("optimal")]
        public IEnumerable<Operator> GetOptimal()
        {
            AbstractSearch searcher = new OptimalSearch();
            return searcher.Search();
        }

        [HttpGet("best-first")]
        public IEnumerable<Operator> GetBestFirst()
        {
            AbstractSearch searcher = new BestFirstSearch();
            return searcher.Search();
        }

        [HttpGet("a-algorithm")]
        public IEnumerable<Operator> GetAalgorithm()
        {
            AbstractSearch searcher = new Aalgorithm();
            return searcher.Search();
        }
    }
}