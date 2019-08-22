using System;
using System.IO;
using System.Text;
using System.Collections;

namespace Library {

// 2004/06/21
// Concatenation of IO, InFile, OutFile, Screen, IntSet and SymSet
// revised 2009/09/07
// revised 2009/10/28
// revised 2011/08/16
// revised 2014/03/14
// revised 2015/06/18

  /////////////////////////////////////////////////////////////////////////////////////////

  public class IO {   // 2015/06/18
  // Provide simple facilities for text I/O (standard input and output streams)
  // P.D. Terry (p.terry@ru.ac.za)

    static public void UseDefaultEncoding() {
    // Use default 8 bit PC Ascii character set on Console output
      Console.OutputEncoding = Encoding.Default;
    } // IO.UseDefaultEncoding

    static public void Write(string s)                 { Console.Write(s); }
    static public void Write(object o)                 { Console.Write(o); }
    static public void Write(byte o)                   { Write(o, 0); }
    static public void Write(sbyte o)                  { Write(o, 0); }
    static public void Write(short o)                  { Write(o, 0); }
    static public void Write(int o)                    { Write(o, 0); }
    static public void Write(long o)                   { Write(o, 0); }
    static public void Write(bool o)                   { Write(o, 0); }
    static public void Write(float o)                  { Write(o, 0); }
    static public void Write(double o)                 { Write(o, 0); }
    static public void Write(char o)                   { Console.Write(o); }
    static public void Write(char[] o)                 { Console.Write(o); }
    static public void Write(char[] o, int off,
                             int len)                  { for (int i = 0; i < len; i++)
                                                           Console.Write(o[off+i]); }

    static public void WriteLine()                     { Console.WriteLine(); }
    static public void WriteLine(string s)             { Console.WriteLine(s); }
    static public void WriteLine(object o)             { Console.WriteLine(o); }
    static public void WriteLine(byte o)               { WriteLine(o, 0); }
    static public void WriteLine(sbyte o)              { WriteLine(o, 0); }
    static public void WriteLine(short o)              { WriteLine(o, 0); }
    static public void WriteLine(int o)                { WriteLine(o, 0); }
    static public void WriteLine(long o)               { WriteLine(o, 0); }
    static public void WriteLine(bool o)               { WriteLine(o, 0); }
    static public void WriteLine(float o)              { WriteLine(o, 0); }
    static public void WriteLine(double o)             { WriteLine(o, 0); }
    static public void WriteLine(char o)               { Console.WriteLine(o); }
    static public void WriteLine(char[] o)             { Console.WriteLine(o); }
    static public void WriteLine(char[] o, int off,
                                 int len)              { for (int i = 0; i < len; i++)
                                                           Console.Write(o[off+i]);
                                                         Console.WriteLine(); }

    static private void PutStr(string s, int width) {
      if (width == 0) Console.Write(" " + s);
      else if (width > 0) {
        for (int i = s.Length; i < width; i++) Console.Write(' ');
        Console.Write(s);
      }
      else {
        Console.Write(s);
        for (int i = s.Length; i < -width; i++) Console.Write(' ');
      }
    } // IO.PutStr

    static public void Write(string o, int width)      { PutStr(o, width); }
    static public void Write(object o, int width)      { PutStr(o.ToString(), width); }
    static public void Write(byte o,   int width)      { PutStr(o.ToString(), width); }
    static public void Write(sbyte o,  int width)      { PutStr(o.ToString(), width); }
    static public void Write(short o,  int width)      { PutStr(o.ToString(), width); }
    static public void Write(int o,    int width)      { PutStr(o.ToString(), width); }
    static public void Write(long o,   int width)      { PutStr(o.ToString(), width); }
    static public void Write(bool o,   int width)      { PutStr(o.ToString(), width); }
    static public void Write(float o,  int width)      { PutStr(o.ToString(), width); }
    static public void Write(double o, int width)      { PutStr(o.ToString(), width); }
    static public void Write(char o,   int width)      { PutStr(o.ToString(), width); }

    static private void PutLine(string s, int width) {
      if (width == 0) Console.WriteLine(" " + s);
      else if (width > 0) {
        for (int i = s.Length; i < width; i++) Console.Write(' ');
        Console.WriteLine(s);
      }
      else {
        Console.Write(s);
        for (int i = s.Length; i < -width; i++) Console.Write(' ');
        Console.WriteLine();
      }
    } // IO.PutLine

    static public void WriteLine(string o, int width)  { PutLine(o, width); }
    static public void WriteLine(object o, int width)  { PutLine(o.ToString(), width); }
    static public void WriteLine(byte o,   int width)  { PutLine(o.ToString(), width); }
    static public void WriteLine(sbyte o,  int width)  { PutLine(o.ToString(), width); }
    static public void WriteLine(short o,  int width)  { PutLine(o.ToString(), width); }
    static public void WriteLine(int o,    int width)  { PutLine(o.ToString(), width); }
    static public void WriteLine(long o,   int width)  { PutLine(o.ToString(), width); }
    static public void WriteLine(bool o,   int width)  { PutLine(o.ToString(), width); }
    static public void WriteLine(float o,  int width)  { PutLine(o.ToString(), width); }
    static public void WriteLine(double o, int width)  { PutLine(o.ToString(), width); }
    static public void WriteLine(char o,   int width)  { PutLine(o.ToString(), width); }

    // formatters

    public static string FixedRep(double d, int fractionDigits) {
      string fmt = "{0,0:F" + Math.Abs(fractionDigits).ToString() + "}";
      return string.Format(fmt, d);
    } // IO.FixedRep

    public static string FixedRep(float f, int fractionDigits) {
      string fmt = "{0,0:F" + Math.Abs(fractionDigits).ToString() + "}";
      return string.Format(fmt, f);
    } // IO.FixedRep

    public static string FloatingRep(double d, int fractionDigits) {
      string fmt = "{0,0:E" + Math.Abs(fractionDigits).ToString() + "}";
      return string.Format(fmt, d);
    } // IO.FloatingRep

    public static string FloatingRep(float f, int fractionDigits) {
      string fmt = "{0,0:E" + Math.Abs(fractionDigits).ToString() + "}";
      return string.Format(fmt, f);
    } // IO.FloatingRep

    static public void WriteFixed(double d, int width, int fractionDigits) {
      if (width == 0) Console.Write(" ");
      string fmt = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      Console.Write(string.Format(fmt, d));
    } // IO.WriteFixed

    static public void WriteLineFixed(double d, int width, int fractionDigits) {
      if (width == 0) Console.Write(" ");
      string fmt = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      Console.WriteLine(string.Format(fmt, d));
    } // IO.WriteLineFixed

    static public void WriteFloating(double d, int width, int fractionDigits) {
      if (width == 0) Console.Write(" ");
      string fmt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      Console.Write(string.Format(fmt, d));
    } // WriteFloating

    static public void WriteLineFloating(double d, int width, int fractionDigits) {
      if (width == 0) Console.Write(" ");
      string fmt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      Console.WriteLine(string.Format(fmt, d));
    } // IO.WriteFloating

    static public void Write(double d, int width, int fractionDigits) {
      if (width == 0) Console.Write(" ");
      string fix = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      string flt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      string sfx = string.Format(fix, d);
      string sfl = string.Format(flt, d);
      if (width == 0)
        if (sfx.Length <= sfl.Length) Console.Write(sfx); else Console.Write(sfl);
      else
        if (sfx.Length <= Math.Abs(width)) Console.Write(sfx); else Console.Write(sfl);
    } // IO.Write

    static public void WriteLine(double d, int width, int fractionDigits) {
      if (width == 0) Console.Write(" ");
      string fix = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      string flt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      string sfx = string.Format(fix, d);
      string sfl = string.Format(flt, d);
      if (width == 0)
        if (sfx.Length <= sfl.Length) Console.WriteLine(sfx); else Console.WriteLine(sfl);
      else
        if (sfx.Length <= Math.Abs(width)) Console.WriteLine(sfx); else Console.WriteLine(sfl);
    } // WriteLine

    static public void WriteFixed(float f, int width, int fractionDigits) {
      if (width == 0) Console.Write(" ");
      string fmt = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      Console.Write(string.Format(fmt, f));
    } // IO.WriteFixed

    static public void WriteLineFixed(float f, int width, int fractionDigits) {
      if (width == 0) Console.Write(" ");
      string fmt = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      Console.WriteLine(string.Format(fmt, f));
    } // IO.WriteLineFixed

