using System;
using hwj.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类tbHPInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class tbHPInfo : iTable
	{
		public tbHPInfo()
		{}
		public enum Fields
		{
			ID,
			Name,
			RightsCode,
			Password,
			LastLogin,
			CreateOn,
			CreateBy,
			UpdateOn,
			UpdateBy,
		}

		public static string TableName
		{
			get { return "tbHPInfo"; }
		}

		#region Model
		private Int32 _id;
		private String _name;
		private Int32 _rightscode;
		private String _password;
		private DateTime _lastlogin;
		private DateTime? _createon;
		private String _createby;
		private DateTime _updateon;
		private String _updateby;
		/// <summary>
		/// 
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
		/// 方便以后权限扩展
		/// </summary>
		[FieldMapping("RightsCode", TypeCode.Int32)]
		public Int32 RightsCode
		{
			set{ _rightscode=value;}
			get{return _rightscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("Password", TypeCode.String)]
		public String Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("LastLogin", TypeCode.DateTime)]
		public DateTime LastLogin
		{
			set{ _lastlogin=value;}
			get{return _lastlogin;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CreateOn", TypeCode.DateTime)]
		public DateTime? CreateOn
		{
			set{ _createon=value;}
			get{return _createon;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CreateBy", TypeCode.String)]
		public String CreateBy
		{
			set{ _createby=value;}
			get{return _createby;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("UpdateOn", TypeCode.DateTime)]
		public DateTime UpdateOn
		{
			set{ _updateon=value;}
			get{return _updateon;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("UpdateBy", TypeCode.String)]
		public String UpdateBy
		{
			set{ _updateby=value;}
			get{return _updateby;}
		}
		#endregion Model

	}
}

