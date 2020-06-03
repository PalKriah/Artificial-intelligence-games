using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artificial_intelligence_games.OnePerson.Searchers
{
    public class Aalgorithm : AbstractSearch
    {
        public override List<Operator> Search()
        {
            List<Node> path = new List<Node>();
            List<Node> closed = new List<Node>();

            path.Add(new Node(new State(), null));
            while (path.Count > 0 && !path.Last().State.IsEndState)
            {
                Node node = path.Last();
                path.RemoveAt(path.Count - 1);

                List<Operator> operators = node.State.GetValidOperators();

                List<Node> siblings = new List<Node>();
                for (int i = 0; i < operators.Count; i++)
                {
                    Node newNode = new Node(new State(node.State), node);
                    newNode.State.Move(operators[i]);
                    newNode.Operator = operators[i];
                    if (!path.Contains(newNode) && !closed.Contains(newNode))
                    {
                        siblings.Add(newNode);
                    }
                }

                siblings.Sort(
                    (n1, n2) =>
                    {
                        if (n1.SumCost > n2.SumCost)
                        {
                            return -1;
                        }
                        else if (n1.SumCost < n2.SumCost)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    });
                path.AddRange(siblings);
                closed.Add(node);
            }

            if (path.Count > 0)
            {
                return path.Last().MovePath;
            }
            return null;
        }
    }
}
