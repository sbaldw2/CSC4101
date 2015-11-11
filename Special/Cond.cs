// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree
{
    public class Cond : Special // we need to have the mechanics of this explained
    { // this method makes ZERO sense to me.
	public Cond() { }

        public override void print(Node t, int n, bool p)
        { 
            Printer.printCond(t, n, p);
        }

        public Node eval (Node t, Environment e)
        {
            Node cdr = t.getCdr();
            if(cdr == null)
            {
                Console.Error.WriteLine("Error: Cond is null");
            }
            return null;
        }
    }
}