    static public void WriteFloating(float f, int width, int fractionDigits) {
      if (width == 0) Console.Write(" ");
      string fmt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      Console.Write(string.Format(fmt, f));
    } // IO.WriteFloating

    static public void WriteLineFloating(float f, int width, int fractionDigits) {
      if (width == 0) Console.Write(" ");
      string fmt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      Console.WriteLine(string.Format(fmt, f));
    } // IO.WriteLineFloat

    static public void Write(float f, int width, int fractionDigits) {
      if (width == 0) Console.Write(" ");
      string fix = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      string flt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      string sfx = string.Format(fix, f);
      string sfl = string.Format(flt, f);
      if (width == 0)
        if (sfx.Length <= sfl.Length) Console.Write(sfx); else Console.Write(sfl);
      else
        if (sfx.Length <= Math.Abs(width)) Console.Write(sfx); else Console.Write(sfl);
    } // IO.Write

    static public void WriteLine(float f, int width, int fractionDigits) {
      if (width == 0) Console.Write(" ");
      string fix = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      string flt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      string sfx = string.Format(fix, f);
      string sfl = string.Format(flt, f);
      if (width == 0)
        if (sfx.Length <= sfl.Length) Console.WriteLine(sfx); else Console.WriteLine(sfl);
      else
        if (sfx.Length <= Math.Abs(width)) Console.WriteLine(sfx); else Console.WriteLine(sfl);
    } // IO.WriteLib\ne

    static public void Prompt(string str) {
      Console.Error.Write(str + " ");
    } // IO.Prompt

    static public void WriteErrorMessage(string str) {
      Console.Error.WriteLine(str);
    } // IO.WriteErrorMessage

  // -- input routines

    const char CR = '\r';
    const char LF = '\n';

    static bool okay = false;    // module-wide error flag for simplicity

    static char savedChar;
    static bool eof, eol, inError, haveCh, noData, printErrors;
    static int errorCount;

    // internal character and token readers

    static char NextChar() {
    // Probe and retrieve next character from input
    // Note that CR+LF is mapped into LF only, and '\0' is returned if the end of
    // file is reached.  There is a one character buffer, to allow ReadAgain
    // to work, and to allow easy reading of strings and tokens, which have to
    // one character past their end.
    // It is an error to attempt to go past the end of file if it has already
    // been detected!
      char ch;
      if (haveCh) { ch = savedChar; okay = ch != '\0'; }
      else if (eof) { ch = '\0'; okay = false; }  // been there already
      else {                                      // get on with it
        int i = Console.Read(); okay = true;
        if (i == CR) { i = Console.Read(); }      // MS-DOS
        ch = (char) i;
        if (i == -1 | i == 26) { ch = '\0'; eof = true; }   // there was no character after all
      }
      savedChar = ch; haveCh = false;
      eol = eof || ch == LF;                      // eof also sets eol
      inError = ! okay;
      if (!okay && printErrors) {
        Console.Error.WriteLine("Attempt to read past eof");
        System.Environment.Exit(1);
      }
      return ch;
    } // IO.NextChar

    static private string ReadToken() {
    // Internal version of ReadWord with no error reporting
      StringBuilder sb = new StringBuilder();
      char ch;
      SkipSpaces();
      if (eof) {
        noData = true; okay = false; inError = true;
        return " ";
      }
      ch = NextChar();
      while (ch > ' ') { sb.Append(ch); ch = NextChar(); }
      haveCh = true;
      return sb.ToString();
    } // IO.ReadToken

    // Character based input

    static public char ReadChar() {
    // Reads and returns a single character
      char ch = NextChar();
      noData = eof;
      if (noData) ReportError("ReadChar failed - no more data");
      return ch;
    } // IO.ReadChar

    static public char ReadChar(string prompt) {
    // Prompts for, reads and returns a single character
      Console.Error.Write(prompt);
      return ReadChar();
    } // IO.ReadChar(prompt)

    static public void ReadAgain() {
    // Allows for a single character probe in code like
    // do ch = IO.ReadChar(); while(notDigit(ch)); IO.ReadAgain(); ...
      okay = true; haveCh = true;
    } // IO.ReadAgain

    static public void SkipSpaces() {
    // Allows for the most elementary of lookahead probes
      char ch;
      do ch = NextChar(); while (ch <= ' ' && !eof);
      haveCh = true;
    } // IO.SkipSpaces

    static public void ReadLn() {
    // Consumes all characters to end of line.
      while (!eol) ReadChar();
      haveCh = false; eol = false;
    } // IO.ReadLn

    // String based input

    static public string ReadString() {
    // Reads and returns a string.  Incorporates leading white space,
    // and terminates on a control character, which is not
    // incorporated or consumed.
    // Note that this means you might need code like
    //    s = IO.ReadString(); IO.Readln();
    // (Alternatively use ReadLine() below )
      StringBuilder sb = new StringBuilder();
      char ch;
      if (eof) {
        noData = true; okay = false; inError = true;
        ReportError("ReadString failed - no more data");
        return "";
      }
      ch = NextChar();
      while (ch >= ' ') { sb.Append(ch); ch = NextChar(); }
      haveCh = true;
      return sb.ToString();
    } // IO.ReadString

    static public string ReadString(string prompt) {
    // Prompts for, reads and returns a single string
      Console.Error.Write(prompt);
      return ReadString();
    } // IO.ReadString(prompt)

    static public string ReadString(int max) {
    // Reads and returns a string.  Incorporates leading white space,
    // and terminates on a control character, which is not
    // incorporated or consumed, or when max characters have been read
    // (useful for fixed format data).  Note that this means you might
    // need code like s = IO.ReadString(10); IO.Readln();
      StringBuilder sb = new StringBuilder();
      char ch;
      if (eof) {
        noData = true; okay = false; inError = true;
        ReportError("ReadString failed - no more data");
        return "";
      }
      ch = NextChar();
      while (ch >= ' ' && max > 0) { sb.Append(ch); ch = NextChar(); max--; }
      haveCh = true;
      return sb.ToString();
    } // IO.ReadString(max)

    static public string ReadString(string prompt, int max) {
    // Prompts for, reads and returns a single string limited to max characters
      Console.Error.Write(prompt);
      return ReadString(max);
    } // IO.ReadString(prompt, max)

    static public string ReadLine() {
    // Reads and returns a string.  Incorporates leading white space,
    // and terminates when EOL or EOF is reached.  The EOL character
    // is not incorporated, but is consumed.
      StringBuilder sb = new StringBuilder();
      char ch;
      if (eof) {
        noData = true; okay = false; inError = true;
        ReportError("ReadLine failed - No more data");
        return "";
      }
      ch = NextChar();
      while (!eol) { sb.Append(ch); ch = NextChar(); }
      haveCh = false;
      return sb.ToString();
    } // IO.ReadLine

    static public string ReadLine(string prompt) {
    // Prompts for, reads and returns a single line
      Console.Error.Write(prompt);
      return ReadLine();
    } // IO.ReadLine(prompt)

    static public string ReadWord() {
    // Reads and returns a word - a string delimited at either end
    // by a control character or space (typically the latter).
    // Leading spaces are discarded, and the terminating character
    // is not consumed.
      StringBuilder sb = new StringBuilder();
      char ch;
      SkipSpaces();
      if (eof) {
        noData = true; okay = false; inError = true;
        ReportError("ReadWord failed - no more data");
        return "";
      }
      ch = NextChar();
      while (ch > ' ') { sb.Append(ch); ch = NextChar(); }
      haveCh = true;
      return sb.ToString();
    } // IO.ReadWord

    static public string ReadWord(string prompt) {
    // Prompts for, reads and returns a single word
      Console.Error.Write(prompt);
      return ReadWord();
    } // IO.ReadWord(prompt)

    // Numeric input routines.  These always return, even if the data
    // is incorrect.  Users may probe the status of the operation,
    // or use ShowErrors() to get error messages.

    static public int ReadInt(int radix) {
    // Reads a word as a textual representation of an integer (base radix)
    // and returns the corresponding value.
    // Errors may be reported or quietly ignored (when 0 is returned).
      string s = ReadToken();
      int n = 0;
      if (okay) {
        try {
          n = Convert.ToInt32(s, radix);
        }
        catch (Exception) {
          okay = false; n = 0; inError = true;
          ReportError("Bad Integer Format");
        }
      }
      else ReportError("ReadInt failed - no more data");
      return n;
    } // IO.ReadInt(radix)

