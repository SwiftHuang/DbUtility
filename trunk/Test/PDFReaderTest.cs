//
// Copyright (c) 2004, O&O Services GmbH.
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
using System.Collections;
using System.Reflection;
using System.IO;
using NUnit.Framework;

namespace OOGroup.Pdf
{
	/// <summary>
	/// Tests the PdfNull class.
	/// </summary>
	[TestFixture]
	public class PdfNullTest
	{
		/// <summary>
		/// Tests the PdfNull class.
		/// </summary>
		[Test]
		public void TestPdfNull()
		{
			PdfNull nullObject = new PdfNull();
			Assert.AreEqual("null", nullObject.ToString());
		}
	}

	/// <summary>
	/// Tests the PdfComment class.
	/// </summary>
	[TestFixture]
	public class PdfCommentTest
	{
		/// <summary>
		/// Test the output of the PdfComment class.
		/// </summary>
		[Test]
		public void TestOutput()
		{
            PdfComment comment = new PdfComment("Hallo");
			Assert.AreEqual("%Hallo\n", comment.ToString());
		}
	}

	/// <summary>
	/// Tests the PdfReference class.
	/// </summary>
	[TestFixture]
	public class PdfReferenceTest
	{
		/// <summary>
		/// Tests the PdfReference class.
		/// </summary>
		[Test]
		public void TestPdfReference()
		{
			PdfReference reference = new PdfReference(4711, 7);
			Assert.AreEqual("4711 7 R", reference.ToString());
		}
	}

	/// <summary>
	/// Tests the PdfNumber class.
	/// </summary>
	[TestFixture]
	public class PdfNumberTest
	{
		/// <summary>
		/// Tests Initialization from string.
		/// </summary>
		[Test]
		public void TestString()
		{
			PdfNumber num = new PdfNumber("4711.999");
			Assert.AreEqual("4711.999", num.ToString());
		}

		/// <summary>
		/// Tests initialization from double.
		/// </summary>
		[Test]
		public void TestDouble()
		{
			PdfNumber num = new PdfNumber(4711.12);
			Assert.AreEqual("4711.12", num.ToString());
		}

		/// <summary>
		/// Tests initialization from false string.
		/// </summary>
		[Test]
		[ExpectedException(typeof(FormatException))]
		public void TestWrongString()
		{
			PdfNumber num;

			num = new PdfNumber("4711bla");
		}
	}

	/// <summary>
	/// Tests the PdfName class.
	/// </summary>
	[TestFixture]
	public class PdfNameTest
	{
		/// <summary>
		/// Tests the PdfName class.
		/// </summary>
		[Test]
		public void TestPdfName()
		{
			PdfName name = new PdfName("/Ff");
			Assert.AreEqual("/Ff", name.ToString());
		}

		/// <summary>
		/// Tests wrong input.
		/// </summary>
		[Test]
		[ExpectedException(typeof(Exception))]
		public void TestWrongInput()
		{
			PdfName name;

			name = new PdfName("bla");
		}

		/// <summary>
		/// Test special characters.
		/// </summary>
		[Test]
		public void TestSpecial()
		{
			PdfName name;
			name = new PdfName("/A#20B");
			Assert.AreEqual("/A#20B", name.ToString());
			name = new PdfName("/A#00B");
			Assert.AreEqual("/A#00B", name.ToString());
			name = new PdfName("/A#ffB");
			Assert.AreEqual("/A#ffB", name.ToString());
			name = new PdfName("/A B");
			Assert.AreEqual("/A#20B", name.ToString());
			Assert.AreEqual(new PdfName("/A B"), new PdfName("/A#20B"));
			Assert.IsFalse(new PdfName("/A B").Equals(new PdfName("/A C")));
		}
	}

	/// <summary>
	/// Tests the PdfBool class.
	/// </summary>
	[TestFixture]
	public class PdfBoolTest
	{
		/// <summary>
		/// Tests the PdfBool class.
		/// </summary>
		[Test]
		public void TestPdfBool()
		{
			PdfBool b;
			b = new PdfBool(true);
			Assert.AreEqual("true", b.ToString());
			b = new PdfBool(false);
			Assert.AreEqual("false", b.ToString());
		}
	}

