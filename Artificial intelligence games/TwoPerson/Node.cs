using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artificial_intelligence_games.TwoPerson
{
    public class Node
    {
        public State State { get; set; }
        public Node Parent { get; set; }
        public Operator Operator { get; set; }
        public int Value { get; set; }

        public Node(State state)
        {
            State = new State(state);
            Parent = null;
        }

        public Node(State state, Node parent) : this(state)
        {
            Parent = parent;
        }

        public int Depth
        {
            get
            {
                int depth = 0;
                Node node = this;
                while (node.Parent != null)
                {
                    depth++;
                    node = node.Parent;
                }
                return depth;
            }
        }

        public List<Node> Expand()
        {
            List<Node> children = new List<Node>();
            foreach (Operator @operator in State.GetValidOperators())
            {
                Node node = new Node(State, this);
                node.State.Move(@operator);
                node.Operator = @operator;
                children.Add(node);
            }
            return children;
        }
    }
}