    static public int ReadInt(string prompt, int radix) {
    // Prompts for, reads and returns a single integer (base radix)
      Console.Error.Write(prompt);
      return ReadInt(radix);
    } // IO.ReadInt(prompt, radix)

    static public int ReadInt() {
    // Reads and returns a single integer (base 10)
      return ReadInt(10);
    } // IO.ReadInt

    static public int ReadInt(string prompt) {
    // Prompts for, reads and returns a single integer (base 10)
      Console.Error.Write(prompt);
      return ReadInt(10);
    } // IO.ReadInt(prompt)

    static public long ReadLong(int radix) {
    // Reads a word as a textual representation of a long integer (base radix)
    // and returns the corresponding value.
    // Errors may be reported or quietly ignored (when 0 is returned).
      string s = ReadToken();
      long n = 0;
      if (okay) {
        try {
          n = Convert.ToInt64(s, radix);
        }
        catch (Exception) {
          okay = false; n = 0; inError = true;
          ReportError("Bad Long Integer Format");
        }
      }
      else ReportError("ReadLong failed - no more data");
      return n;
    } // IO.ReadLong(radix)

    static public long ReadLong(string prompt, int radix) {
    // Prompts for, reads and returns a single long integer (base radix)
      Console.Error.Write(prompt);
      return ReadLong(radix);
    } // IO.ReadLong(prompt, radix)

    static public long ReadLong() {
    // Reads and returns a single long integer (base 10)
      return ReadLong(10);
    } // IO.ReadLong

    static public long ReadLong(string prompt) {
    // Prompts for, reads and returns a single long integer (base 10)
      Console.Error.Write(prompt);
      return ReadLong(10);
    } // IO.ReadLong(prompt)

    static public short ReadShort(int radix) {
    // Reads a word as a textual representation of a short integer (base radix)
    // and returns the corresponding value.
    // Errors may be reported or quietly ignored (when 0 is returned).
      string s = ReadToken();
      short n = 0;
      if (okay) {
        try {
          n = Convert.ToInt16(s, radix);
        }
        catch (Exception) {
          okay = false; n = 0; inError = true;
          ReportError("Bad Short Integer Format");
        }
      }
      else ReportError("ReadShort failed - no more data");
      return n;
    } // IO.ReadShort(radix)

    static public short ReadShort(string prompt, int radix) {
    // Prompts for, reads and returns a single short integer (base radix)
      Console.Error.Write(prompt);
      return ReadShort(radix);
    } // IO.ReadShort(prompt, radix)

    static public short ReadShort() {
    // Reads and returns a single short integer (base 10)
      return ReadShort(10);
    } // IO.ReadShort

    static public short ReadShort(string prompt) {
    // Prompts for, reads and returns a single short integer (base 10)
      Console.Error.Write(prompt);
      return ReadShort(10);
    } // IO.ReadShort(prompt)

    static public sbyte ReadSByte(int radix) {
    // Reads a word as a textual representation of a signed byte (base radix)
    // and returns the corresponding value.
    // Errors may be reported or quietly ignored (when 0 is returned).
      string s = ReadToken();
      sbyte n = 0;
      if (okay) {
        try {
          n = Convert.ToSByte(s, radix);
        }
        catch (Exception) {
          okay = false; n = 0; inError = true;
          ReportError("Bad SByte Format");
        }
      }
      else ReportError("ReadSByte failed - no more data");
      return n;
    } // IO.ReadSByte(radix)

    static public sbyte ReadSByte(string prompt, int radix) {
    // Prompts for, reads and returns a single signed byte (base radix)
      Console.Error.Write(prompt);
      return ReadSByte(radix);
    } // IO.ReadSbyte(prompt, radix)

    static public sbyte ReadSByte() {
    // Reads and returns a single integer (base 10)
      return ReadSByte(10);
    } // IO.ReadSByte

    static public sbyte ReadSByte(string prompt) {
    // Prompts for, reads and returns a single signed byte (base 10)
      Console.Error.Write(prompt);
      return ReadSByte(10);
    } // IO.ReadSByte(prompt)

    static public byte ReadByte(int radix) {
    // Reads a word as a textual representation of a byte (base radix)
    // and returns the corresponding value.
    // Errors may be reported or quietly ignored (when 0 is returned).
      string s = ReadToken();
      byte n = 0;
      if (okay) {
        try {
          n = Convert.ToByte(s, radix);
        }
        catch (Exception) {
          okay = false; n = 0; inError = true;
          ReportError("Bad Byte Format");
        }
      }
      else ReportError("ReadByte failed - no more data");
      return n;
    } // IO.ReadByte(radix)

    static public byte ReadByte(string prompt, int radix) {
    // Prompts for, reads and returns a single byte (base radix)
      Console.Error.Write(prompt);
      return ReadByte(radix);
    } // IO.ReadByte(prompt, radix)

    static public byte ReadByte() {
    // Reads and returns a single byte (base 10)
      return ReadByte(10);
    } // IO.ReadByte

    static public byte ReadByte(string prompt) {
    // Prompts for, reads and returns a single byte (base 10)
      Console.Error.Write(prompt);
      return ReadByte(10);
    } // IO.ReadByte(prompt)

    static public float ReadFloat() {
    // Reads a word as a textual representation of a float
    // and returns the corresponding value.
    // Errors may be reported or quietly ignored (when 0 is returned).
      string s = ReadToken();
      float n = 0;
      if (okay) {
        try {
          n = Convert.ToSingle(s);
        }
        catch (Exception) {
          okay = false; n = 0; inError = true;
          ReportError("Bad Float Format");
        }
      }
      else ReportError("ReadFloat failed - no more data");
      return n;
    } // IO.ReadFloat

    static public float ReadFloat(string prompt) {
    // Prompts for, reads and returns a single float
      Console.Error.Write(prompt);
      return ReadFloat();
    } // IO.ReadFloat(prompt)

    static public double ReadDouble() {
    // Reads a word as a textual representation of a double
    // and returns the corresponding value.
    // Errors may be reported or quietly ignored (when 0 is returned).
      string s = ReadToken();
      double n = 0;
      if (okay) {
        try {
          n = Convert.ToDouble(s);
        }
        catch (Exception) {
          okay = false; n = 0; inError = true;
          ReportError("Bad Double Format");
        }
      }
      else ReportError("ReadDouble failed - no more data");
      return n;
    } // IO.ReadDouble

    static public double ReadDouble(string prompt) {
    // Prompts for, reads and returns a single double
      Console.Error.Write(prompt);
      return ReadDouble();
    } // ReadDouble(prompt)

    static public bool ReadBool() {
    // Reads a word and returns a Boolean value, based on the
    // first letter.  Typically the word would be T(rue) or Y(es)
    // or F(alse) or N(o).
      string s = ReadToken();
      bool b = false;
      if (okay) {
        switch (char.ToUpper(s[0])) {
          case 'Y' : case 'T' : b = true; break;
          case 'N' : case 'F' : b = false; break;
          default  : okay = false; b = false; inError = true;
                     ReportError("Bad Boolean Format"); break;
        }
      }
      else ReportError("ReadBool failed - no more data");
      return b;
    } // IO.ReadBool

    static public bool ReadBool(string prompt) {
    // Prompts for, reads and returns a single double
      Console.Error.Write(prompt);
      return ReadBool();
    } // IO.ReadBool(prompt)

    // Utility "getters"

    static public bool EOF() {
    // Returns true if the last operation terminated by reaching EOF
      return eof;
    } // IO.EOF()

    static public bool EOL() {
    // Returns true if the last operation terminated by reaching EOL
      return eol;
    } // IO.EOL<>

    static public bool Error() {
    // Returns true if the last operation on this file failed
      return inError;
    } // IO.Error()

    static public bool NoMoreData() {
    // Returns true if the last operation on this file failed because
    // an attempt was made to read past the end of file
      return noData;
    } // IO.NoMoreData()

    // Error handlers

    static public void ReportError(string message) {
    // Possible simple error reporting (disabled by default)
      if (printErrors) {
        Console.WriteLine("--- " + message);
        System.Environment.Exit(1);
      }
      errorCount++;
    } // IO.ReportError

    static public int ErrorCount() {
    // Returns number of errors detected on input
      return errorCount;
    } // IO.ErrorCount()

    static public bool Done() {
    // Simple error checking - reports result for last method called
      return okay;
    } // IO.Done()

    static public void ShowErrors() {
    // Allows user to switch error reporting on (off by default)
      printErrors = true;
    } // IO.ShowErrors()

    static public void HideErrors() {
    // Allows user to switch error reporting off (default setting)
      printErrors = false;
    }// IO.HideErrors

  } // class IO

