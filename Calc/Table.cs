// Handle cross reference table for Parva
// Matthew Lewis, Liam Searle, Makungu Chansa (Absent) - 2019 

using Library;
using System;
using System.Collections.Generic;

namespace Calc {
    /*
    class Types //won't be using this for arrays yet.
    {
        public const int // Identifier (and expression) types
        noType = 0, // Numbering is significant
        nullType = 2, // array types are denoted by these numbers + 1
        intType = 4, //
        boolType = 6, //
        voidType = 8;
        static List<string> typeNames = new List<string>();
        static int nextType = 0;

        public static int AddType(string name)
        {
            // Generate (and return) next type id, and add to list of type names
            int thisType = nextType;
            nextType += 2;
            typeNames.Add(name); // simple
            typeNames.Add(name + "[]"); // matching array
            return thisType;
        } // Types.AddType
        public static string Name(int type)
        {
            return typeNames[type];
        } // Types.Name
    } // end Types 
} */
  class Entry {                      // Cross reference table entries
    public enum Type
    { //using the same spacing as above for future proofing.
        noType = 0,
        intType = 4,
        boolType = 6
    };
    public string name;              // The identifier itself
    public int value;                // Value stored in the variable
    public Type type;
    public List<int> refs;           // Line numbers where it appears
    public Entry(string name) {
      this.name = name;
      this.type = Type.noType;
      this.refs = new List<int>();
    }
} // Entry

  class Table {
    static List<Entry> theList = new List<Entry>(); //Symbol Table
    // global variables that can be manipulated in the Parva grammar.
    public static bool dec = false; 
    public static bool check = false; 


        public static void ClearTable() {
            // Clears cross-reference table
            theList.Clear();
    } // Table.ClearTable

    public static void AddRef(string name, bool declared, int lineRef) {
            // Enters name if not already there, and then adds another line reference (negative
            // if at a declaration point in the original source program)
            if (declared) 
            { //Not declared (YET)
                //Adds name to the theList  and then adds the lineRef to the refs list.
                theList.Add(new Entry(name));
                theList[theList.Count - 1].refs.Add(lineRef);
            } else
            {  //Already declared
                for (int i = 0; i < theList.Count; i++)
                    if(theList[i].name == name)
                        theList[i].refs.Add(lineRef);
            }
                
    } // Table.AddRef

    public static void PrintTable() {
    // Prints out all references in the table (eliminate duplicate line numbers)
            string display = "";
            foreach (Entry x in theList)
            {
                if (x.name.Length > 7) //7 be the magic number.
                    display += x.name + "\t\t\t";
                else 
                    display += x.name + "\t\t\t\t";


                //First line where name is mentioned should be the declaration line
                //might need to add some check here to see that it actually was declared.
                display += "-" + x.refs[0] + "\t"; 
                for (int i = 1; i < x.refs.Count; i++)
                    display += x.refs[i] + "\t";
                Console.WriteLine(display);
                display = "";
                display += "\n";
            }
            
    } // Table.PrintTable

        public static int RetrieveValue(string name)
        // Retrieves the value that is associated with the variable in the table
        {
            for (int i = 0; i < theList.Count; i++)
                if (theList[i].name == name)
                    return theList[i].value;
            string msg = "Variable " + name + " has not been declared.";
            throw new Exception(msg);
        }

        public static int RetrieveType(string name)
        // Retrieves the value that is associated with the variable in the table
        {
            for (int i = 0; i < theList.Count; i++)
                if (theList[i].name == name)
                    return (int) theList[i].type;
            string msg = "Variable " + name + " has not been declared.";
            throw new Exception(msg);
        }

        public static void StoreValue(string name, int val, int type)
    // Store the value & type of a variable with the variable
    {
        for (int i = 0; i < theList.Count; i++)
        {
            if (theList[i].name == name)
            {
                theList[i].type = (Entry.Type) type;
                theList[i].value = val;
                break;
            }
        }
    }

  } // Table

} // namespace
