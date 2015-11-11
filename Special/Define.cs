// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special // do not understand this either, at all 
    {
	public Define() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printDefine(t, n, p);
        }
    }
}


