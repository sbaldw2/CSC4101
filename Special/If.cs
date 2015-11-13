// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {
	public If() { } // DONE ?

        public override void print(Node t, int n, bool p)
        {
            Printer.printIf(t, n, p);
        }

        public Node eval (Node t, Environment e) // REMEMBER: If not explictly false, then true.
        {
            Node cond = t.getCdr().getCar(); // condition -> cadr(exp)
            if (cond == null)
            {
                Console.Error.WriteLine("Error: Null in Condition");
            }
            Node ifTrue = t.getCdr().getCdr().getCar(); // true -> caddr(exp)
            if (ifTrue == null)
            {
                Console.Error.WriteLine("Error: Null in True/If");
            }
            Node ifFalse = t.getCdr().getCdr().getCdr().getCar(); // false -> cadddr(exp)
            if (ifFalse == null)
            {
                Console.Error.WriteLine("Error: Null in False/Else");
            }
            bool checkTrueResult = checkTrue(t, e);
            if (checkTrueResult == true)
            {
                return ifTrue.eval(ifTrue, e);
            }
            else
            {
                return ifFalse.eval(ifFalse, e);
            }

        }

        public Boolean checkTrue(Node cond, Environment e)
        {
            Node check = cond.eval(cond, e);
            if (check.isBool() == true)
            {
                BoolLit boolVal = (BoolLit) check;
                return boolVal.getVal();
            }
            return true;
        }

        public Boolean checkFalse(Node cond, Environment e) // can I merge these two into one check/fn??^^
        {
            return !checkTrue(cond, e);
        }
    }
}

