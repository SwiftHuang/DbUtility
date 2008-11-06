using System;
using hwj.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类testtable 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class testtable : iTable
	{
		public testtable()
		{}
		public enum Fields
		{
			ID,
			Name,
			Phone,
			CreateOn,
		}

		public static string TableName
		{
			get { return "testtable"; }
		}

		#region Model
		private Int32 _id;
		private String _name;
		private Int32 _phone;
		private DateTime _createon;
		/// <summary>
		/// auto_increment
		/// </summary>
		[FieldMapping("ID", TypeCode.Int32)]
		public Int32 ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("Name", TypeCode.String)]
		public String Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("Phone", TypeCode.Int32)]
		public Int32 Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CreateOn", TypeCode.DateTime)]
		public DateTime CreateOn
		{
			set{ _createon=value;}
			get{return _createon;}
		}
		#endregion Model

	}
}

