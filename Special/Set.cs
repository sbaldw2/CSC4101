// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special // TODO
    {
	public Set() { }
	
        public override void print(Node t, int n, bool p)
        {
            Printer.printSet(t, n, p);
        }

        public Node eval (Node t, Environment e)
        {
            Node current = t.getCdr().getCar();
            if (!current.isSymbol())
            {
                Console.Error.WriteLine("Error: Not an identifier");
                return Nil.getInstance();
            }
            // insert some methods about env, kinda confusing/binding stuff
            Node final = t.getCdr().getCdr().getCar();
            final = final.eval(final, e);
            e.assign(current, final);
            return new StringLit("; " + current.getName() + " - updated.");
        }
    }
}

