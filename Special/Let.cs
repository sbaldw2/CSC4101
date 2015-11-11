// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special // what this do
    {
	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printLet(t, n, p);
        }
    }
}


