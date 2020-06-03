using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artificial_intelligence_games.OnePerson.Searchers
{
    public class WidthSearch : AbstractSearch
    {
        public override List<Operator> Search()
        {
            Queue<Node> open = new Queue<Node>();
            List<Node> closed = new List<Node>();

            open.Enqueue(new Node(new State(), null));
            while (open.Count > 0 && !open.Peek().State.IsEndState)
            {
                Node node = open.Dequeue();

                List<Operator> operators = node.State.GetValidOperators();

                for (int i = 0; i < operators.Count; i++)
                {
                    Node newNode = new Node(new State(node.State), node);
                    newNode.State.Move(operators[i]);
                    newNode.Operator = operators[i];
                    if (!open.Contains(newNode) && !closed.Contains(newNode))
                    {
                        open.Enqueue(newNode);
                    }
                }
                closed.Add(node);
            }

            if (open.Count > 0)
            {
                return open.Peek().MovePath;
            }
            return null;
        }
    }
}
