using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artificial_intelligence_games.TwoPerson;
using Artificial_intelligence_games.TwoPerson.Searchers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Artificial_intelligence_games.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwoPersonController : ControllerBase
    {
        [HttpPost("mini-max")]
        public Point NextStepMinMax(BoardInput board)
        {
            MiniMaxSearch search = new MiniMaxSearch(5);
            return search.NextStep(new State(board.Board)).Place;
        }

        [HttpPost("nega-max")]
        public Point NextStepNegaMax(BoardInput board)
        {
            NegaMaxSearch search = new NegaMaxSearch(5);
            return search.NextStep(new State(board.Board)).Place;
        }
    }
}
