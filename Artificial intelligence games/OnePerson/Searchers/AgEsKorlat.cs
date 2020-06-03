using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artificial_intelligence_games.OnePerson.Searchers
{
    public class AgEsKorlat : AbstractSearch
    {
        int depth;
        public AgEsKorlat(int depth)
        {
            this.depth = depth;
        }

        public override List<Operator> Search()
        {
            Node node = new Node(new State());
            node = Search(node, null);

            if (node != null)
            {
                return node.MovePath;
            }
            return null;
        }

        private Node Search(Node node, Node bestNode)
        {
            if (depth < node.Depth || node.VisitedNode || (bestNode != null && node.Depth >= bestNode.Depth))
            {
                return null;
            }

            if (node.State.IsEndState)
            {
                return node;
            }

            List<Operator> operators = node.State.GetValidOperators();

            for (int i = 0; i < operators.Count; i++)
            {
                Node newNode = new Node(new State(node.State), node);
                newNode.State.Move(operators[i]);
                newNode.Operator = operators[i];

                Node terminal = Search(newNode, bestNode);

                if (terminal != null && (bestNode == null || terminal.Depth < bestNode.Depth))
                {
                    bestNode = terminal;
                }
            }
            return bestNode;
        }
    }
}
