using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artificial_intelligence_games.OnePerson
{
    public class Node
    {
        public State State { get; set; }
        public Node Parent { get; set; }
        public Operator Operator { get; set; }

        public Node(State state)
        {
            State = state;
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

        public bool VisitedNode
        {
            get
            {
                Node parent = this.Parent;

                while (parent != null)
                {
                    if (Equals(parent))
                    {
                        return true;
                    }
                    parent = parent.Parent;
                }
                return false;
            }
        }

        public List<Operator> MovePath
        {
            get
            {
                List<Operator> movePath = new List<Operator>();
                Node node = this;
                while (node.Parent != null)
                {
                    movePath.Add(node.Operator);
                    node = node.Parent;
                }
                movePath.Reverse();
                return movePath;
            }
        }

        public int Cost
        {
            get
            {
                if (Parent == null)
                {
                    return 1;
                }
                else
                {
                    return Parent.Cost + 1;
                }
            }
        }

        public int Heuristic
        {
            get
            {
                return State.Heuristic;
            }
        }

        public int SumCost
        {
            get
            {
                return Heuristic + Cost;
            }
        }

        public override bool Equals(object obj)
        {
            Node OtherNode = (Node)obj;
            return State.Equals(OtherNode.State);
        }
    }
}
