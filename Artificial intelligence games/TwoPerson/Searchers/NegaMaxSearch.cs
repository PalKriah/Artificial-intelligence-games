using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artificial_intelligence_games.TwoPerson.Searchers
{
    public class NegaMaxSearch
    {
        int maxStep;

        public NegaMaxSearch(int maxStep)
        {
            this.maxStep = maxStep;
        }

        public Operator NextStep(State currentState)
        {
            Node start = new Node(currentState);
            Node next = NegaMax(start, 1, int.MinValue + 1, int.MaxValue);
            while (next.Parent != start) { next = next.Parent; }
            return next.Operator;
        }

        private Node NegaMax(Node currentNode, int color, int alfa, int beta)
        {
            if (currentNode.Depth == maxStep || currentNode.State.IsEndState)
            {
                currentNode.Value = currentNode.State.Heuristic * -color;
                return currentNode;
            }

            List<Node> children = currentNode.Expand();

            Node firstChild = children[0];
            Node best = NegaMax(firstChild, -color, -beta, -alfa);
            int h = color * best.Value;
            for (int i = 1; i < children.Count; i++)
            {
                Node child = children[i];
                Node possibleBest = NegaMax(child, -color, -beta, -alfa);
                int hE = color * possibleBest.Value;
                if (hE > h) { h = hE; best = possibleBest; }
                if (alfa < h) { alfa = h; }
                if (alfa >= beta) { break; }
            }
            return best;
        }
    }
}
