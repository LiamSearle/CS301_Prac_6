
/* Generic driver frame file for Coco/R for C#.
   PDT  October 2005 - for CSC 301 pracs
   Modify this to suit your own purposes - hints are given below! */

//  ----------------------- you may need to change the "using" clauses:

using System;
using System.IO;
using System.Text;
using Library;

namespace Calc {

  public class Calc {

    public static void Main (string[] args) {
      bool mergeErrors = false;
      string inputName = null;

      // ------------------------ you may need to process command line parameters:

      for (int i = 0; i < args.Length; i++) {
        if (args[i].ToLower().Equals("-l")) mergeErrors = true;
        else inputName = args[i];
      }
      if (inputName == null) {
        Console.WriteLine("No input file specified");
        System.Environment.Exit(1);
      }

      int pos = inputName.LastIndexOf('/');
      if (pos < 0) pos = inputName.LastIndexOf('\\');
      string dir = inputName.Substring(0, pos+1);

/*++++ If the parser needs an output file, include a section like the following
       and add a line

            public static OutFile output;

       to your ATG file.

      string outputName = null;
      pos = inputName.LastIndexOf('.');
      if (pos < 0) outputName = inputName + ".out";
      else outputName = inputName.Substring(0, pos) + ".out";
      Parser.output = new OutFile(outputName);
      if (Parser.output.OpenError()) {
        Console.WriteLine("cannot open " + outputName);
        System.Environment.Exit(1);
      }

++++++ */

      Scanner.Init(inputName);
      Errors.Init(inputName, dir, mergeErrors);
      //  ----------------------- add other initialization if required:
      Parser.Parse();
      Errors.Summarize();
      //  ----------------------- add other finalization if required:

/*++++ If the parser needs an output file, uncomment this section
      Parser.output.Close();
++++++ */

    }

  } // end driver

} // end namespace