  /////////////////////////////////////////////////////////////////////////////////////////

  public class InFile {   // 2015/06/18
  // Provide simple facilities for text input
  // P.D. Terry (p.terry@ru.ac.za)

    const char CR = '\r';
    const char LF = '\n';

    static bool okay = false;    // module-wide error flag for simplicity

    char savedChar;
    bool eof, eol, openFailure, inError, haveCh, noData, printErrors, fromDisk;
    int errorCount;
    string name;

    void Init(string fn) {
    // Called by all constructors to initialize hidden fields
      eof = eol = inError = haveCh = noData = openFailure = printErrors = false;
      okay = true;
      savedChar = '\0';
      errorCount = 0;
      name = fn;
      fromDisk = false;
    } // InFile.Init

    TextReader inReader;

    public static InFile StdIn = new InFile();

    // File opening and closing

    public InFile() {
    // Creates an InFile attached to StdIn
      Init("StdIn");
      inReader = Console.In;
    } // InFile.Infile

    public InFile(string fileName) {
    // Creates an InFile from named file
    // (reverts to StdIn if it fails)
      if (fileName != null) fileName = fileName.Trim();
      if (fileName != null && fileName == "") {
        Init("StdIn");
        inReader = Console.In;
      }
      else {
        Init(fileName); fromDisk = true;
        try {
          inReader = new StreamReader(new FileStream(fileName, FileMode.Open));
          Probe();
        }
        catch (Exception) {
          Console.WriteLine("InFile(" + fileName + ") failed - redirected to Console");
          inReader = Console.In;
          name = "StdIn"; openFailure = true; okay = false;
        }
      }
    } // InFile.Infile(name)

    public InFile(TextReader s, bool fromDisk) {
    // Creates an inFile from extant stream
    // (reverts to StdIn if it fails)
      Init("stream");
      if (s == null) {
        Console.Error.WriteLine("InFile(null) directed to Console");
        Init("StdIn");
        inReader = Console.In;
        openFailure = true; okay = false;
      } else {
        try {
          inReader = s; this.fromDisk = fromDisk;
          if (fromDisk) Probe();
        }
        catch (Exception) {
          Console.WriteLine(s + " not created");
          name = "StdIn";
          inReader = Console.In;
          openFailure = true;
          okay = false;
        }
      }
    } // InFile.InFile

    private void Probe() {
    // check for empty file
     try {
       int i = inReader.Read();
       if (i == -1) {
         eof = true; eol = true; haveCh = false;
       }
       else {
        haveCh = true; savedChar = (char) i;
        eol = i == CR || i == LF;
       }
      }
      catch (IOException) {
        Console.Error.WriteLine("Error reading " + name); System.Environment.Exit(1);
        /* fudge compiler fussiness! */
      }
    } // InFile.Probe


    public void Close() {
    // Closes this file
    // Unfortunately there seems no simple way to get the InFile to Close automagically
      if (inReader != Console.In) inReader.Close();
    } // InFile.Close

    // internal character and token readers

    char NextChar() {
    // Probe and retrieve next character from InFile
    // Note that CR+LF is mapped into LF only, and '\0' is returned if the end of
    // file is reached.  There is a one character buffer, to allow ReadAgain
    // to work, and to allow easy reading of strings and tokens, which have to
    // one character past their end.
    // It is an error to attempt to go past the end of file if it has already
    // been detected!
      char ch;
      if (haveCh) { ch = savedChar; okay = ch != '\0'; }
      else if (eof) { ch = '\0'; okay = false; }  // been there already
      else {                                      // get on with it
        int i = inReader.Read(); okay = true;
        if (i == CR) { i = inReader.Read(); }     // MS-DOS
        ch = (char) i;
        if (i == -1 || i == 26) { ch = '\0'; eof = true; }   // there was no character after all
      }
      savedChar = ch; haveCh = false;
      eol = eof || ch == LF;                      // eof also sets eol
      inError = ! okay;
      if (!okay && printErrors) {
        Console.Error.WriteLine("Attempt to read past eof" + (int) ch);
        System.Environment.Exit(1);
      }
      return ch;
    } // InFile.NextChar

    private string ReadToken() {
    // Internal version of ReadWord with no error reporting
      StringBuilder sb = new StringBuilder();
      char ch;
      SkipSpaces();
      if (eof) {
        noData = true; okay = false; inError = true;
        return " ";
      }
      ch = NextChar();
      while (ch > ' ') { sb.Append(ch); ch = NextChar(); }
      haveCh = true;
      return sb.ToString();
    } // InFile.ReadToken

    // Character based input

    public char ReadChar() {
    // Reads and returns a single character
      char ch = NextChar();
      noData = eof;
      if (noData) ReportError("ReadChar failed - no more data");
      return ch;
    } // InFile.ReadChar

    public void ReadAgain() {
    // Allows for a single character probe in code like
    // do ch = I.ReadChar(); while (notDigit(ch)); I.ReadAgain(); ...
      okay = true; haveCh = true;
    }

    public void SkipSpaces() {
    // Allows for the most elementary of lookahead probes
      char ch;
      do ch = NextChar(); while (ch <= ' ' && !eof);
      haveCh = true;
    } // InFile.SkipSpaces

    public void ReadLn() {
    // Consumes all character to end of line.
    // Then probe for non-interactive files in case it reached EOF
      if (eof && printErrors) {
        Console.Error.WriteLine("ReadLn attempting to read past eof");
        System.Environment.Exit(1);
      }
      while (!eol) ReadChar();
      haveCh = false; eol = false;
      if (fromDisk && !eof) {
        NextChar(); haveCh = true;
      }
    } // InFile.Readln

    // String based input

    public string ReadString() {
    // Reads and returns a string.  Incorporates leading white space,
    // and terminates on a control character, which is not
    // incorporated or consumed.
    // Note that this means you might need code like
    //       s = I.ReadString(); I.ReadLn();
    // (Alternatively use ReadLine() below )
      StringBuilder sb = new StringBuilder();
      char ch;
      if (eof) {
        noData = true; okay = false; inError = true;
        ReportError("ReadString failed - no more data");
        return "";
      }
      ch = NextChar();
      while (ch >= ' ') { sb.Append(ch); ch = NextChar(); }
      haveCh = true;
      return sb.ToString();
    } // InFile.ReadString

    public string ReadString(int max) {
    // Reads and returns a string.  Incorporates leading white space,
    // and terminates with a control character, which is not
    // incorporated or consumed, or when max characters have been read
    // (useful for fixed format data).  Note that this means you might
    // need code like s = l.ReadString(10); l.ReadLn();
      StringBuilder sb = new StringBuilder();
      char ch;
      if (eof) {
        noData = true; okay = false; inError = true;
        ReportError("ReadString failed - no more data");
        return "";
      }
      ch = NextChar();
      while (ch >= ' ' && max > 0) { sb.Append(ch); ch = NextChar(); max--; }
      haveCh = true;
      return sb.ToString();
    } // InFile.ReadString(max)

    public string ReadLine() {
    // Reads and returns a string.  Incorporates leading white space,
    // and terminates when EOL or EOF is reached.  The EOL character
    // is not incorporated, but is consumed.
      StringBuilder sb = new StringBuilder();
      char ch;
      if (eof) {
        noData = true; okay = false; inError = true;
        ReportError("ReadLine failed - No more data");
        return "";
      }
      ch = NextChar();
      while (!eol) { sb.Append(ch); ch = NextChar(); }
      haveCh = false;
      if (inReader != Console.In) {
        NextChar(); haveCh = true;
      }
      return sb.ToString();
    } // InFile.ReadLine

    public string ReadWord() {
    // Reads and returns a word - a string delimited at either end
    // by a control character or space (typically the latter).
    // Leading spaces are discarded, and the terminating character
    // is not consumed.
      StringBuilder sb = new StringBuilder();
      char ch;
      SkipSpaces();
      if (eof) {
        noData = true; okay = false; inError = true;
        ReportError("ReadWord failed - no more data");
        return "";
      }
      ch = NextChar();
      while (ch > ' ') { sb.Append(ch); ch = NextChar(); }
      haveCh = true;
      return sb.ToString();
    } // InFile.ReadWord

    // Numeric input routines.  These always return, even if the data
    // is incorrect.  Users may probe the status of the operation,
    // or use ShowErrors to get error messages.

