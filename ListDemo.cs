   using Library;
   using System.Collections.Generic;
   using System.Text;

   class ListDemo {
   // Demonstrate simple application of the generic List class (C# version 2.0)

     class Entry {
       public string name;
       public int age;                                     // other fields could be added

       public Entry(string name, int age) {                // constructor
         this.name = name;
         this.age = age;
       }
     } // Entry

     static List<Entry> list = new List<Entry>();          // global for simplicity here!

     public static int Position(string name) {
     // Finds Position of entry with search key name in list, or -1 if not found
       int i = list.Count - 1;                             // index of last entry
       while (i >= 0 &&                                    // short-circuit protection
              !name.Equals(list[i].name))                  // no need to cast before extracting field
         i--;                                              // will reach -1 if no match
       return i;
     } // Position

     public static void Main (string[] args) {
     // Build a list of people's names and ages
       IO.WriteLine("Supply a list of people's names and ages.  CTRL-Z to terminate");
       do {
         string name = IO.ReadWord();
         if (IO.EOF()) break;
         int age = IO.ReadInt();
         IO.ReadLn();
         list.Add(new Entry(name, age));                   // add to end of list
       } while (!IO.EOF());

       IO.WriteLine(list.Count + " items stored");         // report size of list

       Entry patEntry = new Entry("Pat", 61);              // that fellow again!
       list[0] = patEntry;                                 // insert him on position 0

       StringBuilder sb = new StringBuilder();             // demonstrate StringBuilder use
       for (int i = 0; i < list.Count; i++) {              // display each entry
         Entry e = list[i];                                // retrieve an item at position i
         IO.Write(e.name, -16); IO.WriteLine(e.age);       // -16 means "left justify"
         sb.Append(e.name + " ");                          // add the names to a StringBuffer object
       }
       IO.WriteLine();

       int where = position("Peter");                      // find the silly fellow!
       if (where < 0) IO.WriteLine("Peter not found");
       else {
         Entry peter = list[where];                        // retrieve an item at position where
         IO.WriteLine("Peter found at position " + where + ". He is " + peter.age + " years old");
       }

       if (sb.Length > 0) {
         IO.WriteLine();
         IO.WriteLine("Summary of names:");
         IO.WriteLine();
         IO.WriteLine(sb.ToString());
       }
     }

   } // ListDemo
