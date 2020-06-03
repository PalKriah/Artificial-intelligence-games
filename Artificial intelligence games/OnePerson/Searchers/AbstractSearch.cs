using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artificial_intelligence_games.OnePerson.Searchers
{
    abstract public class AbstractSearch
    {
        public abstract List<Operator> Search();
    }
}
