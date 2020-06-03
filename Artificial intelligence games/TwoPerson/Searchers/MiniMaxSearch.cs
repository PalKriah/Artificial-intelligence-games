using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artificial_intelligence_games.TwoPerson.Searchers
{
    public class MiniMaxSearch
    {
        int maxStep;

        public MiniMaxSearch(int maxStep)
        {
            this.maxStep = maxStep;
        }

        public Operator NextStep(State currentState)
        {
            Node start = new Node(currentState);
            Node next = MinMax(start, true, int.MinValue + 1, int.MaxValue);
            while (next.Parent != start) { next = next.Parent; }
            return next.Operator;
        }

        private Node MinMax(Node currentNode, bool maximize, int alfa, int beta)
        {
            if (currentNode.Depth == maxStep || currentNode.State.IsEndState)
            {
                currentNode.Value = currentNode.State.Heuristic * (maximize ? -1 : 1);
                return currentNode;
            }

            List<Node> children = currentNode.Expand();

            Node firstChild = children[0];
            Node best;
            if (maximize)
            {
                best = MinMax(firstChild, false, alfa, beta);
                int h = best.Value;
                for (int i = 1; i < children.Count; i++)
                {
                    Node child = children[i];
                    Node possibleBest = MinMax(child, false, alfa, beta);
                    int hE = possibleBest.Value;
                    if (hE > h) { h = hE; best = possibleBest; }
                    if (alfa < h) { alfa = h; }
                    if (alfa >= beta) { break; }
                }
            }
            else
            {
                best = MinMax(firstChild, true, alfa, beta);
                int h = best.Value;
                for (int i = 1; i < children.Count; i++)
                {
                    Node child = children[i];
                    Node possibleBest = MinMax(child, true, alfa, beta);
                    int hE = possibleBest.Value;
                    if (hE < h) { h = hE; best = possibleBest; }
                    if (beta > h) { beta = h; }
                    if (alfa >= beta) { break; }
                }
            }
            return best;
        }
    }
}