    public int ReadInt(int radix) {
    // Reads a word as a textual representation of an integer (base radix)
    // and returns the corresponding value.
    // Errors may be reported or quietly ignored (when 0 is returned).
      string s = ReadToken();
      int n = 0;
      if (okay) {
        try {
          n = Convert.ToInt32(s, radix);
        }
        catch (Exception) {
          okay = false; n = 0; inError = true;
          ReportError("Bad Integer Format");
        }
      }
      else ReportError("ReadInt failed - no more data");
      return n;
    } // InFile.ReadInt(radix)

    public int ReadInt() {
    // Reads and returns a single integer (base 10)
      return ReadInt(10);
    } // InFile.ReadInt

    public long ReadLong(int radix) {
    // Reads a word as a textual representation of a long integer (base radix)
    // and returns the corresponding value.
    // Errors may be reported or quietly ignored (when 0 is returned).
      string s = ReadToken();
      long n = 0;
      if (okay) {
        try {
          n = Convert.ToInt64(s, radix);
        }
        catch (Exception) {
          okay = false; n = 0; inError = true;
          ReportError("Bad Long Integer Format");
        }
      }
      else ReportError("ReadLong failed - no more data");
      return n;
    } // InFile.Readlong(radix)

    public long ReadLong() {
    // Reads and returns a single long integer (base 10)
      return ReadLong(10);
    } // InFile.ReadLong

    public short ReadShort(int radix) {
    // Reads a word as a textual representation of a short integer (base radix)
    // and returns the corresponding value.
    // Errors may be reported or quietly ignored (when 0 is returned).
      string s = ReadToken();
      short n = 0;
      if (okay) {
        try {
          n = Convert.ToInt16(s, radix);
        }
        catch (Exception) {
          okay = false; n = 0; inError = true;
          ReportError("Bad Short Integer Format");
        }
      }
      else ReportError("ReadShort failed - no more data");
      return n;
    } // InFile.ReadShort9radix)

    public short ReadShort() {
    // Reads and returns a single short integer (base 10)
      return ReadShort(10);
    } // InFile.ReadShort

    public sbyte ReadSByte(int radix) {
    // Reads a word as a textual representation of a signed byte (base radix)
    // and returns the corresponding value.
    // Errors may be reported or quietly ignored (when 0 is returned).
      string s = ReadToken();
      sbyte n = 0;
      if (okay) {
        try {
          n = Convert.ToSByte(s, radix);
        }
        catch (Exception) {
          okay = false; n = 0; inError = true;
          ReportError("Bad SByte Format");
        }
      }
      else ReportError("ReadSByte failed - no more data");
      return n;
    } // InFile.ReadSByte(radix)

    public sbyte ReadSByte() {
    // Reads and returns a single signed byte (base 10)
      return ReadSByte(10);
    } // InFile.ReadSByte

    public byte ReadByte(int radix) {
    // Reads a word as a textual representation of an unsigned byte (base radix)
    // and returns the corresponding value.
    // Errors may be reported or quietly ignored (when 0 is returned).
      string s = ReadToken();
      byte n = 0;
      if (okay) {
        try {
          n = Convert.ToByte(s, radix);
        }
        catch (Exception) {
          okay = false; n = 0; inError = true;
          ReportError("Bad Byte Format");
        }
      }
      else ReportError("ReadByte failed - no more data");
      return n;
    } // InFile.ReadByte(radix)

    public byte ReadByte() {
    // Reads and returns a single unsigned byte (base 10)
      return ReadByte(10);
    } // InFile.ReadByte

    public float ReadFloat() {
    // Reads a word as a textual representation of a float
    // and returns the corresponding value.
    // Errors may be reported or quietly ignored (when 0 is returned).
      string s = ReadToken();
      float n = 0;
      if (okay) {
        try {
          n = Convert.ToSingle(s);
        }
        catch (Exception) {
          okay = false; n = 0; inError = true;
          ReportError("Bad Float Format");
        }
      }
      else ReportError("ReadFloat failed - no more data");
      return n;
    } // InFile.ReadFloat

    public double ReadDouble() {
    // Reads a word as a textual representation of a double
    // and returns the corresponding value.
    // Errors may be reported or quietly ignored (when 0 is returned).
      string s = ReadToken();
      double n = 0;
      if (okay) {
        try {
          n = Convert.ToDouble(s);
        }
        catch (Exception) {
          okay = false; n = 0; inError = true;
          ReportError("Bad Double Format");
        }
      }
      else ReportError("ReadDouble failed - no more data");
      return n;
    } // InFile.ReadDouble

    public bool ReadBool() {
    // Reads a word and returns a Boolean value, based on the
    // first letter.  Typically the word would be T(rue) or Y(es)
    // or F(alse) or N(o).
      string s = ReadToken();
      bool b = false;
      if (okay) {
        switch (char.ToUpper(s[0])) {
          case 'Y' : case 'T' : b = true; break;
          case 'N' : case 'F' : b = false; break;
          default : okay = false; b = false; inError = true;
                    ReportError("Bad Boolean Format"); break;
        }
      }
      else ReportError("ReadBool failed - no more data");
      return b;
    } // InFile.ReadBool

    // Utility "getters"

    public bool EOF() {
    // Returns true if the last operation terminated by reaching EOF
      return this.eof;
    } // InFile.EOF()

    public bool EOL() {
    // Returns true if the last operation terminated by reaching EOL
      return this.eol;
    } // InFile.EOL()

    public bool Error() {
    // Returns true if the last operation on this file failed
      return this.inError;
    }

    public bool NoMoreData() {
    // Returns true if the last operation on this file failed because
    // an attempt was made to read past the end of file
      return this.noData;
    } // InFile.NoMoreData

    public string FileName() {
    // Returns the file name for the file
      return this.name;
    } // InFile.Filename

    // Error handlers

    public bool OpenError() {
    // Returns true if the open operation on this file failed
      return this.openFailure;
    } // InFile.OpenError

    public void ReportError(string message) {
    // Possible simple error reporting (disabled by default)
      if (printErrors) Console.Error.WriteLine("--- " + name + " - " + message);
      errorCount++;
    } // InFile.ReportError

    public int ErrorCount() {
    // Returns number of errors detected on input
      return this.errorCount;
    } // InFile.ErrorCount

    public static bool Done() {
    // Simple error checking - reports result for last method called
    // regardless of which file was accessed
      return okay;
    } // InFile.Done

    public void ShowErrors() {
    // Allows user to switch error reporting on (off by default)
      printErrors = true;
    } // InFile.ShowErrors

    public void HideErrors() {
    // Allows user to switch error reporting off (default setting)
      printErrors = false;
    } // InFile.HideErrors

  } // InFile

  /////////////////////////////////////////////////////////////////////////////////////////

  public class OutFile {   // 2015/06/18
  // Provide simple facilities for text output
  // P.D. Terry (p.terry@ru.ac.za)

    public static OutFile StdOut = new OutFile(Console.Out);
    public static OutFile StdErr = new OutFile(Console.Error);

    bool openFailure;
    TextWriter outWriter;
    string fileName;

    static public void UseDefaultEncoding() {
    // Use default 8 bit PC Ascii character set on Console output
      Console.OutputEncoding = Encoding.Default;
    } // OutFile.UseDefaultEncoding

    // File opening and closing

    public OutFile() {
    // Creates an OutFile to StdOut
      outWriter = Console.Out;
      openFailure = false;
    } // OutFile.OutFile

    public OutFile(string fileName) {
    // Creates an OutFile to named disk file
    // (reverts to StdOut if it fails)
      openFailure = false;
      if (fileName != null) fileName = fileName.Trim();
      if (fileName != null && fileName == "")
        outWriter = Console.Out;
      else {
        try {
          outWriter = new StreamWriter(new FileStream(fileName, FileMode.Create), Encoding.Default);
          this.fileName = fileName;
        }
        catch (Exception) {
          Console.WriteLine("OutFile(" + fileName + ") failed - redirected to Console");
          outWriter = Console.Out;
          openFailure = true;
        }
      }
    } // OutFile.OutFile(name)

    public OutFile(TextWriter s) {
    // Creates an OutFile from extant stream
    // (reverts to StdOut if it fails)
      openFailure = false;
      if (s == null) {
        Console.Error.WriteLine("OutFile(null) directed to Console");
        openFailure = true;
        outWriter = Console.Out;
      } else {
        try {
          outWriter = s;
        }
        catch (Exception) {
          Console.Error.WriteLine(s + " not created - directed to Console");
          openFailure = true;
          outWriter = Console.Out;
        }
      }
    } // OutFile.OutFile(textreader)

