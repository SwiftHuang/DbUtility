//
// Copyright (c) 2004-2005, O&O Services GmbH.
// Am Borsigturm 48
// 13507 Berlin
// GERMANY
// Tel: +49 30 43 03 43-03, Fax: +49 30 43 03 43-99
// E-mail: info@oo-services.com
// Web: http://www.oo-services.com
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions are met:
//
// * Redistributions of source code must retain the above copyright notice, 
//   this list of conditions and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright notice, 
//   this list of conditions and the following disclaimer in the documentation 
//   and/or other materials provided with the distribution.
// * Neither the name of O&O Services GmbH nor the names of its contributors 
//   may be used to endorse or promote products derived from this software
//   without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, 
// EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, 
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; 
// OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR 
// OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, 
// EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Runtime.CompilerServices;
using log4net;
using log4net.Config;

[assembly: CLSCompliant(true)]
[assembly: FileIOPermission(SecurityAction.RequestMinimum)]

namespace Test.Pdf
{
    /// <summary>
    /// Abstract base class for all PDF Objects.
    /// </summary>
    [CLSCompliant(true)]
    abstract public class PdfObject
    {
        private static readonly Regex boolRegex = new Regex(@"^((true)|(false))", RegexOptions.Singleline);
        private static readonly Regex nameRegex = new Regex(@"^(/[^\s()<>{}/%[\]]+)", RegexOptions.Singleline);
        private static readonly Regex stringRegex = new Regex(@"^(<|\()", RegexOptions.Singleline);
        private static readonly Regex arrayRegex = new Regex(@"^\[", RegexOptions.Singleline);
        private static readonly Regex nullRegex = new Regex(@"^null", RegexOptions.Singleline);
        private static readonly Regex referenceRegex = new Regex(@"^(\d+)\s+(\d+)\s+R", RegexOptions.Singleline);
        private static readonly Regex dictionaryRegex = new Regex(@"^<<", RegexOptions.Singleline);
        private static readonly Regex numberRegex = new Regex(@"^((-|\+)?\d*\.?\d*)", RegexOptions.Singleline);
        private static readonly Regex commentRegex = new Regex(@"^%([^\u000a\u000d]*)", RegexOptions.Singleline);

        private static readonly ILog log = LogManager.GetLogger(typeof(PdfObject));

        /// <summary>
        /// Factory method for PdfObjects. 
        /// Tries to parse a given input string into a new instance of PdfObject.
        /// </summary>
        /// <param name="input">The input string to be parsed. Will be consumed.</param>
        /// <returns>A PdfObject on success, null otherwise.</returns>
        public static PdfObject GetPdfObject(ref string input)
        {
            Match match;

            input = input.TrimStart(null); // remove white space from the start

            if (input.StartsWith("true"))
            {
                input = input.Substring(4);
                log.Info("Parsing PdfBool (true)");
                return new PdfBool(true);
            }
            else if (input.StartsWith("false"))
            {
                input = input.Substring(5);
                log.Info("Parsing PdfBool (false)");
                return new PdfBool(false);
            }
            if (input.StartsWith("/") && (match = nameRegex.Match(input)).Success)
            {
                input = input.Substring(match.Index + match.Length);
                log.Info("Parsing PdfName (" + match.Groups[1].Value + ")");
                return new PdfName(match.Groups[1].Value);
            }
            if (input.StartsWith("<<"))
            {
                input = input.Substring(2);
                log.Info("Parsing PdfDictionary");
                return new PdfDictionary(ref input);
            }
            if (input.Length > 0 && (input[0] == '<' || input[0] == '('))
            {
                bool hex = input[0] == '<';
                input = input.Substring(1);
                log.Info("Parsing PdfString (hex = " + hex + ")");
                return new PdfString(hex, ref input);
            }
            if (input.StartsWith("["))
            {
                input = input.Substring(1);
                log.Info("Parsing PdfArray");
                return new PdfArray(ref input);
            }
            if (input.StartsWith("null"))
            {
                input = input.Substring(4);
                log.Info("Parsing PdfNull");
                return new PdfNull();
            }
            match = referenceRegex.Match(input);
            if (match.Success)
            {
                input = input.Substring(match.Index + match.Length);
                int objNumber = Int32.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                int generationNumber = Int32.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
                log.Info(string.Format(CultureInfo.InvariantCulture, "Parsing PdfReference ({0}, {1})", objNumber, generationNumber));
                return new PdfReference(objNumber, generationNumber);
            }
            match = numberRegex.Match(input);
            if (match.Success)
            {
                input = input.Substring(match.Index + match.Length);
                log.Info("Parsing PdfNumber (" + match.Groups[1].Value + ")");
                return new PdfNumber(match.Groups[1].Value);
            }

            PdfObject comment = ParseComment(ref input);
            if (comment != null)
            {
                log.Info("Parsing PdfComment");
                return comment;
            }

            throw new Exception("unable to parse '" + input + "'");
        }

        /// <summary>
        /// Tries to parse a PDF comment from the input string.
        /// </summary>
        /// <param name="input">The input string to be parsed. Will be consumed.</param>
        /// <returns>A PdfComment object on success, null otherwise.</returns>
        public static PdfComment ParseComment(ref string input)
        {
            Match match;

            match = commentRegex.Match(input);

            if (match.Success)
            {
                input = input.Substring(match.Index + match.Length);
                return new PdfComment(match.Groups[1].Value);
            }
            else
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Represents a PDF Comment. See the PDF Reference 3.1.2 Comments.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfComment : PdfObject
    {
        private string comment;

        /// <summary>
        /// Initializes a new instance of PdfComment.
        /// </summary>
        /// <param name="comment">The comment from which to initialize the object (without the leading '%' character and the trailing newline).</param>
        public PdfComment(string comment)
        {
            this.comment = comment;
        }

        /// <summary>
        /// Returns the string representation of the PdfComment object.
        /// </summary>
        /// <returns>The string representation of the PdfComment object.</returns>
        public override string ToString()
        {
            return "%" + Comment + "\n";
        }

        /// <summary>
        /// Gets or sets the value of this PdfComment object.
        /// </summary>
        public string Comment
        {
            get
            {
                return comment;
            }

            set
            {
                comment = value;
            }
        }
    }

    /// <summary>
    /// Represents a PDF Numeric object. See the PDF Reference 3.2.2 Numeric Objects.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfNumber : PdfObject
    {
        private double number = 0.0;
        private static readonly NumberFormatInfo numberFormat = new CultureInfo("en-US").NumberFormat;

        /// <summary>
        /// Initializes a new instance of PdfNumber.
        /// </summary>
        /// <param name="num">The string from which to parse the PdfNumber</param>
        public PdfNumber(string num)
        {
            number = Double.Parse(num, numberFormat);
        }

        /// <summary>
        /// Initializes a new instance of PdfNumber.
        /// </summary>
        /// <param name="num">The number from which to initialize the PdfNumber.</param>
        public PdfNumber(double num)
        {
            number = num;
        }

        /// <summary>
        /// Returns the string representation of the PdfNumber object.
        /// </summary>
        /// <returns>The string representation of the PdfNumber object.</returns>
        public override string ToString()
        {
            return number.ToString(numberFormat);
        }

        /// <summary>
        /// Gets or sets the value of this PdfNumber object.
        /// </summary>
        public double Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }
    }

