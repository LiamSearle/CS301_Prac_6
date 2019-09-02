// Handle cross reference table for Parva
// P.D. Terry, Rhodes University, 2016

using Library;
using System.Collections.Generic;

namespace Parva {

  class Entry {                      // Cross reference table entries
    public string name;              // The identifier itself
    public List<int> refs;           // Line numbers where it appears
    public Entry(string name) {
      this.name = name;
      this.refs = new List<int>();
    }
  } // Entry

  class Table {
    static List<Entry> theList = new List<Entry>();

    public static void ClearTable() {
            // Clears cross-reference table
            theList.Clear();
    } // Table.ClearTable

    public static void AddRef(string name, bool declared, int lineRef) {
            // Enters name if not already there, and then adds another line reference (negative
            // if at a declaration point in the original source program)
            if (!declared) 
            { //Not declared (YET)
                //Adds name to the theList  and then adds the lineRef to the refs list.
                theList.Add(new Entry(name));
                theList[theList.Count() - 1].refs.Add(lineRef);
            } else
            {  //Already declared
                for (int i = 0; i < theList.Count(); i++)
                    if(theList[i].name == name)
                        theList[i].refs.Add(lineRef);
            }
                
    } // Table.AddRef

    public static void PrintTable() {
    // Prints out all references in the table (eliminate duplicate line numbers)
            string display = "";
            foreach (Entry x in theList)
            {
                display += x.name + "\t\t\t";
                display += "-" + x.refs[0] + "\t";
                for (int i = 1; i < x.refs.Count(); i++)
                    display += x.refs[i] + "\t";
                display += "\n";
            }
    } // Table.PrintTable

  } // Table

} // namespace
