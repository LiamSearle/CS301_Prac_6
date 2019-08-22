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
    static List<Entry> list = new List<Entry>();

    public static void ClearTable() {
    // Clears cross-reference table
    // ...
    } // Table.ClearTable

    public static void AddRef(string name, bool declared, int lineRef) {
    // Enters name if not already there, and then adds another line reference (negative
    // if at a declaration point in the original source program)
    // ...
    } // Table.AddRef

    public static void PrintTable() {
    // Prints out all references in the table (eliminate duplicates line numbers)
    //...
    } // Table.PrintTable

  } // Table

} // namespace