    /// <summary>
    /// Represents a PDF Dictionary object. See the PDF Reference 3.2.6 Dictionary Objects.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfDictionary : PdfObject
    {
        private Hashtable dictionary = new Hashtable();
        private static readonly Regex endRegex = new Regex(@"^>>", RegexOptions.Singleline);
        private static readonly Regex keyRegex = new Regex(@"^(/[^\s()<>{}/%[\]]+)", RegexOptions.Singleline);

        /// <summary>
        /// Initializes a new instance of PdfDictionary.
        /// </summary>
        /// <param name="input">The input string from which to parse the PdfDictionary.
        /// Must not contain the leading "&lt;&lt;". Must contain the trailing "&gt;&gt;". 
        /// Consumes the PdfDictionary from the input.</param>
        public PdfDictionary(ref string input)
        {
            bool match;

            input = input.TrimStart(null);
            for (match = input.StartsWith(">>"); !match && input.Length > 0; match = input.StartsWith(">>"))
            {
                Match keyMatch = keyRegex.Match(input);
                if (keyMatch.Success)
                {
                    input = input.Substring(keyMatch.Index + keyMatch.Length);
                    dictionary.Add(new PdfName(keyMatch.Groups[1].Value), PdfObject.GetPdfObject(ref input));
                }
                else if (ParseComment(ref input) == null) // maybe there is a comment
                {
                    throw new Exception("cannot parse PDF dictionary from '" + input + "'");
                }

                input = input.TrimStart(null);
            }

            if (match)
            {
                input = input.Substring(2);
            }
        }

        /// <summary>
        /// Initializes a new PdfDictionary object.
        /// </summary>
        /// <param name="dictionary">The Hashtable from which to initialize the PdfDictionary.</param>
        public PdfDictionary(Hashtable dictionary)
        {
            this.dictionary = dictionary;
        }

        /// <summary>
        /// Gets the Hashtable for the PdfDictionary.
        /// </summary>
        public Hashtable Dictionary
        {
            get
            {
                return dictionary;
            }
        }

        /// <summary>
        /// Returns the string representation of this PdfDictionary.
        /// </summary>
        /// <returns>The string representation of this PdfDictionary.</returns>
        public override string ToString()
        {
            string s = "<<\n";
            foreach (PdfName key in Dictionary.Keys)
            {
                s += key + " " + Dictionary[key] + "\n";
            }
            s += " >>";
            return s;
        }

        /// <summary>
        /// Sets an element in the PDF dictionary to the specified value.
        /// </summary>
        /// <remarks>
        /// If there is no element with the specified key in the dictionary, it will be added.
        /// </remarks>
        /// <param name="key">The key.</param>
        /// <param name="objValue">The value.</param>
        public void SetElement(PdfName key, PdfObject objValue)
        {
            if (Dictionary.ContainsKey(key))
            {
                Dictionary[key] = objValue;
            }
            else
            {
                Dictionary.Add(key, objValue);
            }
        }

        /// <summary>
        /// Returns the value in the PdfDictionary for the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>A PdfObject or null if there is no value in the PdfDictionary with the specified key.</returns>
        public PdfObject GetElement(PdfName key)
        {
            if (Dictionary.ContainsKey(key))
            {
                return (PdfObject)Dictionary[key];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Indexer for the PdfDictionary.
        /// </summary>
        public PdfObject this[string key]
        {
            get
            {
                return GetElement(new PdfName(key));
            }

            set
            {
                SetElement(new PdfName(key), value);
            }
        }
    }

    /// <summary>
    /// Represents a PDF Reference object. See the PDF Reference 3.2.9 Indirect Objects.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfReference : PdfObject
    {
        private int objNumber;
        private int generationNumber;

        /// <summary>
        /// Initializes a new PdfReference object.
        /// </summary>
        /// <param name="objNumber">The object number.</param>
        /// <param name="generationNumber">The generation number.</param>
        public PdfReference(int objNumber, int generationNumber)
        {
            this.objNumber = objNumber;
            this.generationNumber = generationNumber;
        }

        /// <summary>
        /// Returns the string representation of this object.
        /// </summary>
        /// <returns>"o g R" where o is the object number and g is the generation number.</returns>
        public override string ToString()
        {
            return objNumber.ToString(CultureInfo.InvariantCulture) + " " + generationNumber + " R";
        }

        /// <summary>
        /// Gets or sets a value indicating the object number.
        /// </summary>
        public int ObjectNumber
        {
            get
            {
                return objNumber;
            }

            set
            {
                objNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the generation number.
        /// </summary>
        public int GenerationNumber
        {
            get
            {
                return generationNumber;
            }

            set
            {
                generationNumber = value;
            }
        }
    }

    /// <summary>
    /// Represents a PDF Null object. See the PDF Reference 3.2.8 Null Object.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfNull : PdfObject
    {
        /// <summary>
        /// Returns "null".
        /// </summary>
        /// <returns>The string "null".</returns>
        public override string ToString()
        {
            return "null";
        }
    }

    /// <summary>
    /// Represents a PDF Array object. See the PDF Reference 3.2.5 Array Objects.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfArray : PdfObject
    {
        private ArrayList array = new ArrayList();
        private static readonly Regex endRegex = new Regex(@"^\s*\]", RegexOptions.Singleline);

        /// <summary>
        /// Initializes a new PdfArray object.
        /// </summary>
        /// <param name="input">The input string to be parsed. 
        /// Must not contain the leading '['. Must contain the trailing ']'. 
        /// The PdfArray is consumed from the input.</param>
        public PdfArray(ref string input)
        {
            bool match;

            input = input.TrimStart(null);
            for (match = input.StartsWith("]"); !match && input.Length > 0; match = input.StartsWith("]"))
            {
                array.Add(PdfObject.GetPdfObject(ref input));
                input = input.TrimStart(null);
            }

            if (match)
            {
                input = input.Substring(1);
            }
        }

        /// <summary>
        /// Initializes a new PdfArray object.
        /// </summary>
        /// <param name="items">The array of PdfObjects from which to construct the new PdfArray.</param>
        public PdfArray(params PdfObject[] items)
        {
            if (items != null)
            {
                array.AddRange(items);
            }
        }

        /// <summary>
        /// Returns the string representation of this object.
        /// </summary>
        /// <returns>The string representation of this object.</returns>
        public override string ToString()
        {
            string s = "[ ";

            foreach (PdfObject element in array)
            {
                s += element.ToString() + " ";
            }

            s += "]";

            return s;
        }

        /// <summary>
        /// Gets the elements of the PdfArray.
        /// </summary>
        /// <value>The elements of the PdfArray.</value>
        public ArrayList Elements
        {
            get
            {
                return array;
            }
        }

        /// <summary>
        /// Indexer for the PdfArray.
        /// </summary>
        public PdfObject this[int index]
        {
            get
            {
                return (PdfObject)array[index];
            }

            set
            {
                array[index] = value;
            }
        }
    }

    /// <summary>
    /// Represents a PDF String object. See the PDF Reference 3.2.3 String Objects.
    /// </summary>
    /// <remarks>
    /// This implementation can parse PDF Strings in either literal or hexadecimal form.
    /// It writes strings always in literal form.
    /// Unicode (UTF-16) Encoding is supported, bytes in PdfDocEncoding are interpreted as Unicode.
    /// Language detection is not supported.
    /// </remarks>
    [CLSCompliant(true)]
    public class PdfString : PdfObject
    {
        private string s = "";
        private static readonly Regex hexRegex = new Regex(@"^([^>]+)>", RegexOptions.Singleline);
        private static readonly Regex octRegex = new Regex(@"^([0-7]{3})", RegexOptions.Singleline);
        private static readonly Regex wsRegex = new Regex(@"\s+", RegexOptions.Singleline);
        private static readonly Encoding encoding = new UnicodeEncoding(true, true);

        /// <summary>
        /// Initializes a new instance of PdfString.
        /// </summary>
        /// <param name="hex">Is this string in hexadecimal form?</param>
        /// <param name="input">The string to be parsed into a PdfString object. Must not include the leading '('.
        /// Must include the trailing ')'. Consumes the PDF String object from the input.
        /// </param>
        public PdfString(bool hex, ref string input)
        {
            if (hex)
            {
                Match hexMatch = hexRegex.Match(input);

                if (!hexMatch.Success)
                {
                    throw new Exception("Cannot parse hexadecimal string at '" + input + "'");
                }

                string hexString = hexMatch.Groups[1].Value;
                hexString = wsRegex.Replace(hexString, "");
                input = input.Substring(hexMatch.Index + hexMatch.Length);
                if ((hexString.Length & 1) == 1) // odd number of characters, append 0 according to PDF spec
                {
                    hexString += "0";
                }

                byte[] hexBytes = new byte[hexString.Length / 2];
                for (int i = 0; i < hexString.Length; i += 2)
                {
                    byte b = Byte.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                    hexBytes[i / 2] = b;
                }

                if (hexBytes.Length >= 2 && hexBytes[0] == 0xfe && hexBytes[1] == 0xff) // utf16 encoding
                {
                    s = encoding.GetString(hexBytes, 2, hexBytes.Length - 2);
                }
                else
                {
                    char[] chars = new char[hexBytes.Length];

                    for (int i = 0; i < hexBytes.Length; i++)
                    {
                        chars[i] = (char)hexBytes[i];
                    }

                    s = new String(chars);
                }
            }
            else
            {
                int nestLevel = 1;
                bool unicode = input.Length >= 2
                    && ((input[0] == (char)0xfe && input[1] == (char)0xff)
                        || input.StartsWith("\\376\\377"));

                if (unicode) // strip byte-order marker
                {
                    input = input.Substring(input[0] == '\\' ? 8 : 2);
                }

                while (nestLevel > 0 && input.Length > 0)
                {
                    if (input[0] == ')' && nestLevel == 1)
                    {
                        nestLevel = 0;
                        input = input.Substring(1);
                        break;
                    }

                    string currentChars = GetNextChar(ref input, unicode);
                    if (currentChars.Equals(""))
                    {
                        continue;
                    }
                    char currentChar = currentChars[0];

                    if (currentChar == '(')
                    {
                        nestLevel++;
                    }
                    else if (currentChar == ')')
                    {
                        nestLevel--;
                    }

                    if (currentChar == '\\' && currentChars.Length == 2) // can only be "\(" or "\)"
                    {
                        currentChar = currentChars[1];
                    }

                    s += currentChar;
                }
            }
        }

        /// <summary>
        /// Initializes a new PdfString object.
        /// </summary>
        /// <param name="s">A string from which to initialize the PdfString object.</param>
        public PdfString(string s)
        {
            this.s = s;
        }

        private string GetNextInputChar(ref string input)
        {
            int len = 1;
            char currentChar = input[0];
            char nextCharacter = input[1];
            string returnChar = "";

            if (input.Length >= 2
                && currentChar == '\\')
            {
                len += 1; // strip the \

                switch (nextCharacter)
                {
                    case ')':
                    case '(':
                    case '\\':
                        returnChar += "\\" + nextCharacter;
                        break;
                    case 'n':
                        returnChar += '\n';
                        break;
                    case 'r':
                        returnChar += '\r';
                        break;
                    case 't':
                        returnChar += '\t';
                        break;
                    case 'b':
                        returnChar += '\b';
                        break;
                    case 'f':
                        returnChar += '\f';
                        break;
                }

                Match octMatch = octRegex.Match(input.Substring(1));
                if (octMatch.Success)
                {
                    len += 2; // strip two more characters from input
                    int num = Convert.ToInt32(octMatch.Groups[1].Value, 8);
                    returnChar += (char)num;
                }
            }
            else if (input.Length >= 2
                && (currentChar == '\n' || currentChar == '\r'))
            {
                returnChar += "\n";
                if (nextCharacter == '\n' || nextCharacter == '\r') // two-byte line ending
                {
                    len += 1;
                }
            }
            else
            {
                returnChar += currentChar;
            }

            input = input.Substring(len);

            return returnChar;
        }

        private string GetNextChar(ref string input, bool unicode)
        {
            string nextCharacter = GetNextInputChar(ref input);
            if (nextCharacter.Equals(""))
            {
                return "";
            }

            if (unicode)
            {
                try
                {
                    string c2s;
                    do
                    {
                        c2s = GetNextInputChar(ref input);
                    }
                    while (c2s.Equals(""));
                    char c2 = c2s[0];
                    nextCharacter = "" + encoding.GetChars(new byte[] { (byte)nextCharacter[0], (byte)c2 }, 0, 2)[0];
                }
                catch (Exception ex)
                {
                    throw new Exception("error parsing unicode string", ex);
                }
            }

            return nextCharacter;
        }

        /// <summary>
        /// Returns the PdfString as a string.
        /// </summary>
        public string Text
        {
            get
            {
                return s;
            }

            set
            {
                s = value;
            }
        }

        /// <summary>
        /// Returns the encoded representation of the PdfString object. Automatically chooses Unicode or PdfDocEncoding.
        /// Returned string is always in literal format.
        /// </summary>
        /// <returns>The encoded string.</returns>
        public override string ToString()
        {
            string output = s.Replace("(", "\\(");
            output = output.Replace(")", "\\)");

            bool unicode = false;
            foreach (char c in output.ToCharArray())
            {
                if ((UInt16)c > 255)
                {
                    unicode = true;
                    break;
                }
            }

            if (unicode)
            {
                string str = "(" + (char)0xfe + (char)0xff;
                byte[] bytes = encoding.GetBytes(output);
                foreach (byte b in bytes)
                {
                    str += (char)b;
                }
                str += ")";
                return str;
            }
            else
            {
                return "(" + output + ")";
            }
        }
    }

    /// <summary>
    /// Represents a PDF Name object. See the PDF Reference 3.2.4 Name Objects.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfName : PdfObject
    {
        private string name;
        private static readonly Regex hexRegex = new Regex(@"#([A-Fa-f0-9]{2})", RegexOptions.Singleline);
        private static readonly Regex specialRegex = new Regex(@"[\x00-\x20\x7f-\xff\s/%\(\)<>\{\}\[\]#]", RegexOptions.Singleline); // PDF special characters, to be encoded as #xx

        private string HexMatchEvaluator(Match match)
        {
            byte b = Byte.Parse(match.Groups[1].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            return "" + (char)b;
        }

        private string SpecialMatchEvaluator(Match match)
        {
            byte b = (byte)match.Groups[0].Value[0];
            return "#" + b.ToString("x2", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Initializes a new PdfName instance.
        /// </summary>
        /// <param name="name">The string to be parsed into a PdfName, e.g. "/AP".</param>
        public PdfName(string name)
        {
            if (!name.StartsWith("/"))
            {
                throw new Exception("PdfName does not start with '/': '" + name + "'");
            }
            this.name = hexRegex.Replace(name.Substring(1), new MatchEvaluator(HexMatchEvaluator));
        }

        /// <summary>
        /// Returns the string representation of this object.
        /// </summary>
        /// <returns>The string representation of this object.</returns>
        public override string ToString()
        {
            return "/" + specialRegex.Replace(name, new MatchEvaluator(SpecialMatchEvaluator));
        }

        /// <summary>
        /// Determines whether the specified object's value is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(PdfName) && ((PdfName)obj).name.Equals(name);
        }

        /// <summary>
        /// Returns a hashcode that is determined by the string representation of the PdfName object.
        /// </summary>
        /// <returns>A hashcode for the PdfName object.</returns>
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }

    /// <summary>
    /// Represents the PDF bool object. See the PDF Reference 3.2.1 Boolean Objects.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfBool : PdfObject
    {
        private bool val;

        /// <summary>
        /// Initializes a new PdfBool instance.
        /// </summary>
        /// <param name="truthValue">The initial value of the PdfBool object.</param>
        public PdfBool(bool truthValue)
        {
            this.val = truthValue;
        }

        /// <summary>
        /// Returns the string representation of this object.
        /// </summary>
        /// <returns>Either "true" or "false".</returns>
        public override string ToString()
        {
            return val ? "true" : "false";
        }
    }

    /// <summary>
    /// Represents a form field in a PDF document.
    /// Objects of this class should not be created directly, but rather by instantiating any of its subclasses.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfField
    {
        /// <summary>
        /// The object number of this field.
        /// </summary>
        private int objectNumber;
        /// <summary>
        /// The generation number of this field.
        /// </summary>
        private int generationNumber;
        /// <summary>
        /// The field dictionary of this field. See the PDF Reference 8.6.2 Field Dictionaries.
        /// </summary>
        private PdfDictionary fieldDictionary;
        /// <summary>
        /// The serialized form of the object after it was parsed.
        /// </summary>
        private string original;
        /// <summary>
        /// The /AP PDF Name object.
        /// </summary>
        protected static PdfName APName = new PdfName("/AP");
        /// <summary>
        /// The /N PDF Name object.
        /// </summary>
        protected static PdfName NName = new PdfName("/N");
        /// <summary>
        /// The /V PDF Name object.
        /// </summary>
        protected static PdfName VName = new PdfName("/V");
        /// <summary>
        /// The /T PDF Name object.
        /// </summary>
        protected static PdfName TName = new PdfName("/T");
        /// <summary>
        /// The /Ff PDF Name object.
        /// </summary>
        protected static PdfName FFName = new PdfName("/Ff");
        /// <summary>
        /// The /FT PDF Name object.
        /// </summary>
        protected static PdfName FTName = new PdfName("/FT");
        /// <summary>
        /// The /Tx PDF Name object.
        /// </summary>
        protected static PdfName TXName = new PdfName("/Tx");
        /// <summary>
        /// The /Ch PDF Name object.
        /// </summary>
        protected static PdfName CHName = new PdfName("/Ch");
        /// <summary>
        /// The /Btn PDF Name object.
        /// </summary>
        protected static PdfName ButtonName = new PdfName("/Btn");
        /// <summary>
        /// The /Kids PDF Name object.
        /// </summary>
        protected static PdfName KidsName = new PdfName("/Kids");
        /// <summary>
        /// The /AA PDF Name object.
        /// </summary>
        protected static PdfName AAName = new PdfName("/AA");
        /// <summary>
        /// The /TM PDF Name object.
        /// </summary>
        protected static PdfName TMName = new PdfName("/TM");
        /// <summary>
        /// The /TU PDF Name object.
        /// </summary>
        protected static PdfName TUName = new PdfName("/TU");
        /// <summary>
        /// The /Parent PDF Name object.
        /// </summary>
        protected static PdfName ParentName = new PdfName("/Parent");

        /// <summary>
        /// The object number of this field.
        /// </summary>
        public int ObjectNumber
        {
            get
            {
                return objectNumber;
            }

            set
            {
                objectNumber = value;
            }
        }

        /// <summary>
        /// The generation number of this field.
        /// </summary>
        public int GenerationNumber
        {
            get
            {
                return generationNumber;
            }

            set
            {
                generationNumber = value;
            }
        }

        /// <summary>
        /// The field dictionary of this field. See the PDF Reference 8.6.2 Field Dictionaries.
        /// </summary>
        public PdfDictionary FieldDictionary
        {
            get
            {
                return fieldDictionary;
            }

            set
            {
                fieldDictionary = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of PdfField with the specified object number, generation number,
        /// and field dictionary.
        /// </summary>
        /// <param name="objNumber">The object number.</param>
        /// <param name="generationNumber">The generation number.</param>
        /// <param name="fieldDictionary">The field dictionary.</param>
        protected PdfField(int objNumber, int generationNumber, PdfDictionary fieldDictionary)
        {
            ObjectNumber = objNumber;
            GenerationNumber = generationNumber;
            FieldDictionary = fieldDictionary;
            original = GetString();
        }

        /// <summary>
        /// Factory method for PdfField objects. 
        /// Initializes new objects according to the contents of the specified field dictionary.
        /// Does not currently support signature fields.
        /// In most cases, this will return just one object. However, fields are organized according
        /// to trees, where intermediate field objects may have child fields. Only terminal field objects
        /// are "real" fields, so this method may return more than one field.
        /// </summary>
        /// <param name="reference">The reference to the root node of the fields.</param>
        /// <param name="reader">The PdfReader object from which to fetch additional child objects.</param>
        /// <param name="parentDictionary">The accumulated field dictionary of the ancestor objects.
        /// May be null for the root object.</param>
        /// <param name="fieldName">The complete field name up to this object, e.g. "a.b.c".</param>
        /// <returns>A new PdfField object.</returns>
        /// <exception cref="Exception">Thrown when the field dictionary does not contain
        /// a known field type.</exception>
        public static PdfField[] GetPdfFields(PdfReference reference, PdfReader reader,
            PdfDictionary parentDictionary, string fieldName)
        {
            int objNumber = reference.ObjectNumber;
            int generationNumber = reference.GenerationNumber;
            PdfDictionary fieldDictionary = (PdfDictionary)reader.GetObjectForReference(reference);

            // get the path name
            if (fieldDictionary["/T"] != null)
            {
                if (fieldName != "")
                {
                    fieldName += ".";
                }

                fieldName += ((PdfString)fieldDictionary["/T"]).Text;
            }

            if (parentDictionary != null)
            {
                // add all ancestral objects that haven't been overwritten by this object
                foreach (object key in parentDictionary.Dictionary.Keys)
                {
                    if (!fieldDictionary.Dictionary.ContainsKey(key))
                    {
                        fieldDictionary.Dictionary.Add(key, parentDictionary.Dictionary[key]);
                    }
                }
            }

            if (fieldDictionary["/Kids"] == null || PdfButtonField.IsRadioButton(fieldDictionary))
            {
                // it's a terminal node

                PdfName fieldType = (PdfName)fieldDictionary.GetElement(FTName);
                PdfField field;

                if (fieldType.Equals(TXName))
                {
                    field = new PdfTXField(objNumber, generationNumber, fieldDictionary);
                }
                else if (fieldType.Equals(CHName))
                {
                    field = new PdfCHField(objNumber, generationNumber, fieldDictionary);
                }
                else if (fieldType.Equals(ButtonName))
                {
                    field = PdfButtonField.GetButtonField(objNumber, generationNumber, fieldDictionary);
                }
                else
                {
                    throw new Exception("unsupported field type '" + fieldType.ToString() + "'");
                }

                field.FieldName = fieldName;

                return new PdfField[] { field };
            }
            else
            {
                // it's an intermediate node

                ArrayList fields = new ArrayList();
                PdfArray kids = (PdfArray)fieldDictionary.GetElement(KidsName);

                foreach (PdfReference child in kids.Elements)
                {
                    PdfDictionary childDictionary = new PdfDictionary(new Hashtable(fieldDictionary.Dictionary));
                    // these are not inheritable
                    childDictionary.Dictionary.Remove(KidsName);
                    childDictionary.Dictionary.Remove(TName);
                    childDictionary.Dictionary.Remove(AAName);
                    childDictionary.Dictionary.Remove(TMName);
                    childDictionary.Dictionary.Remove(TUName);
                    childDictionary.Dictionary.Remove(ParentName);
                    fields.AddRange(GetPdfFields(child, reader, childDictionary, fieldName));
                }

                return (PdfField[])fields.ToArray(typeof(PdfField));
            }
        }

        /// <summary>
        /// Returns true if changes were made to the field after it was created.
        /// </summary>
        /// <returns>true if there are changes.</returns>
        public bool HasChanged()
        {
            bool hasChanged = !original.Equals(ToString());
            return hasChanged;
        }

        /// <summary>
        /// Returns the string representation of this form field.
        /// </summary>
        /// <returns>The string representation of this form field.</returns>
        public override string ToString()
        {
            return GetString();
        }

        private string GetString()
        {
            string s = ObjectNumber.ToString(CultureInfo.InvariantCulture) + " " + GenerationNumber + " obj\n";
            s += FieldDictionary.ToString();
            s += "\nendobj\n";

            return s;
        }

        /// <summary>
        /// Gets or sets the name of this field. This is not the complete field name, just the local part,
        /// e.g. "c" where the complete field name is "a.b.c".
        /// </summary>
        /// <value>The name of this form field.</value>
        public string Name
        {
            get
            {
                if (FieldDictionary.Dictionary.ContainsKey(TName) && FieldDictionary.Dictionary[TName].GetType() == typeof(PdfString))
                {
                    PdfString name = (PdfString)FieldDictionary.Dictionary[TName];
                    return name.Text;
                }
                else
                {
                    return "";
                }
            }

            set
            {
                string s = "()";
                PdfString name = new PdfString(false, ref s);
                name.Text = value;
                FieldDictionary.SetElement(TName, name);
            }
        }

        /// <summary>
        /// The complete field name.
        /// </summary>
        private string completeFieldName;

        /// <summary>
        /// Gets or Sets the complete field name.
        /// </summary>
        public string FieldName
        {
            get
            {
                return completeFieldName;
            }

            set
            {
                this.completeFieldName = value;
            }
        }

        /// <summary>
        /// Returns the bit at the specified position in the field flags of this field.
        /// </summary>
        /// <param name="bitPosition">The bit position starting at 1.</param>
        /// <returns>true if the bit's value is 1.</returns>
        public bool GetBit(int bitPosition)
        {
            bool bit = false;
            if (FieldDictionary.Dictionary.ContainsKey(FFName) && FieldDictionary.Dictionary[FFName].GetType() == typeof(PdfNumber))
            {
                PdfNumber number = (PdfNumber)FieldDictionary.Dictionary[FFName];
                bit = ((int)number.Number & (1 << (bitPosition - 1))) > 0;
            }

            return bit;
        }

        /// <summary>
        /// Sets the bit at the specified position in the field flags of this field.
        /// </summary>
        /// <param name="bitPosition">The bit position starting at 1.</param>
        /// <param name="bit">true to set the bit's value to 1.</param>
        public void SetBit(int bitPosition, bool bit)
        {
            int num = 0;
            if (FieldDictionary.Dictionary.ContainsKey(FFName) && FieldDictionary.Dictionary[FFName].GetType() == typeof(PdfNumber))
            {
                num = (int)((PdfNumber)FieldDictionary.Dictionary[FFName]).Number;
            }

            if (bit)
            {
                num = (int)num | (1 << (bitPosition - 1));
            }
            else
            {
                num = (int)num & ~(1 << (bitPosition - 1));
            }

            FieldDictionary.SetElement(FFName, new PdfNumber(num.ToString(CultureInfo.InvariantCulture)));
        }
    }

    /// <summary>
    /// Represents a generic Button form field in a PDF document.
    /// Instances of this class should not be created through the constructor but instead through the factory
    /// method <see cref="GetButtonField"/>.
    /// See the PDF reference 8.6.3 Field Types.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfButtonField : PdfField
    {
        private static readonly Regex btnRegex = new Regex(@"/Ff\s+(\d+)", RegexOptions.Singleline);

        /// <summary>
        /// Initializes a new instance of PdfButtonField with the specified object number, generation number,
        /// and field dictionary.
        /// </summary>
        /// <param name="objNumber">The object number.</param>
        /// <param name="generationNumber">The generation number.</param>
        /// <param name="fieldDictionary">The field dictionary.</param>
        protected PdfButtonField(int objNumber, int generationNumber, PdfDictionary fieldDictionary)
            : base(objNumber,
                generationNumber, fieldDictionary)
        {
        }

        /// <summary>
        /// Creates either a <see cref="PdfPushButtonField"/>, <see cref="PdfRadioButtonField"/>, or a
        /// <see cref="PdfCheckBoxField"/> according to the parsed field dictionary.
        /// </summary>
        /// <param name="objNumber">The object number.</param>
        /// <param name="generationNumber">The generation number.</param>
        /// <param name="fieldDictionary">The field dictionary.</param>
        /// <returns></returns>
        public static PdfButtonField GetButtonField(int objNumber, int generationNumber, PdfDictionary fieldDictionary)
        {
            int flags = 0;

            PdfNumber num = (PdfNumber)fieldDictionary.GetElement(FFName);
            if (num != null)
            {
                flags = (int)num.Number;
            }

            if ((flags & (1 << 16)) > 0)
            {
                return new PdfPushButtonField(objNumber, generationNumber, fieldDictionary);
            }
            else if ((flags & (1 << 15)) > 0)
            {
                return new PdfRadioButtonField(objNumber, generationNumber, fieldDictionary);
            }
            else
            {
                return new PdfCheckBoxField(objNumber, generationNumber, fieldDictionary);
            }
        }

        /// <summary>
        /// Determines whether the object specified is a RadioButton.
        /// </summary>
        /// <param name="fieldDictionary">The object's field dictionary.</param>
        /// <returns>true if the object specified is a RadioButton, false otherwise.</returns>
        public static bool IsRadioButton(PdfDictionary fieldDictionary)
        {
            if (!IsButton(fieldDictionary))
            {
                return false;
            }

            PdfNumber num = fieldDictionary.GetElement(FFName) as PdfNumber;
            if (num != null)
            {
                int flags = (int)num.Number;
                return ((flags & (1 << 15)) > 0);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether the object specified is a Button.
        /// </summary>
        /// <param name="fieldDictionary">The object's field dictionary.</param>
        /// <returns>true if the object specified is a Button, false otherwise.</returns>
        protected static bool IsButton(PdfDictionary fieldDictionary)
        {
            PdfName type = fieldDictionary.GetElement(FTName) as PdfName;
            if (type != null)
            {
                if (!type.Equals(ButtonName))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Represents a PushButton form field in a PDF document.
    /// See the PDF reference 8.6.3 Field Types.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfPushButtonField : PdfButtonField
    {
        /// <summary>
        /// Initializes a new instance of PdfPushButtonField with the specified object number, generation number,
        /// and field dictionary.
        /// </summary>
        /// <param name="objNumber">The object number.</param>
        /// <param name="generationNumber">The generation number.</param>
        /// <param name="fieldDictionary">The field dictionary.</param>
        public PdfPushButtonField(int objNumber, int generationNumber, PdfDictionary fieldDictionary)
            : base(objNumber,
                generationNumber, fieldDictionary)
        {
        }
    }

    /// <summary>
    /// Represents a set of RadioButton form fields in a PDF document.
    /// See the PDF reference 8.6.3 Field Types.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfRadioButtonField : PdfButtonField
    {
        /// <summary>
        /// Initializes a new instance of PdfRadioButtonField with the specified object number, generation number,
        /// and field dictionary.
        /// </summary>
        /// <param name="objNumber">The object number.</param>
        /// <param name="generationNumber">The generation number.</param>
        /// <param name="fieldDictionary">The field dictionary.</param>
        public PdfRadioButtonField(int objNumber, int generationNumber, PdfDictionary fieldDictionary)
            : base(objNumber,
                generationNumber, fieldDictionary)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating the selected RadioButton.
        /// </summary>
        /// <value>The name of the selected RadioButton (without the leading '/').</value>
        public string SelectedItem
        {
            get
            {
                if (FieldDictionary.Dictionary.ContainsKey(VName) && FieldDictionary.Dictionary[VName].GetType() == typeof(PdfName))
                {
                    PdfName selected = (PdfName)FieldDictionary.Dictionary[VName];
                    return selected.ToString().Substring(1);
                }
                else
                {
                    return "";
                }
            }

            set
            {
                FieldDictionary.SetElement(VName, new PdfName("/" + value));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if it is possible that no RadioButton is selected.
        /// </summary>
        /// <value>true if it is not possible that no RadioButton is selected.</value>
        public bool NoToggleToOff
        {
            get
            {
                return GetBit(15);
            }

            set
            {
                SetBit(15, value);
            }
        }
    }

    /// <summary>
    /// Represents a CheckBox form field in a PDF document.
    /// See the PDF reference 8.6.3 Field Types.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfCheckBoxField : PdfButtonField
    {
        private PdfName OnState; // the Name object for the checked state, unchecked is always /Off
        private static PdfName OffState = new PdfName("/Off");
        private static PdfName ASName = new PdfName("/AS");

        /// <summary>
        /// Initializes a new instance of PdfCheckBoxField with the specified object number, generation number,
        /// and field dictionary.
        /// </summary>
        /// <param name="objNumber">The object number.</param>
        /// <param name="generationNumber">The generation number.</param>
        /// <param name="fieldDictionary">The field dictionary.</param>
        public PdfCheckBoxField(int objNumber, int generationNumber, PdfDictionary fieldDictionary)
            : base(objNumber,
                generationNumber, fieldDictionary)
        {
            SetOnState();
        }

        private void SetOnState()
        {
            if (FieldDictionary.Dictionary.ContainsKey(APName) && FieldDictionary.Dictionary[APName].GetType() == typeof(PdfDictionary))
            {
                PdfDictionary appearance = (PdfDictionary)FieldDictionary.Dictionary[APName];
                if (appearance.Dictionary.ContainsKey(NName) && appearance.Dictionary[NName].GetType() == typeof(PdfDictionary))
                {
                    PdfDictionary subAppearance = (PdfDictionary)appearance.Dictionary[NName];
                    foreach (PdfName name in subAppearance.Dictionary.Keys)
                    {
                        if (!name.Equals(OffState))
                        {
                            OnState = name;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the CheckBox is checked.
        /// </summary>
        /// <value>true is the CheckBox is checked.</value>
        public bool Checked
        {
            get
            {
                return FieldDictionary.Dictionary.ContainsKey(VName) && FieldDictionary.Dictionary[VName].Equals(OnState);
            }

            set
            {
                PdfName name = value ? OnState : OffState;
                FieldDictionary.SetElement(VName, name);
                FieldDictionary.SetElement(ASName, name);
            }
        }
    }

    /// <summary>
    /// Represents a Text form field in a PDF document, i.e. either a ListBox or a ComboBox.
    /// See the PDF reference 8.6.3 Field Types.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfTXField : PdfField
    {
        /// <summary>
        /// Initializes a new instance of PdfTXField with the specified object number, generation number,
        /// and field dictionary.
        /// </summary>
        /// <param name="objNumber">The object number.</param>
        /// <param name="generationNumber">The generation number.</param>
        /// <param name="fieldDictionary">The field dictionary.</param>
        public PdfTXField(int objNumber, int generationNumber, PdfDictionary fieldDictionary)
            : base(objNumber,
                generationNumber, fieldDictionary)
        {
            FieldDictionary.Dictionary.Remove(APName); // remove the appearance element, so it gets regenerated by the viewer
        }

        /// <summary>
        /// Gets or sets a value indicating the text that is displayed in the field.
        /// </summary>
        public string Text
        {
            get
            {
                if (FieldDictionary.Dictionary.ContainsKey(VName) && FieldDictionary.Dictionary[VName].GetType() == typeof(PdfString))
                {
                    PdfString val = (PdfString)FieldDictionary.Dictionary[VName];
                    return val.Text;
                }
                else
                {
                    return "";
                }
            }

            set
            {
                PdfString val;
                string input = value + ")";
                val = new PdfString(false, ref input);

                FieldDictionary.SetElement(VName, val);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the field allows more than one line of input.
        /// </summary>
        /// <value>true if more than one line of input is allowed.</value>
        public bool MultiLine
        {
            get
            {
                return GetBit(13);
            }

            set
            {
                SetBit(13, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the text should be visibly echoed
        /// or instead rendered in a non-readable form such as asterisks or bullets.
        /// </summary>
        /// <value>true if the text should not be visibly echoed.</value>
        public bool Password
        {
            get
            {
                return GetBit(14);
            }

            set
            {
                SetBit(14, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this field represents the pathname of
        /// a file whose contents are to be submitted as the value of the field.
        /// </summary>
        /// <value>true if this field represents the pathname of a file.</value>
        public bool FileSelect
        {
            get
            {
                return GetBit(21);
            }

            set
            {
                SetBit(21, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether spellchecking should be enabled.
        /// </summary>
        /// <value>true if no spell checking is performed.</value>
        public bool DoNotSpellCheck
        {
            get
            {
                return GetBit(23);
            }

            set
            {
                SetBit(23, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if scrolling is allowed.
        /// </summary>
        /// <value>true if this field should not allow scrolling.</value>
        public bool DoNotScroll
        {
            get
            {
                return GetBit(24);
            }

            set
            {
                SetBit(24, value);
            }
        }
    }

    /// <summary>
    /// Represents a Choice form field in a PDF document, i.e. either a ListBox or a ComboBox.
    /// See the PDF reference 8.6.3 Field Types.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfCHField : PdfField
    {
        private static PdfName IName = new PdfName("/I");

        /// <summary>
        /// Initializes a new instance of PdfCHField with the specified object number, generation number,
        /// and field dictionary.
        /// </summary>
        /// <param name="objNumber">The object number.</param>
        /// <param name="generationNumber">The generation number.</param>
        /// <param name="fieldDictionary">The field dictionary.</param>
        public PdfCHField(int objNumber, int generationNumber, PdfDictionary fieldDictionary)
            : base(objNumber,
                generationNumber, fieldDictionary)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether this field should be rendered as a ComboBox or a ListBox.
        /// </summary>
        /// <value>true if the field should be rendered as ComboBox.</value>
        public bool Combo
        {
            get
            {
                return GetBit(18);
            }

            set
            {
                SetBit(18, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the ComboBox includes an editable text box as well as a drop list.
        /// This property is meaningful only if the Combo property is set to true.
        /// </summary>
        /// <value>true if the ComboBox should include an editable text box.</value>
        public bool Edit
        {
            get
            {
                return GetBit(19);
            }

            set
            {
                SetBit(19, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the fields elements are sorted alphabetically.
        /// </summary>
        /// <value>true if the elements are sorted alphabetically.</value>
        public bool Sort
        {
            get
            {
                return GetBit(20);
            }

            set
            {
                SetBit(20, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if more than one element is selectable.
        /// </summary>
        /// <value>true if more than one element is selectable.</value>
        public bool MultiSelect
        {
            get
            {
                return GetBit(22);
            }

            set
            {
                SetBit(22, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether spellchecking should be enabled.
        /// This flag is meaningful only if the Combo and Edit flags are both set.
        /// </summary>
        /// <value>true if no spell checking is performed.</value>
        public bool DoNotSpellCheck
        {
            get
            {
                return GetBit(23);
            }

            set
            {
                SetBit(23, value);
            }
        }

        /// <summary>
        /// Sets the indexes of the items that should appear selected.
        /// </summary>
        /// <param name="indexes">The selected indexes.</param>
        public void SetSelectedIndexes(params int[] indexes)
        {
            if (indexes == null || indexes.Length <= 0)
            {
                FieldDictionary.SetElement(IName, new PdfNull());
            }
            else if (indexes.Length == 1)
            {
                PdfNumber val = new PdfNumber((double)indexes[0]);

                FieldDictionary.SetElement(IName, val);
            }
            else
            {
                PdfNumber[] items = new PdfNumber[indexes.Length];
                int i = 0;
                foreach (int index in indexes)
                {
                    items[i] = new PdfNumber((double)index);
                    i++;
                }

                PdfArray val = new PdfArray(items);
                FieldDictionary.SetElement(IName, val);
            }
        }

        /// <summary>
        /// Gets the indexes of the items that should appear selected.
        /// </summary>
        /// <returns>An array of index that are selected.</returns>
        public int[] GetSelectedIndexes()
        {
            PdfObject iObject = FieldDictionary.GetElement(IName);

            if (iObject == null || iObject.GetType() == typeof(PdfNull))
            {
                return new int[] { };
            }
            else if (iObject.GetType() == typeof(PdfNumber))
            {
                return new int[] { (int)((PdfNumber)iObject).Number };
            }
            else
            {
                PdfArray array = (PdfArray)iObject;
                int[] indexes = new int[array.Elements.Count];

                for (int i = 0; i < array.Elements.Count; i++)
                {
                    indexes[i] = (int)((PdfNumber)array[i]).Number;
                }

                return indexes;
            }
        }
    }

    /// <summary>
    /// Represents an AcroForm object in a PDF document. See the PDF reference 8.6.1 Interactive Form Dictionary.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfForm : PdfField
    {
        private static PdfName NAName = new PdfName("/NeedAppearances");

        /// <summary>
        /// Initializes a new instance of PdfForm with the specified object number, generation number,
        /// and field dictionary.
        /// </summary>
        /// <param name="objNumber">The object number.</param>
        /// <param name="generationNumber">The generation number.</param>
        /// <param name="fieldDictionary">The field dictionary.</param>
        public PdfForm(int objNumber, int generationNumber, PdfDictionary fieldDictionary)
            : base(objNumber,
                generationNumber, fieldDictionary)
        {
            // set NeedAppearances key so the viewer application regenerates the appearance streams
            // for the form fields.
            FieldDictionary.SetElement(NAName, new PdfBool(true));
        }
    }

    /// <summary>
    /// Represents an entry in the PDF Cross Reference table. 
    /// See the PDF Reference 3.4.3 Cross-Reference Table.
    /// </summary>
    [CLSCompliant(true)]
    public class PdfCrossReferenceEntry
    {
        private int objectNumber;
        private int generationNumber;
        private int offset;
        private bool active;

        /// <summary>
        /// The object number.
        /// </summary>
        public int ObjectNumber
        {
            get
            {
                return objectNumber;
            }

            set
            {
                objectNumber = value;
            }
        }

        /// <summary>
        /// The generation number.
        /// </summary>
        public int GenerationNumber
        {
            get
            {
                return generationNumber;
            }

            set
            {
                generationNumber = value;
            }
        }

        /// <summary>
        /// The byte offset of the object within the document.
        /// </summary>
        public int Offset
        {
            get
            {
                return offset;
            }

            set
            {
                offset = value;
            }
        }

        /// <summary>
        /// true if the object is not free, false otherwise.
        /// </summary>
        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }

        /// <summary>
        /// Initializes a new PdfCrossReferenceEntry object.
        /// </summary>
        /// <param name="objNumber">The object number</param>
        /// <param name="generationNumber">The generation number</param>
        /// <param name="offset">The byte offset within the PDF file</param>
        /// <param name="active">true if the object is not free, false otherwise</param>
        public PdfCrossReferenceEntry(int objNumber, int generationNumber,
            int offset, bool active)
        {
            ObjectNumber = objNumber;
            GenerationNumber = generationNumber;
            Offset = offset;
            Active = active;
        }
    }

    /// <summary>
    /// Parses PDF files for interactive form fields and allows to get and set the value of those fields.
    /// </summary>
    /// <remarks>
    /// The PDF parser in PdfReader is very simple and suffices only for basic cases.
    /// PdfReader is intended to easily programmatically fill out PDF forms.
    /// It parses the PDF in one go and allows the user to make changes to the form field values.
    /// It writes an updated version of the PDF to a Stream, which (hopefully) conforms to the PDF Reference.
    /// If you have advanced parsing needs, you are probably better off with a package such as <see href="http://www.lowagie.com/iText/">iText</see>.
    /// </remarks>
    /// <example>
    /// Read a PDF file, change one text field, write the updated file back out:
    /// <code>
    /// // read the file
    /// PdfReader reader = new PdfReader(infile);
    /// 
    /// // change one text field
    /// try
    /// {
    ///		((PdfTXField)reader.FieldsByName["Name"]).Text = "Doe";
    /// }
    /// catch
    /// {
    /// }
    /// 
    /// // write the file
    /// FileStream fileStream = new FileStream(file, System.IO.FileMode.Create);
    /// reader.WritePdf(fileStream);
    /// fileStream.Close();
    /// </code>
    /// </example>
    [CLSCompliant(true)]
    public class PdfReader
    {
        private string pdf;
        private PdfField[] fields = new PdfField[0];
        private Hashtable fieldsByName = new Hashtable();
        private PdfForm form;
        private static readonly Regex xrefRegex = new Regex(@"startxref\s*(\d+)\s*%%EOF", RegexOptions.Singleline);
        private static readonly Regex trailerRegex = new Regex(@"trailer\s*<<(.*?)>>", RegexOptions.Singleline);
        private static readonly Regex rootRegex = new Regex(@"/Root\s*(\d+)\s+(\d+)\s*R", RegexOptions.Singleline);
        private static readonly Regex sizeRegex = new Regex(@"/Size\s*(\d+)", RegexOptions.Singleline);
        private static readonly Regex nullRegex = new Regex(@"\sxref\s+0\s+\d+\s+(\d+)", RegexOptions.Singleline);
        private static readonly Regex refRegex = new Regex(@"\s*((\d+)\s+(\d+))?\s*(\d{10})\s+(\d{5})\s+(n|f)", RegexOptions.Singleline);
        private static readonly Regex objectRegex = new Regex(@"(\d+)\s+(\d+)\s+obj(.*?)endobj", RegexOptions.Singleline);
        private static readonly Regex fieldRegex = new Regex(@"^\s*<<(.*?/FT\s+/(Btn|Tx|Ch).*>>)", RegexOptions.Singleline);
        private static readonly Regex formRegex = new Regex(@"^\s*<<(.*?/Fields\s+\[.*>>)", RegexOptions.Singleline);
        private static readonly Regex acroFormRegex = new Regex(@"/AcroForm\s+(\d+)\s+(\d+)", RegexOptions.Singleline);
        private static readonly Regex trailRegex = new Regex(@"trailer\s+<<(.*>>)(\s+startxref\s+(\d+))?", RegexOptions.Singleline);
        private static readonly Regex objRegex = new Regex(@"(\d+)\s+(\d+)\s+obj", RegexOptions.Singleline);
        private static readonly Regex linearizedRegex = new Regex(@"/Linearized\s+1", RegexOptions.Singleline);

        private int previous = -1; // location of the previous cross-reference table
        private PdfDictionary previousTrailer;
        private int rootObjectNumber;
        private int nullOffset;
        private bool linearized = false;

        private Hashtable objects = new Hashtable();
        private SortedList offsets = new SortedList();

        /// <summary>
        /// Initializes a new instance of PdfReader with the specified file.
        /// </summary>
        /// <param name="name">The file containing the PDF data.</param>
        public static PdfReader GetPdfReader(string name)
        {
            PdfReader reader;

            using (FileStream stream = new FileStream(name, FileMode.Open))
            {
                reader = new PdfReader(stream);
            }

            return reader;
        }

        /// <summary>
        /// Initializes a new instance of PdfReader with the specified Stream.
        /// </summary>
        /// <param name="stream">The Stream containing the PDF data.</param>
        public PdfReader(Stream stream)
        {
            DOMConfigurator.ConfigureAndWatch(new FileInfo("PdfReader.exe.log4net"));

            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int)stream.Length);

            char[] chars = new char[buffer.Length];

            for (int i = 0; i < buffer.Length; i++)
            {
                chars[i] = (char)buffer[i];
            }

            pdf = new String(chars);

            Parse();
        }

        /// <summary>
        /// Returns the PDF object referenced by the specified PDF reference.
        /// </summary>
        /// <param name="reference">The reference to the object.</param>
        /// <returns>The PDF object referenced.</returns>
        public PdfObject GetObjectForReference(PdfReference reference)
        {
            PdfObject PdfObject = null;

            // is the object active?
            if (objects.Contains(reference.ObjectNumber))
            {
                PdfCrossReferenceEntry entry = (PdfCrossReferenceEntry)objects[reference.ObjectNumber];

                if (entry.Active)
                {
                    int start = entry.Offset;
                    int end = GetEndOfObject(reference.ObjectNumber);

                    PdfObject = ParseObject(start, end);
                }
            }

            return PdfObject;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the file is linearized.
        /// Refer to the PDF Reference, Appendix F.
        /// </summary>
        public bool Linearized
        {
            get
            {
                return linearized;
            }

            set
            {
                linearized = value;
            }
        }

        private void Parse()
        {
            ArrayList fieldsList = new ArrayList();
            int startTrailer;
            int endPosition = pdf.Length - 1;
            int startxref;
            PdfName prevName = new PdfName("/Prev");
            PdfName sizeName = new PdfName("/Size");
            PdfName rootName = new PdfName("/Root");
            Match match;

            // hack to determine if PDF is linearized:
            // check for the occurence of "/Linearized 1" before the first
            // occurence of "endobj"
            match = linearizedRegex.Match(pdf, 0, pdf.IndexOf("endobj"));
            if (match.Success)
            {
                Linearized = true;
            }

            // succesively parse all trailers starting from the end
            while ((startTrailer = pdf.LastIndexOf("trailer", endPosition)) >= 0)
            {
                match = trailRegex.Match(pdf, startTrailer, endPosition - startTrailer + 1);

                if (match.Success)
                {
                    string trailerString = match.Groups[1].Value;
                    PdfDictionary trailerDictionary = new PdfDictionary(ref trailerString);

                    startxref = -1;
                    // in a hybrid-reference file (PDF 1.5), the trailer doesn't seem to
                    // always include a startxref.
                    if (match.Groups[2].Success)
                    {
                        startxref = Int32.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
                    }

                    if (previous == -1)
                    {
                        previous = startxref;
                    }

                    // we don't believe the startxref field.
                    // it can be bogus due to linearization.
                    // we'll keep the "previous" value from above though, since
                    // that's what taft@adobe.com says in a 1998 post on comp.text.pdf :-)
                    startxref = pdf.LastIndexOf("xref", startTrailer);

                    if (previousTrailer == null || Linearized)
                    {
                        previousTrailer = trailerDictionary;
                    }

                    // parse the xref table that is referenced by this trailer
                    ParseXRef(startxref);

                    // the offset of the first object marks the start of the body and is therefore
                    // the end of the previous trailer
                    if (offsets.Count > 0)
                    {
                        endPosition = ((PdfCrossReferenceEntry)offsets.GetByIndex(0)).Offset;
                    }
                    else
                    {
                        // if the xref table has no objects then the previous trailer must
                        // be right in front of it
                        endPosition = startxref;
                    }
                }
            }

            rootObjectNumber = ((PdfReference)previousTrailer["/Root"]).ObjectNumber;

            ParseAcroForm();

            if (form != null)
            {
                PdfObject fieldsObject = form.FieldDictionary["/Fields"];
                PdfArray fieldsArray = fieldsObject as PdfArray;
                if (fieldsArray == null)
                {
                    PdfReference fieldsReference = fieldsObject as PdfReference;
                    fieldsArray = (PdfArray)GetObjectForReference(fieldsReference);
                }

                foreach (PdfReference fieldReference in fieldsArray.Elements)
                {
                    PdfField[] fields = PdfField.GetPdfFields(fieldReference, this, null, "");

                    foreach (PdfField field in fields)
                    {
                        Trace.Assert(field != null);

                        fieldsList.Add(field);

                        // make field name unique
                        string fieldName = field.Name;
                        int i = 0;
                        while (fieldsByName.Contains(fieldName))
                        {
                            fieldName = string.Format(CultureInfo.InvariantCulture, "{0}[{1}]", field.Name, i);
                            i++;
                        }

                        fieldsByName.Add(fieldName, field);
                    }
                }

                this.fields = (PdfField[])fieldsList.ToArray(typeof(PdfField));
            }
        }

        private void ParseXRef(int startxref)
        {
            int objNumber = 0;
            int generationNumber;
            int offset;
            PdfCrossReferenceEntry entry;
            int endOfXRef = pdf.IndexOf("trailer", startxref + 4);
            string xRef = pdf.Substring(startxref + 4, endOfXRef - (startxref + 4) + 1);
            MatchCollection refMatches = refRegex.Matches(xRef);

            foreach (Match refMatch in refMatches)
            {
                if (!refMatch.Groups[2].Value.Equals(""))
                {
                    objNumber = Int32.Parse(refMatch.Groups[2].Value, CultureInfo.InvariantCulture);
                }

                offset = Int32.Parse(refMatch.Groups[4].Value, CultureInfo.InvariantCulture);
                generationNumber = Int32.Parse(refMatch.Groups[5].Value, CultureInfo.InvariantCulture);

                if (refMatch.Groups[6].Value.Equals("n"))
                {
                    entry = new PdfCrossReferenceEntry(objNumber, generationNumber, offset,
                        refMatch.Groups[6].Value.Equals("n"));

                    if (!objects.Contains(objNumber))
                    {
                        offsets.Add(offset, entry);
                        objects.Add(objNumber, entry);
                    }
                }
                else if (objNumber == 0)
                {
                    // special case:
                    // in order to build a new xref table we need the first free object number
                    nullOffset = offset;
                }

                objNumber++;
            }
        }

        /// <summary>
        /// Gets the end offset of the specified object.
        /// The offset is determined by the beginning offset of the object with next higher start offset.
        /// If the object is the last object, -1 is returned.
        /// If the document was updated, the offset may be after the xref table and trailer that
        /// follow the specified object.
        /// </summary>
        /// <param name="objNumber">The object number to find the offset for.</param>
        /// <returns>The end offset of the specified object or -1 if it is the last object</returns>
        private int GetEndOfObject(int objNumber)
        {
            PdfCrossReferenceEntry theObject = (PdfCrossReferenceEntry)objects[objNumber];
            int objectIndex = offsets.IndexOfKey(theObject.Offset);

            if ((objectIndex + 1) < offsets.Count)
            {
                PdfCrossReferenceEntry nextObject = (PdfCrossReferenceEntry)offsets.GetByIndex(objectIndex + 1);
                return nextObject.Offset;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Parses the Interactive Form Dictionary referenced by the AcroForm entry in
        /// the Document Catalog.
        /// </summary>
        private void ParseAcroForm()
        {
            PdfCrossReferenceEntry documentCatalog = (PdfCrossReferenceEntry)objects[rootObjectNumber];
            int documentCatalogStart = documentCatalog.Offset;
            int documentCatalogEnd = GetEndOfObject(documentCatalog.ObjectNumber);

            PdfDictionary documentCatalogObject = ParseObject(documentCatalogStart, documentCatalogEnd) as PdfDictionary;
            PdfObject acroFormObject = documentCatalogObject["/AcroForm"];

            if (acroFormObject is PdfReference)
            {
                PdfReference acroFormRef = (PdfReference)acroFormObject;

                // extract the AcroForm object
                int acroNumber = acroFormRef.ObjectNumber;
                int acroGeneration = acroFormRef.GenerationNumber;
                int acroStart = ((PdfCrossReferenceEntry)objects[acroNumber]).Offset;
                int acroEnd = GetEndOfObject(acroNumber);

                PdfDictionary formDictionary = (PdfDictionary)ParseObject(acroStart, acroEnd);
                form = new PdfForm(acroNumber, acroGeneration, formDictionary);
            }
        }

        private PdfObject ParseObject(int start, int end)
        {
            Match match;
            if (end < 0)
            {
                match = objRegex.Match(pdf, start);
            }
            else
            {
                match = objRegex.Match(pdf, start, end - start);
            }

            if (match.Success)
            {
                int objNumber = Int32.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                int generationNumber = Int32.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
                int endOfMatch = match.Index + match.Length;

                string afterObj;
                if (end < 0)
                {
                    afterObj = pdf.Substring(endOfMatch);
                }
                else
                {
                    afterObj = pdf.Substring(endOfMatch, end - endOfMatch + 1);
                }
                return PdfObject.GetPdfObject(ref afterObj);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Writes the PDF out to the specified stream including all updates made after this object was created.
        /// </summary>
        /// <param name="stream">The <see cref="System.IO.Stream"/> the PDF will be written to.</param>
        public void WritePdf(Stream stream)
        {
            string lines = pdf + GetUpdate();

            byte[] buffer = new byte[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                buffer[i] = (byte)lines[i];
            }

            stream.Write(buffer, 0, buffer.Length);
        }

        private string GetUpdate()
        {
            if (form != null)
            {
                int offset = pdf.Length;
                string update = "";
                string xref = "xref\n";
                xref += "0 1\n";
                xref += nullOffset.ToString("0000000000", CultureInfo.InvariantCulture) + " 65535 f \n";

                // write the AcroForm object
                string formString = form.ToString();
                update += formString;
                xref += form.ObjectNumber.ToString(CultureInfo.InvariantCulture) + " 1\n";
                xref += offset.ToString("0000000000", CultureInfo.InvariantCulture) + " " + form.GenerationNumber.ToString("00000", CultureInfo.InvariantCulture) + " n \n";
                offset += formString.Length;

                foreach (PdfField field in Fields)
                {
                    if (field.HasChanged())
                    {
                        string fieldString = field.ToString();
                        update += fieldString;
                        xref += field.ObjectNumber.ToString(CultureInfo.InvariantCulture) + " 1\n";
                        xref += offset.ToString("0000000000", CultureInfo.InvariantCulture) + " " + field.GenerationNumber.ToString("00000", CultureInfo.InvariantCulture) + " n \n";
                        offset += fieldString.Length;
                    }
                }

                string trailer = GetTrailer(offset);

                return update + xref + trailer;
            }
            else
            {
                return "";
            }
        }

        private string GetTrailer(int xrefOffset)
        {
            Hashtable trailerHash = new Hashtable();
            PdfName prevName = new PdfName("/Prev");
            PdfName rootName = new PdfName("/Root");
            PdfName sizeName = new PdfName("/Size");

            trailerHash[prevName] = new PdfNumber(previous);
            trailerHash[rootName] = previousTrailer["/Root"];
            trailerHash[sizeName] = previousTrailer["/Size"];

            PdfDictionary newTrailer = new PdfDictionary(trailerHash);

            string s = "";
            s += "trailer\n";
            s += newTrailer + "\n";
            s += "startxref\n";
            s += xrefOffset.ToString(CultureInfo.InvariantCulture) + "\n";
            s += "%%EOF\n";

            return s;
        }

        /// <summary>
        /// Gets a collection of all form fields.
        /// </summary>
        public PdfField[] Fields
        {
            get
            {
                return fields;
            }
        }

        /// <summary>
        /// Gets a Hashtable of all form fields keyed by their name.
        /// </summary>
        public Hashtable FieldsByName
        {
            get
            {
                return fieldsByName;
            }
        }

        ///// <summary>
        ///// Reads the first file on the command line, parses it and writes it to the second file on the command line.
        ///// </summary>
        ///// <param name="args">Two filenames, the first must be a PDF file, the second will be written to.</param>
        //public static void Main(string[] args)
        //{
        //    if (args.Length != 2)
        //    {
        //        Console.Error.WriteLine("Usage: " + Environment.GetCommandLineArgs()[0] + " file1 file2");
        //        Console.Error.WriteLine("Reads file1, parses it as a PDF file, and writes to file2");
        //    }
        //    else
        //    {
        //        PdfReader reader = PdfReader.GetPdfReader(args[0]);

        //        foreach (PdfField field in reader.Fields)
        //        {
        //            Debug.WriteLine(field.FieldName);
        //        }

        //        FileStream fileStream = new FileStream(args[1], System.IO.FileMode.Create);
        //        reader.WritePdf(fileStream);
        //        fileStream.Close();
        //    }
        //}
    }
}
