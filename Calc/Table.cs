// Handle cross reference table for Parva
// Matthew Lewis, Liam Searle , Makungu Chansa  - 2019 

using Library;
using System;
using System.Collections.Generic;

namespace Calc {

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
        static List<Entry> symTable = new List<Entry>(); //Symbol Table
                                                         // global variables that can be manipulated in the Parva grammar.
        public static bool dec = false;
        public static bool check = false;


        public static void ClearTable() {
            // Clears cross-reference table
            symTable.Clear();
        } // Table.ClearTable


    public static bool VarExists(string name) {
            for (int i = 0; i < symTable.Count; i++)
                if (symTable[i].name == name)
                    return true;
            return false;
        }

    public static void AddRef(string name, bool declared, int lineRef) {
            // Enters name if not already there, and then adds another line reference (negative
            // if at a declaration point in the original source program)
            if (declared) 
            { //Not declared (YET)
                bool ch = false; //checks if name is in the symTable
                if(VarExists(name))
                    ch = true;
                if (ch == false)
                {
                    //Adds name to the symTable  and then adds the lineRef to the refs list.
                    symTable.Add(new Entry(name));
                    symTable[symTable.Count - 1].refs.Add(lineRef);
                }
            } else
            {  //Already declared
                for (int i = 0; i < symTable.Count; i++)
                    if(symTable[i].name == name)
                        symTable[i].refs.Add(lineRef);
            }
                
    } // Table.AddRef

    public static void PrintTable() {
    // Prints out all references in the table (eliminate duplicate line numbers)
            string display = "";
            foreach (Entry x in symTable)
            {
                if (x.name.Length > 7) //7 be the magic number.
                    display += x.name + "\t\t\t";
                else 
                    display += x.name + "\t\t\t\t";


                //First line where name is mentioned should be the declaration line
                //might need to add some check here to see that it actually was declared.
                display += "-" + x.refs[0] + "\t" + x.type + "\t" + x.value + ":\t";
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
            for (int i = 0; i < symTable.Count; i++)
                if (symTable[i].name == name)
                    return symTable[i].value;
            string msg = "Variable " + name + " has not been declared.";
            throw new Exception(msg);
        }

        public static int RetrieveType(string name)
        // Retrieves the value that is associated with the variable in the table
        {
            for (int i = 0; i < symTable.Count; i++)
                if (symTable[i].name == name)
                    return (int) symTable[i].type;
            string msg = "Variable " + name + " has not been declared.";
            throw new Exception(msg);
        }

        public static void StoreValue(string name, int val, int type)
    // Store the value & type of a variable with the variable
    {
        for (int i = 0; i < symTable.Count; i++)
        {
            if (symTable[i].name == name)
            {
                symTable[i].type = (Entry.Type) type;
                symTable[i].value = val;
                break;
            }
        }
    }

  } // Table

} // namespace