	/// <summary>
	/// Tests the PdfString class.
	/// </summary>
	[TestFixture]
	public class PdfStringTest
	{
		/// <summary>
		/// Tests the PdfString class.
		/// </summary>
		[Test]
		public void TestPdfString()
		{
			PdfString s;
			string input, output, compare;

			input = "hallo)";
			Assert.AreEqual("(hallo)", new PdfString(false, ref input).ToString());
			Assert.AreEqual("(hallo)", new PdfString("hallo").ToString());
			input = "( ) and\nspecial characters (*!&}^% and so on).)";
			Assert.AreEqual(@"(\( \) and" + "\n" + @"special characters \(*!&}^% and so on\).)", new PdfString(false, ref input).ToString());
			Assert.AreEqual("()", new PdfString("").ToString());
			input = "hallo \\\nballo)";
			Assert.AreEqual("(hallo ballo)", new PdfString(false, ref input).ToString());
			input = @"hallo\040ballo)";
			Assert.AreEqual("(hallo ballo)", new PdfString(false, ref input).ToString());
			input = @"hallo\tballo)";
			Assert.AreEqual("(hallo\tballo)", new PdfString(false, ref input).ToString());
			input = @"hallo\\ballo)";
			Assert.AreEqual("(hallo\\ballo)", new PdfString(false, ref input).ToString());
			input = "hallo\r\nballo)";
			Assert.AreEqual("(hallo\nballo)", new PdfString(false, ref input).ToString());
			input = "4E6F762073686D6F7A206B6120706F702E>";
			Assert.AreEqual("(Nov shmoz ka pop.)", new PdfString(true, ref input).ToString());
			input = "4E6F762>";
			Assert.AreEqual("(Nov )", new PdfString(true, ref input).ToString());
			input = "4E 6F 76 20 73 68 6D 6F 7A 20\n6B 61 20 70 6F 70 2E>";
			Assert.AreEqual("(Nov shmoz ka pop.)", new PdfString(true, ref input).ToString());
			input = "fe ff 004E 006F 0076 20ac>";
			input = new PdfString(true, ref input).ToString();
			Assert.AreEqual("(\u00fe\u00ff\u0000N\u0000o\u0000v\u0020\u00ac)", input);
			input = "\u00fe\u00ff\u0020\u00ac)";
			s = new PdfString(false, ref input);
			input = s.ToString();
			Assert.AreEqual("\u20ac", s.Text);
			Assert.AreEqual("(\u00fe\u00ff\u0020\u00ac)", input);
			input = "This is a string)";
			Assert.AreEqual("(This is a string)", new PdfString(false, ref input).ToString());
			input = "Strings may contain balanced parentheses ( ) and\nspecial characters (*!&}^% and so on).)";
			PdfString str = new PdfString(false, ref input);
			output = str.ToString();
			compare = "(Strings may contain balanced parentheses \\( \\) and\nspecial characters \\(*!&}^% and so on\\).)";
			Assert.AreEqual(compare, output);
			input = ")";
			Assert.AreEqual("()", new PdfString(false, ref input).ToString());
			input = @"Hallo \) Ballo)";
			Assert.AreEqual(@"(Hallo \) Ballo)", new PdfString(false, ref input).ToString());
		}
	}

	/// <summary>
	/// Tests the PdfArray class.
	/// </summary>
	[TestFixture]
	public class PdfArrayTest
	{
		/// <summary>
		/// Tests the PdfArray class.
		/// </summary>
		[Test]
		public void TestPdfArray()
		{
			PdfArray array;
			string input;

			input = "4711 /Name true ]";
			array = new PdfArray(ref input);
			Assert.AreEqual(3, array.Elements.Count);
			Assert.AreEqual(typeof (PdfNumber), array[0].GetType());
			Assert.AreEqual(typeof (PdfName), array[1].GetType());
			Assert.AreEqual(typeof (PdfBool), array[2].GetType());
			array.Elements.Add(new PdfString("hallo"));
			Assert.AreEqual("[ 4711 /Name true (hallo) ]", array.ToString());
			array = new PdfArray(new PdfBool(false), new PdfNull());
			Assert.AreEqual("[ false null ]", array.ToString());
		}
	}

