using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类spe_endorse 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class spe_endorse : iTable
	{
		public spe_endorse()
		{}
		public enum Fields
		{
			SPE_CODE,
			SPE_CRE_EMP,
			SPE_CRE_DATE,
		}

		public static string TableName
		{
			get { return "spe_endorse"; }
		}

		#region Model
		private String _spe_code;
		private String _spe_cre_emp;
		private DateTime? _spe_cre_date;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("SPE_CODE", TypeCode.String)]
		public String SPE_CODE
		{
			set{ _spe_code=value;}
			get{return _spe_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("SPE_CRE_EMP", TypeCode.String)]
		public String SPE_CRE_EMP
		{
			set{ _spe_cre_emp=value;}
			get{return _spe_cre_emp;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("SPE_CRE_DATE", TypeCode.DateTime)]
		public DateTime? SPE_CRE_DATE
		{
			set{ _spe_cre_date=value;}
			get{return _spe_cre_date;}
		}
		#endregion Model

	}
}

