// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special // IN PROGRESS
    {
	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printLet(t, n, p);
        }

        public Node eval (Node t, Environment e)
        {
            Environment letE = new Environment(e);
            Node children = t.getCdr().getCar();
            if (children != null)
            {
                Node current = t.getCar();
                letE.define(current, null);
                return null;
            }
        }
    }
}