	/// <summary>
	/// Tests the PdfDictionary class.
	/// </summary>
	[TestFixture]
	public class PdfDictionaryTest
	{
		/// <summary>
		/// Tests the PdfDictionary class.
		/// </summary>
		[Test]
		public void TestPdfDictionary()
		{
			PdfDictionary dict;
			string input;

			input = "/key1 4711 /key2 false /key3 /V >>";
			dict = new PdfDictionary(ref input);
			Assert.AreEqual(3, dict.Dictionary.Count);
			Assert.AreEqual(typeof (PdfNumber), dict["/key1"].GetType());
			Assert.AreEqual(typeof (PdfBool), dict["/key2"].GetType());
			Assert.AreEqual(typeof (PdfName), dict["/key3"].GetType());
			Hashtable hashtable = new Hashtable();
			hashtable.Add(new PdfName("/AP"), new PdfNull());
			dict = new PdfDictionary(hashtable);
			Assert.AreEqual("<<\n/AP null\n >>", dict.ToString());
			input = "/V/Bla>>";
			dict = new PdfDictionary(ref input);
			Assert.AreEqual("<<\n/V /Bla\n >>", dict.ToString());
		}
	}

	/// <summary>
	/// Tests the PdfObject class.
	/// </summary>
	[TestFixture]
	public class PdfObjectTest
	{
		/// <summary>
		/// Tests the PdfObject class.
		/// </summary>
		[Test]
		public void TestPdfObject()
		{
			string input;
			PdfObject o;

			input = "<< /V 4711 >> true 8 1 R";
			o = PdfObject.GetPdfObject(ref input);
			Assert.AreEqual(typeof (PdfDictionary), o.GetType());
			Assert.AreEqual(" true 8 1 R", input);
			o = PdfObject.GetPdfObject(ref input);
			Assert.AreEqual(typeof (PdfBool), o.GetType());
			Assert.AreEqual(" 8 1 R", input);
			o = PdfObject.GetPdfObject(ref input);
			Assert.AreEqual(typeof (PdfReference), o.GetType());
			Assert.AreEqual("", input);
			input = "4711 null [ ] << >> <feff20ac>";
			o = PdfObject.GetPdfObject(ref input);
			Assert.AreEqual(typeof (PdfNumber), o.GetType());
			Assert.AreEqual(" null [ ] << >> <feff20ac>", input);
			o = PdfObject.GetPdfObject(ref input);
			Assert.AreEqual(typeof (PdfNull), o.GetType());
			Assert.AreEqual(" [ ] << >> <feff20ac>", input);
			o = PdfObject.GetPdfObject(ref input);
			Assert.AreEqual(typeof (PdfArray), o.GetType());
			Assert.AreEqual(" << >> <feff20ac>", input);
			Assert.AreEqual(0, ((PdfArray)o).Elements.Count);
			o = PdfObject.GetPdfObject(ref input);
			Assert.AreEqual(typeof (PdfDictionary), o.GetType());
			Assert.AreEqual(" <feff20ac>", input);
			Assert.AreEqual(0, ((PdfDictionary)o).Dictionary.Count);
			o = PdfObject.GetPdfObject(ref input);
			Assert.AreEqual(typeof (PdfString), o.GetType());
			Assert.AreEqual("", input);
			input = "/Name%bla";
			Assert.AreEqual("/Name", PdfObject.GetPdfObject(ref input).ToString());
		}

		/// <summary>
		/// Tests parsing a strign that is not a PDF Object.
		/// </summary>
		[Test]
		[ExpectedException(typeof(FormatException))]
		public void TestWrongPdfObject()
		{
			string input;
			PdfObject o;

			input = "bla";
			o = PdfObject.GetPdfObject(ref input);
		}
	}

