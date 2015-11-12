// SPP -- The main program of the Scheme pretty printer.

using System;
using Parse;
using Tokens;
using Tree;

public class Scheme4101
{
    public static int Main(string[] args)
    {
        // Create scanner that reads from standard input
        Scanner scanner = new Scanner(Console.In);
        
        if (args.Length > 1 ||
            (args.Length == 1 && ! args[0].Equals("-d")))
        {
            Console.Error.WriteLine("Usage: mono SPP [-d]");
            return 1;
        }
        
        // If command line option -d is provided, debug the scanner.
        if (args.Length == 1 && args[0].Equals("-d"))
        {
            // Console.Write("Scheme 4101> ");
            Token tok = scanner.getNextToken();
            while (tok != null)
            {
                TokenType tt = tok.getType();

                Console.Write(tt);
                if (tt == TokenType.INT)
                    Console.WriteLine(", intVal = " + tok.getIntVal());
                else if (tt == TokenType.STRING)
                    Console.WriteLine(", stringVal = " + tok.getStringVal());
                else if (tt == TokenType.IDENT)
                    Console.WriteLine(", name = " + tok.getName());
                else
                    Console.WriteLine();

                // Console.Write("Scheme 4101> ");
                tok = scanner.getNextToken();
            }
            return 0;
        }

        // Create parser
        TreeBuilder builder = new TreeBuilder();
        Parser parser = new Parser(scanner, builder);
        Node root;

        // TODO: Create and populate the built-in environment and
        // create the top-level environment
        var env = new Tree.Environment(); // create built in environment for scheme functions
        var id = new Ident("car");
        // TODO: create lines for definitions of built in functions from first page of docs
        id = new Ident("b+");
        env.define(id, new BuiltIn(id)); // populates environment--puts car into built in environment--define manages tree for you
        env = new Tree.Environment(env); // 
        root = (Node) parser.parseExp();
        while (root != null) 
        {
            root.print(0);
            root = (Node) parser.parseExp();
        }

        return 0;
    }
}
