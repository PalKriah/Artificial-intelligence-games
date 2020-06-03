using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artificial_intelligence_games.OnePerson.Searchers
{
    public class RandomSearch : AbstractSearch
    {
        public override List<Operator> Search()
        {
            Random rnd = new Random();
            Node node = new Node(new State());

            do
            {
                node = new Node(new State(node.State), node);

                List<Operator> operators = node.State.GetValidOperators();
                node.Operator = operators[rnd.Next(0, operators.Count)];

                node.State.Move(node.Operator);
            } while (!node.State.IsEndState);

            return node.MovePath;
        }
    }
}
