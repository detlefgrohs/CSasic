using System;
using System.IO;

namespace CSasic.CommandLine {
    class Program {
        static void Main(string[] args) {
            Interpreter.Create().Interpret(File.ReadAllText(args[0]));
        }
    }
}