    public void Close() {
    // Closes the file
    // Unfortunately there seems no simple way to get the OutFile to Close automagically
      outWriter.Close();
    } // OutFile.Close

    // The following methods mostly smply map the operations onto the hidden
    // TextWriter, and provide the standard functionality of that TextWriter

    public void Write(string s)                 { outWriter.Write(s); }
    public void Write(object o)                 { outWriter.Write(o); }
    public void Write(byte o)                   { Write(o, 0); }
    public void Write(sbyte o)                  { Write(o, 0); }
    public void Write(short o)                  { Write(o, 0); }
    public void Write(int o)                    { Write(o, 0); }
    public void Write(long o)                   { Write(o, 0); }
    public void Write(bool o)                   { Write(o, 0); }
    public void Write(float o)                  { Write(o, 0); }
    public void Write(double o)                 { Write(o, 0); }
    public void Write(char o)                   { outWriter.Write(o); }
    public void Write(char[] o)                 { outWriter.Write(o); }
    public void Write(char[] o, int off,
                      int len)                  { outWriter.Write(o, off, len); }

    public void WriteLine()                     { outWriter.WriteLine(); }
    public void WriteLine(string s)             { outWriter.WriteLine(s); }
    public void WriteLine(object o)             { outWriter.WriteLine(o); }
    public void WriteLine(byte o)               { WriteLine(o, 0); }
    public void WriteLine(sbyte o)              { WriteLine(o, 0); }
    public void WriteLine(short o)              { WriteLine(o, 0); }
    public void WriteLine(int o)                { WriteLine(o, 0); }
    public void WriteLine(long o)               { WriteLine(o, 0); }
    public void WriteLine(bool o)               { WriteLine(o, 0); }
    public void WriteLine(float o)              { WriteLine(o, 0); }
    public void WriteLine(double o)             { WriteLine(o, 0); }
    public void WriteLine(char o)               { outWriter.WriteLine(o); }
    public void WriteLine(char[] o)             { outWriter.WriteLine(o); }
    public void WriteLine(char[] o, int off,
                          int len)              { outWriter.Write(o, off, len); outWriter.WriteLine(); }

    private void PutStr(string s, int width) {
      if (width == 0) outWriter.Write(" " + s);
      else if (width > 0) {
        for (int i = s.Length; i < width; i++) outWriter.Write(' ');
        outWriter.Write(s);
      }
      else {
        outWriter.Write(s);
        for (int i = s.Length; i < -width; i++) outWriter.Write(' ');
      }
    } // OutFile.PutStr

    public void Write(string o, int width)      { PutStr(o, width); }
    public void Write(object o, int width)      { PutStr(o.ToString(), width); }
    public void Write(byte o,   int width)      { PutStr(o.ToString(), width); }
    public void Write(sbyte o,  int width)      { PutStr(o.ToString(), width); }
    public void Write(short o,  int width)      { PutStr(o.ToString(), width); }
    public void Write(int o,    int width)      { PutStr(o.ToString(), width); }
    public void Write(long o,   int width)      { PutStr(o.ToString(), width); }
    public void Write(bool o,   int width)      { PutStr(o.ToString(), width); }
    public void Write(float o,  int width)      { PutStr(o.ToString(), width); }
    public void Write(double o, int width)      { PutStr(o.ToString(), width); }
    public void Write(char o,   int width)      { PutStr(o.ToString(), width); }

    private void PutLine(string s, int width) {
      if (width == 0) outWriter.WriteLine(" " + s);
      else if (width > 0) {
        for (int i = s.Length; i < width; i++) outWriter.Write(' ');
        outWriter.WriteLine(s);
      }
      else {
        outWriter.Write(s);
        for (int i = s.Length; i < -width; i++) outWriter.Write(' ');
        outWriter.WriteLine();
      }
    } // OutFile.PutLine

    public void WriteLine(string o, int width)  { PutLine(o, width); }
    public void WriteLine(object o, int width)  { PutLine(o.ToString(), width); }
    public void WriteLine(byte o,   int width)  { PutLine(o.ToString(), width); }
    public void WriteLine(sbyte o,  int width)  { PutLine(o.ToString(), width); }
    public void WriteLine(short o,  int width)  { PutLine(o.ToString(), width); }
    public void WriteLine(int o,    int width)  { PutLine(o.ToString(), width); }
    public void WriteLine(long o,   int width)  { PutLine(o.ToString(), width); }
    public void WriteLine(bool o,   int width)  { PutLine(o.ToString(), width); }
    public void WriteLine(float o,  int width)  { PutLine(o.ToString(), width); }
    public void WriteLine(double o, int width)  { PutLine(o.ToString(), width); }
    public void WriteLine(char o,   int width)  { PutLine(o.ToString(), width); }

    // formatters

    public static string FixedRep(double d, int fractionDigits) {
      string fmt = "{0,0:F" + Math.Abs(fractionDigits).ToString() + "}";
      return string.Format(fmt, d);
    } // OutFile.FixedRep(d)

    public static string FixedRep(float f, int fractionDigits) {
      string fmt = "{0,0:F" + Math.Abs(fractionDigits).ToString() + "}";
      return string.Format(fmt, f);
    } // OutFile.FixedRep(f)

    public static string FloatingRep(double d, int fractionDigits) {
      string fmt = "{0,0:E" + Math.Abs(fractionDigits).ToString() + "}";
      return string.Format(fmt, d);
    } // OutFile.FloatingRep(d)

    public static string FloatingRep(float f, int fractionDigits) {
      string fmt = "{0,0:E" + Math.Abs(fractionDigits).ToString() + "}";
      return string.Format(fmt, f);
    } // OutFile.FloatingRep(f)

    public void WriteFixed(double d, int width, int fractionDigits) {
      if (width == 0) outWriter.Write(" ");
      string fmt = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      outWriter.Write(string.Format(fmt, d));
    } // OutFile.WriteFixed

    public void WriteLineFixed(double d, int width, int fractionDigits) {
      if (width == 0) outWriter.Write(" ");
      string fmt = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      outWriter.WriteLine(string.Format(fmt, d));
    } // OutFile.WriteLineFixed

    public void WriteFloating(double d, int width, int fractionDigits) {
      if (width == 0) outWriter.Write(" ");
      string fmt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      outWriter.Write(string.Format(fmt, d));
    } // OutFile.WriteFloating(d)

    public void WriteLineFloating(double d, int width, int fractionDigits) {
      if (width == 0) outWriter.Write(" ");
      string fmt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      outWriter.WriteLine(string.Format(fmt, d));
    } // OutFile.WriteLineFloating(d)

    public void Write(double d, int width, int fractionDigits) {
      if (width == 0) outWriter.Write(" ");
      string fix = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      string flt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      string sfx = string.Format(fix, d);
      string sfl = string.Format(flt, d);
      if (width == 0)
        if (sfx.Length <= sfl.Length) outWriter.Write(sfx); else outWriter.Write(sfl);
      else
        if (sfx.Length <= Math.Abs(width)) outWriter.Write(sfx); else outWriter.Write(sfl);
    } // OutFile.Write(d)

    public void WriteLine(double d, int width, int fractionDigits) {
      if (width == 0) outWriter.Write(" ");
      string fix = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      string flt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      string sfx = string.Format(fix, d);
      string sfl = string.Format(flt, d);
      if (width == 0)
        if (sfx.Length <= sfl.Length) outWriter.WriteLine(sfx); else outWriter.WriteLine(sfl);
      else
        if (sfx.Length <= Math.Abs(width)) outWriter.WriteLine(sfx); else outWriter.WriteLine(sfl);
    } // OutFile.WriteLine(d)

    public void WriteFixed(float f, int width, int fractionDigits) {
      if (width == 0) outWriter.Write(" ");
      string fmt = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      outWriter.Write(string.Format(fmt, f));
    } // OutFile.WriteFixed(f)

    public void WriteLineFixed(float f, int width, int fractionDigits) {
      if (width == 0) outWriter.Write(" ");
      string fmt = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      outWriter.WriteLine(string.Format(fmt, f));
    } // OutFile.WriteLineFixed(f)

    public void WriteFloating(float f, int width, int fractionDigits) {
      if (width == 0) outWriter.Write(" ");
      string fmt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      outWriter.Write(string.Format(fmt, f));
    } // OutFile.WriteFloating(f)

    public void WriteLineFloating(float f, int width, int fractionDigits) {
      if (width == 0) outWriter.Write(" ");
      string fmt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      outWriter.WriteLine(string.Format(fmt, f));
    } // OutFile.WriteLineFloating(f)

