using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

///<summary>
///Implements a <see cref="TextWriter"/> for writing information to the debugger log.
///</summary>
/// <seealso cref="Debugger.Log"/>
public class DebuggerWriter : TextWriter
{
    private bool isOpen;
    private static UnicodeEncoding encoding;
    private readonly int level;
    private readonly string category;

    /// <summary>
    /// Initializes a new instance of the <see cref="DebuggerWriter"/> class.
    /// </summary>
    /// 
    //[Conditional("DEBUG")]
    public DebuggerWriter()
        : this(0, Debugger.DefaultCategory)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DebuggerWriter"/> class with the specified level and category.
    /// </summary>
    /// <param name="level">A description of the importance of the messages.</param>
    /// <param name="category">The category of the messages.</param>
    public DebuggerWriter(int level, string category)
        : this(level, category, CultureInfo.CurrentCulture)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DebuggerWriter"/> class with the specified level, category and format provider.
    /// </summary>
    /// <param name="level">A description of the importance of the messages.</param>
    /// <param name="category">The category of the messages.</param>
    /// <param name="formatProvider">An <see cref="IFormatProvider"/> object that controls formatting.</param>
    public DebuggerWriter(int level, string category, IFormatProvider formatProvider)
        : base(formatProvider)
    {
        this.level = level;
        this.category = category;
        this.isOpen = true;
    }

    /// <summary>
    /// Dispose
    /// </summary>
    /// <param name="disposing">disposing</param>
    protected override void Dispose(bool disposing)
    {
        isOpen = false;
        base.Dispose(disposing);
    }

    /// <summary>
    /// Write
    /// </summary>
    /// <param name="value">char value</param>
    public override void Write(char value)
    {
        if (!isOpen)
        {
            throw new ObjectDisposedException(null);
        }
        Debugger.Log(level, category, value.ToString());
    }

    /// <summary>
    /// Write
    /// </summary>
    /// <param name="value">string value</param>
    public override void Write(string value)
    {
        if (!isOpen)
        {
            throw new ObjectDisposedException(null);
        }
        if (value != null)
        {
            Debugger.Log(level, category, value);
        }
    }

    /// <summary>
    /// Write
    /// </summary>
    /// <param name="buffer">buffer</param>
    /// <param name="index">index</param>
    /// <param name="count">count</param>
    public override void Write(char[] buffer, int index, int count)
    {
        if (!isOpen)
        {
            throw new ObjectDisposedException(null);
        }
        if (buffer == null || index < 0 || count < 0 || buffer.Length - index < count)
        {
            base.Write(buffer, index, count); // delegate throw exception to base class
        }
        Debugger.Log(level, category, new string(buffer, index, count));
    }

    /// <summary>
    /// Get the encoding of the writer
    /// </summary>
    public override Encoding Encoding
    {
        get
        {
            if (encoding == null)
            {
                encoding = new UnicodeEncoding(false, false);
            }
            return encoding;
        }
    }

    /// <summary>
    /// Get the level of the writer
    /// </summary>
    public int Level
    {
        get { return level; }
    }

    /// <summary>
    /// Get the category of the writer
    /// </summary>
    public string Category
    {
        get { return category; }
    }
}
