using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artificial_intelligence_games.OnePerson.Searchers
{
    public class DepthSearch : AbstractSearch
    {
        public override List<Operator> Search()
        {
            Stack<Node> open = new Stack<Node>();
            List<Node> closed = new List<Node>();

            open.Push(new Node(new State(), null));
            while (open.Count > 0 && !open.Peek().State.IsEndState)
            {
                Node node = open.Pop();

                List<Operator> operators = node.State.GetValidOperators();

                for (int i = 0; i < operators.Count; i++)
                {
                    Node newNode = new Node(new State(node.State), node);
                    newNode.State.Move(operators[i]);
                    newNode.Operator = operators[i];
                    if (!open.Contains(newNode) && !closed.Contains(newNode))
                    {
                        open.Push(newNode);
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
