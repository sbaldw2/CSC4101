// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {
	public If() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printIf(t, n, p);
        }

        public Node eval (Node t, Environment e)
        {
            Node check = t.getCdr().getCar();
            check = check.eval(check, e);
            Node final = null;
            if (check instanceof BooleanLit) 
        }
    }
}