	/// <summary>
	/// Tests the PdfButtonField class.
	/// </summary>
	[TestFixture]
	public class PdfButtonFieldTest
	{
		/// <summary>
		/// Tests the PdfPushButtonField class.
		/// </summary>
		[Test]
		public void TestPdfButtonField()
		{
			PdfButtonField field;
			string input;

			input = "<< /FT /Btn /Ff 65536 /T (Günter) >>";
			field = PdfButtonField.GetButtonField(4711, 0, (PdfDictionary)PdfObject.GetPdfObject(ref input));
			Assert.AreEqual(typeof (PdfPushButtonField), field.GetType());
			Assert.AreEqual(4711, field.ObjectNumber);
			Assert.AreEqual(0, field.GenerationNumber);
			Assert.AreEqual(true, field.GetBit(17));
			Assert.AreEqual("Günter", field.Name);
		}

		/// <summary>
		/// Tests the PdfCheckBoxField class.
		/// </summary>
		[Test]
		public void TestPdfCheckBoxField()
		{
			PdfButtonField field;
			string input;

			input = "<< /FT /Btn /V /Off /AP << /N << /Off 0 /On 1 >> >> /T (Bla) >>";
			field = PdfButtonField.GetButtonField(4711, 0, (PdfDictionary)PdfObject.GetPdfObject(ref input));
			Assert.AreEqual(typeof (PdfCheckBoxField), field.GetType());
			PdfCheckBoxField f = (PdfCheckBoxField)field;
			Assert.AreEqual(f.Checked, false);
			f.Checked = true;
			Assert.AreEqual(true, f.ToString().IndexOf("/V /On") > 0);
		}

		/// <summary>
		/// Tests the PdfRadioButtonField class.
		/// </summary>
		[Test]
		public void TestPdfRadioButtonField()
		{
			PdfButtonField field;
			string input = "<< /FT /Btn /Ff 32768 /V /1 /T (Bla) >>";

			field = PdfButtonField.GetButtonField(4711, 0, (PdfDictionary)PdfObject.GetPdfObject(ref input));
			Assert.AreEqual(typeof (PdfRadioButtonField), field.GetType());
			PdfRadioButtonField f = (PdfRadioButtonField)field;
			Assert.AreEqual(f.SelectedItem, "1");
			f.SelectedItem = "2";
			Assert.AreEqual(true, f.ToString().IndexOf("/V /2") > 0);
		}
	}

	/// <summary>
	/// Tests the PdfTXField class.
	/// </summary>
	[TestFixture]
	public class PdfTXFieldTest
	{
		/// <summary>
		/// Tests the PdfTXField class.
		/// </summary>
		[Test]
		public void TestPdfTXField()
		{
			PdfTXField field;
			string input = "<< /FT /Tx /Ff 8192 /V (Tüüüt) /T (Bla) >>";

			field = new PdfTXField(4711, 0, (PdfDictionary)PdfObject.GetPdfObject(ref input));
			Assert.AreEqual(typeof (PdfTXField), field.GetType());
			Assert.AreEqual("Tüüüt", field.Text);
			field.Text = "4711 \u20ac";
			Assert.AreEqual(true, field.ToString().IndexOf("(\u00fe\u00ff\u00004\u00007\u00001\u00001\u0000 \u0020\u00ac)") > 0);
			Assert.AreEqual(true, field.Password);
		}

	}

	/// <summary>
	/// Tests the PdfCHField class.
	/// </summary>
	[TestFixture]
	public class PdfCHFieldTest
	{
		/// <summary>
		/// Tests the PdfCHField class.
		/// </summary>
		[Test]
		public void TestPdfCHField()
		{
			PdfCHField field;
			string input = "<</FT /Ch /I [ 1 2 3 ] /T (Bla) >>";

			field = new PdfCHField(4711, 0, (PdfDictionary)PdfObject.GetPdfObject(ref input));
			Assert.AreEqual(typeof (PdfCHField), field.GetType());
			Assert.AreEqual(3, field.GetSelectedIndexes().Length);
			Assert.AreEqual(1, field.GetSelectedIndexes()[0]);
			Assert.AreEqual(2, field.GetSelectedIndexes()[1]);
			Assert.AreEqual(3, field.GetSelectedIndexes()[2]);
			field.SetSelectedIndexes(4711);
			Assert.AreEqual(true, field.ToString().IndexOf("/I 4711") > 0);
			input = "<< /FT /Ch /I null /T (Bla) >>";
			field = new PdfCHField(4711, 0, (PdfDictionary)PdfObject.GetPdfObject(ref input));
			Assert.AreEqual(0, field.GetSelectedIndexes().Length);
		}
	}