    public void Write(float f, int width, int fractionDigits) {
      if (width == 0) outWriter.Write(" ");
      string fix = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      string flt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      string sfx = string.Format(fix, f);
      string sfl = string.Format(flt, f);
      if (width == 0)
        if (sfx.Length <= sfl.Length) outWriter.Write(sfx); else outWriter.Write(sfl);
      else
        if (sfx.Length <= Math.Abs(width)) outWriter.Write(sfx); else outWriter.Write(sfl);
    } // OutFile.Write(f)

    public void WriteLine(float f, int width, int fractionDigits) {
      if (width == 0) outWriter.Write(" ");
      string fix = "{0," + width.ToString() + ":F" + Math.Abs(fractionDigits).ToString() + "}";
      string flt = "{0," + width.ToString() + ":E" + Math.Abs(fractionDigits).ToString() + "}";
      string sfx = string.Format(fix, f);
      string sfl = string.Format(flt, f);
      if (width == 0)
        if (sfx.Length <= sfl.Length) outWriter.WriteLine(sfx); else outWriter.WriteLine(sfl);
      else
        if (sfx.Length <= Math.Abs(width)) outWriter.WriteLine(sfx); else outWriter.WriteLine(sfl);
    } // OutFile.WriteLine(f)

    // Error handler

    public bool OpenError() {
    // Returns true if the open operation on this file failed
      return openFailure;
    } // OutFile.OpenError

  } // OutFile

  /////////////////////////////////////////////////////////////////////////////////////////

  public class IntSet {   // 2015/06/18
  // Simple set class for integers 0 <= i <= max
  // P.D. Terry (p.terry@ru.ac.za)
  // copy of SymSet - for compatibility with the new Java version

    const int Default = 512;      // default set size

    BitArray bitSet;

    private int max(int a, int b) {
      if (a > b) return a; else return b;
    } // IntSet.max

    private int min(int a, int b) {
      if (a < b) return a; else return b;
    } // IntSet.max

    private IntSet(int size) {
      this.bitSet = new BitArray(size);
    } // IntSet.Constructor(size)

    public IntSet() : this(Default) {}
    // Empty set constructor

    public IntSet(IntSet old) {
    // Construct set from old
      this.bitSet = new BitArray(old.bitSet);
    } // IntSet.Constructor

    private IntSet(BitArray b) {
      this.bitSet = b;
    } // IntSet.Constructor

    public IntSet(params int[] members) {
    // Variable args constructor  IntSet(a)  IntSet(a,b) etc
      int m = 0;
      foreach (int i in members) if (i > m) m = i;
      this.bitSet = new BitArray(max(Default, m + 1));
      foreach (int i in members) this.bitSet[i] = true;
    } // IntSet.Constructor, initialised

    private IntSet Expand(IntSet old, int newSize) {
      IntSet expandedSet = old.Copy();
      if (newSize > old.bitSet.Length) expandedSet.bitSet.Length = newSize;
      return expandedSet;
    } // IntSet.Expand

    public object Clone() {
    // Value copy
      return new IntSet(this);
    } // IntSet.Clone

    public IntSet Copy() {
    // Value copy
      return new IntSet(this);
    } // IntSet.Copy

    public bool Equals(IntSet that) {
    // Value comparison - sets contain same elements
      if (that == null) return false;
      int commonSize = max(this.bitSet.Length, that.bitSet.Length);
      IntSet one = Expand(this, commonSize);
      IntSet two = Expand(that, commonSize);
      for (int i = 0; i < commonSize; i++)  {
        if (one.bitSet[i] != two.bitSet[i]) return false;
      }
      return true;
    } // IntSet.Equals

    public void Incl(int i) {
    // Includes i in this set
      if (i >= 0) {
        if (i >= this.bitSet.Length) this.bitSet.Length = max(2 * this.bitSet.Length, i + 1);
        this.bitSet[i] = true;
      }
    } // IntSet.Incl

    public void Excl(int i) {
    // Excludes i from this set
      if (i >= 0 && i < this.bitSet.Length) this.bitSet[i] = false;
    } // IntSet.Excl

    public bool Contains(int i) {
    // Returns true if i is a member of this set
      return i >= 0 && i < this.bitSet.Length && this.bitSet[i];
    } // IntSet.Contains

    public bool Contains(IntSet that) {
    // Returns true if that is a subset of this set
      return that.IsEmpty() || that.Difference(this).IsEmpty();
    } // IntSet.Contains

    public bool IsEmpty() {
    // Returns true if this set is empty
      for (int i = 0; i < this.bitSet.Length; i++)
        if (this.bitSet[i]) return false;
      return true;
    } // IntSet.isEmpty

    public void Fill() {
    // Creates a full universe set
      for (int i = 0; i < this.bitSet.Length; i++) this.bitSet[i] = true;
    } // IntSet.Fill

    public int Members() {
    // Returns number of members in this set
      int count = 0;
      for (int i = 0; i < this.bitSet.Length; i++) if (this.bitSet[i]) count++;
      return count;
    } // IntSet.Members

    public IntSet Union(IntSet that) {
    // Set union
      int commonSize = max(this.bitSet.Length, that.bitSet.Length);
      IntSet one = Expand(this, commonSize);
      IntSet two = Expand(that, commonSize);
      return new IntSet(one.bitSet.Or(two.bitSet));
    } // IntSet.Union

  /*
    public IntSet Intersection(IntSet that) {
    // Set intersection
      int commonSize = max(this.bitSet.Length, that.bitSet.Length);
      IntSet one = Expand(this, commonSize);
      IntSet two = Expand(that, commonSize);
      return new IntSet(one.bitSet.And(two.bitSet));
    } // IntSet.intersection
  */

    public IntSet Intersection(IntSet that) {
    // Set intersection
      int minSize = min(this.bitSet.Length, that.bitSet.Length);
      IntSet one = new IntSet(minSize);
      for (int i = 0; i < minSize; i++) one.bitSet[i] = this.bitSet[i]  && that.bitSet[i];
      return one;
    } // IntSet.Intersection

  /*
    public IntSet Difference(IntSet that) {
    // Set difference
      int commonSize = max(this.bitSet.Length, that.bitSet.Length);
      IntSet one = Expand(this, commonSize);
      IntSet two = Expand(that, commonSize);
      for (int i = 0; i < commonSize; i++) one.bitSet[i] = one.bitSet[i]  && ! two.bitSet[i];
      return one;
    } // IntSet.Difference
  */

    public IntSet Difference(IntSet that) {
    // Set difference
      int minSize = min(this.bitSet.Length, that.bitSet.Length);
      IntSet one = this.Copy();
      for (int i = 0; i < minSize; i++) one.bitSet[i] = one.bitSet[i]  && ! that.bitSet[i];
      return one;
    } // IntSet.Difference

    public IntSet SymDiff(IntSet that) {
    // Set symmetric difference
      int commonSize = max(this.bitSet.Length, that.bitSet.Length);
      IntSet one = Expand(this, commonSize);
      IntSet two = Expand(that, commonSize);
      return new IntSet(one.bitSet.Xor(two.bitSet));
    } // IntSet.SymDiff

    public void Write() {
    // Simple display of this set on StdOut
      Console.Write(this);
    } // IntSet.Write

    public override string ToString() {
    // Returns string representation of this set
      StringBuilder sb = new StringBuilder(1000);
      sb.Append('{');
      int last = 0;
      for (int i = 0; i < this.bitSet.Length; i++) if (this.bitSet[i]) last = i;
      for (int i = 0; i <= last; i++)
        if (this.bitSet[i]) {
          sb.Append(i.ToString()); if (i < last) sb.Append(", ");
        }
      sb.Append("}");
      return sb.ToString();
    } // IntSet.ToString

  } // IntSet

  /////////////////////////////////////////////////////////////////////////////////////////

  public class SymSet {   // 2015/06/18
  // Simple set class for integers 0 <= i <= max
  // P.D. Terry (p.terry@ru.ac.za)
  // copy of IntSet - for compatibility with the new Java version

    const int Default = 512;      // default set size

    BitArray bitSet;

    private int max(int a, int b) {
      if (a > b) return a; else return b;
    } // SymSet.max

    private int min(int a, int b) {
      if (a < b) return a; else return b;
    } // SymSet.max

    private SymSet(int size) {
      this.bitSet = new BitArray(size);
    }

    public SymSet() : this(Default) {}
    // Empty set constructor

    public SymSet(SymSet old) {
    // Construct set from old
      this.bitSet = new BitArray(old.bitSet);
    }

    private SymSet(BitArray b) {
      this.bitSet = b;
    }

    public SymSet(params int[] members) {
    // Variable args constructor  SymSet(a)  SymSet(a,b) etc
      int m = 0;
      foreach (int i in members) if (i > m) m = i;
      this.bitSet = new BitArray(max(Default, m + 1));
      foreach (int i in members) this.bitSet[i] = true;
    } // Constructor(initialised)

    private SymSet Expand(SymSet old, int newSize) {
      SymSet expandedSet = old.Copy();
      if (newSize > old.bitSet.Length) expandedSet.bitSet.Length = newSize;
      return expandedSet;
    } // SymSet.Expand

    public object Clone() {
    // Value copy
      return new SymSet(this);
    } // SymSet.Clone

    public SymSet Copy() {
    // Value copy
      return new SymSet(this);
    } // SymSet.copy

    public bool Equals(SymSet that) {
    // Value comparison - sets contain same elements
      if (that == null) return false;
      int commonSize = max(this.bitSet.Length, that.bitSet.Length);
      SymSet one = Expand(this, commonSize);
      SymSet two = Expand(that, commonSize);
      for (int i = 0; i < commonSize; i++)  {
        if (one.bitSet[i] != two.bitSet[i]) return false;
      }
      return true;
    } // SymSet.Equals

    public void Incl(int i) {
    // Includes i in this set
      if (i >= 0) {
        if (i >= this.bitSet.Length) this.bitSet.Length = max(2 * this.bitSet.Length, i + 1);
        this.bitSet[i] = true;
      }
    } // SymSet.Incl

    public void Excl(int i) {
    // Excludes i from this set
      if (i >= 0 && i < this.bitSet.Length) this.bitSet[i] = false;
    } // SymSet.Excl

    public bool Contains(int i) {
    // Returns true if i is a member of this set
      return i >= 0 && i < this.bitSet.Length && this.bitSet[i];
    } // SymSet.Contains

    public bool Contains(SymSet that) {
    // Returns true if that is a subset of this set
      return that.IsEmpty() || that.Difference(this).IsEmpty();
    } // SymSet.Contains

    public bool IsEmpty() {
    // Returns true if this set is empty
      for (int i = 0; i < this.bitSet.Length; i++)
        if (this.bitSet[i]) return false;
      return true;
    } // SymSet.isEmpty

    public void Fill() {
    // Creates a full universe set
      for (int i = 0; i < this.bitSet.Length; i++) this.bitSet[i] = true;
    } // SymSet.Fill

    public int Members() {
    // Returns number of members in this set
      int count = 0;
      for (int i = 0; i < this.bitSet.Length; i++) if (this.bitSet[i]) count++;
      return count;
    } // SymSet.Members

    public SymSet Union(SymSet that) {
    // Set union
      int commonSize = max(this.bitSet.Length, that.bitSet.Length);
      SymSet one = Expand(this, commonSize);
      SymSet two = Expand(that, commonSize);
      return new SymSet(one.bitSet.Or(two.bitSet));
    } // SymSet.Union

  /*
    public SymSet Intersection(SymSet that) {
    // Set intersection
      int commonSize = max(this.bitSet.Length, that.bitSet.Length);
      SymSet one = Expand(this, commonSize);
      SymSet two = Expand(that, commonSize);
      return new SymSet(one.bitSet.And(two.bitSet));
    } // SymSet.intersection
  */

    public SymSet Intersection(SymSet that) {
    // Set intersection
      int minSize = min(this.bitSet.Length, that.bitSet.Length);
      SymSet one = new SymSet(minSize);
      for (int i = 0; i < minSize; i++) one.bitSet[i] = this.bitSet[i]  && that.bitSet[i];
      return one;
    } // SymSet.Intersection

  /*
    public SymSet Difference(SymSet that) {
    // Set difference
      int commonSize = max(this.bitSet.Length, that.bitSet.Length);
      SymSet one = Expand(this, commonSize);
      SymSet two = Expand(that, commonSize);
      for (int i = 0; i < commonSize; i++) one.bitSet[i] = one.bitSet[i]  && ! two.bitSet[i];
      return one;
    } // SymSet.Difference
  */

    public SymSet Difference(SymSet that) {
    // Set difference
      int minSize = min(this.bitSet.Length, that.bitSet.Length);
      SymSet one = this.Copy();
      for (int i = 0; i < minSize; i++) one.bitSet[i] = one.bitSet[i]  && ! that.bitSet[i];
      return one;
    } // SymSet.Difference

    public SymSet SymDiff(SymSet that) {
    // Set symmetric difference
      int commonSize = max(this.bitSet.Length, that.bitSet.Length);
      SymSet one = Expand(this, commonSize);
      SymSet two = Expand(that, commonSize);
      return new SymSet(one.bitSet.Xor(two.bitSet));
    } // SymSet.SymDiff

    public void Write() {
    // Simple display of this set on StdOut
      Console.Write(this);
    } // SymSet.Write

    public override string ToString() {
    // Returns string representation of this set
      StringBuilder sb = new StringBuilder(1000);
      sb.Append('{');
      int last = 0;
      for (int i = 0; i < this.bitSet.Length; i++) if (this.bitSet[i]) last = i;
      for (int i = 0; i <= last; i++)
        if (this.bitSet[i]) {
          sb.Append(i.ToString()); if (i < last) sb.Append(", ");
        }
      sb.Append("}");
      return sb.ToString();
    } // SymSet.ToString

  } // SymSet.

  /////////////////////////////////////////////////////////////////////////////////////////

  public class Screen {   // 2015/06/18
  // Basic addressed screen operations
  // P.D. Terry (p.terry@ru.ac.za), Rhodes University

    static int
      oldWidth   = 80,
      oldHeight  = 25;
    static ConsoleColor
      oldFGColor = ConsoleColor.White,
      oldBGColor = ConsoleColor.Black;

    public static void UseDefaultEncoding() {
    // Use default 8 bit PC Ascii character set on Console output
      Console.OutputEncoding = Encoding.Default;
    } // Screen.UseDefaultEncoding

    public static void SaveWindow() {
      oldWidth    = Console.WindowWidth;
      oldHeight   = Console.WindowHeight;
      oldFGColor  = Console.ForegroundColor;
      oldBGColor  = Console.BackgroundColor;
    } // Screen.SaveWindow

    public static void RestoreWindow() {
      Console.SetWindowSize(oldWidth, oldHeight);
      Console.ForegroundColor = oldFGColor;
      Console.BackgroundColor = oldBGColor;
    } // Screen.RestoreWindow

    public static void SetWindowSize(int width, int height) {
      Console.SetWindowSize(width, height);
    } // Screen.SetWindowSize

    public static void GoToXY(int x, int y) {
      Console.SetCursorPosition(x - 1, y - 1);
    } // Screen.GoToXY

    public static void ClrScr() {
      Console.Clear();
    } // Screen.ClrScr

    public static void ClrEOL() {
      int posX = Console.CursorLeft, posY = Console.CursorTop;
      for (int x = Console.CursorLeft; x < Console.WindowWidth; x++) Console.Write(' ');
      Console.SetCursorPosition(posX, posY);
    } // ClrEOL

    public static void ClrEOS() {
      int posX = Console.CursorLeft, posY =  Console.CursorTop;
      for (int x = Console.CursorLeft; x < Console.WindowWidth; x++) Console.Write(' ');
      for (int y = posY + 1 ; y < Console.WindowHeight - 1; y++)  {
        Console.SetCursorPosition(0 , y);
        for (int x = 0; x < Console.WindowWidth; x++) Console.Write(' ');
      }
      Console.MoveBufferArea(0, Console.WindowHeight - 2, Console.WindowWidth, 1, 0, Console.WindowHeight - 1);
      Console.SetCursorPosition(posX, posY);
    } // ClrEOS

    public static char ReadKey() {
      ConsoleKeyInfo cki = Console.ReadKey();
      return cki.Key.ToString()[0];
    } // Screen.ReadKey

    public static void TextColor(int c) {
      Console.ForegroundColor = (ConsoleColor) (c % 16);
    } // Screen.TextColor

    public static void DefaultColor() {
      Console.ResetColor();
    } // Screen.DefaultColor

    public static void BackgroundColor(int c) {
      Console.BackgroundColor = (ConsoleColor) (c %16);
    } // Screen.BackgroundColor

  } // Screen

} // namespace