	/// <summary>
	/// Tests the PdfForm class.
	/// </summary>
	[TestFixture]
	public class PdfFormTest
	{
		/// <summary>
		/// Tests the PdfForm class.
		/// </summary>
		[Test]
		public void TestPdfForm()
		{
			string input;
			input = "<< /V 1 >>";
			PdfForm form = new PdfForm(4711, 0, (PdfDictionary)PdfObject.GetPdfObject(ref input));
			Assert.AreEqual(true, form.ToString().IndexOf("/NeedAppearances true") > 0);
		}
	}
	
//	Uncomment the next class if you have the MISReq.pdf file contained in the Adobe Acrobat Forms Samples
//	package at http://www.adobe.com/support/downloads/detail.jsp?ftpID=328.
//	The pdf file must be included in the project and marked as "Embedded Resource" 
//	(in the properties window).
//	I didn't include the file in the source package because of size and possible copyright issues.

//	/// <summary>
//	/// Tests the PdfReader class.
//	/// </summary>
//	[TestFixture]
//	public class PdfReaderTest
//	{
//		/// <summary>
//		/// Tests the PdfReader class.
//		/// </summary>
//		[Test]
//		public void TestPdfReader()
//		{
//			Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
//
//			System.IO.Stream stream = 
//				assembly.GetManifestResourceStream("OOGroup.PDF.MISReq.pdf");
//
//			PdfReader reader = new PdfReader(stream);
//
//			PdfTXField txField = (PdfTXField)reader.FieldsByName["name"];
//			txField.Text = "Jürgen";
//
//			MemoryStream memStream = new MemoryStream();
//			reader.WritePdf(memStream);
//
//			byte[] bytes = memStream.ToArray();
//
//			memStream.Position = 0;
//			reader = new PdfReader(memStream);
//
//			byte[] bytes2 = memStream.ToArray();
//
//			Assert.AreEqual(bytes.Length, bytes2.Length);
//
//			for(int i = 0; i < bytes.Length; i++)
//			{
//				Assert.AreEqual(bytes[i], bytes2[i]);
//			}
//		}
//
//		/// <summary>
//		/// Test the performance of PdfReader.
//		/// </summary>
//		public static void Main()
//		{
//			Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
//
//			System.IO.Stream stream = 
//				assembly.GetManifestResourceStream("OOGroup.PDF.MISReq.pdf");
//
//			PdfReader reader = new PdfReader(stream);
//		}
//	}

	/// <summary>
	/// Test using the Adobe AcroForms Samples.
	/// </summary>
	[TestFixture]
	public class SamplesTest
	{
		private MemoryStream memoryStream = new MemoryStream();

		/// <summary>
		/// Tests one sample by reading and writing it.
		/// Not a very thorough test :-)
		/// </summary>
		/// <param name="fileName">File name of the sample</param>
		public void SampleTest(string fileName)
		{
			Console.WriteLine("Testing sample " + fileName);
			PdfReader reader = PdfReader.GetPdfReader(fileName);
			Console.WriteLine("Number of fields: " + reader.Fields.Length);
			memoryStream.Position = 0;
			reader.WritePdf(memoryStream);
			Console.WriteLine("Done testing sample " + fileName);
		}

		/// <summary>
		/// Tests all samples.
		/// </summary>
		[Test]
		public void TestAllSamples()
		{
			DirectoryInfo dirInfo = new DirectoryInfo("../../samples");
			foreach (FileInfo file in dirInfo.GetFiles("*.pdf"))
			{
				SampleTest(file.FullName);
			}
			foreach (DirectoryInfo subdirInfo in dirInfo.GetDirectories())
			{
				foreach (FileInfo file in subdirInfo.GetFiles("*.pdf"))
				{
					SampleTest(file.FullName);
				}
			}
		}
	}
}
