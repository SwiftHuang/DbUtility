using System;
using hwj.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类tbSickInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class tbSickInfo : iTable
	{
		public tbSickInfo()
		{}
		public enum Fields
		{
			ID,
			HP_ID,
			Name,
			IDCardNum,
			Sex,
			Telphone,
			Cellphone,
			Address,
			BabyBirthDate,
			MontherPlace,
			FatherPlace,
			InHPNum,
			BloodTime,
			MontherAge,
			BirthRank,
			SuckleTimes,
			BabyAge,
			BabyWeight,
			BabyIsHypoxia,
			DeliveryType,
			CreateOn,
			CreateBy,
			UpdateOn,
			UpdateBy,
		}

		public static string TableName
		{
			get { return "tbSickInfo"; }
		}

		#region Model
		private Decimal _id;
		private Int32? _hp_id;
		private String _name;
		private String _idcardnum;
		private String _sex;
		private String _telphone;
		private String _cellphone;
		private String _address;
		private DateTime? _babybirthdate;
		private String _montherplace;
		private String _fatherplace;
		private String _inhpnum;
		private DateTime? _bloodtime;
		private Int32? _montherage;
		private Int32? _birthrank;
		private Int32? _suckletimes;
		private Int32? _babyage;
		private Int32? _babyweight;
		private String _babyishypoxia;
		private String _deliverytype;
		private DateTime? _createon;
		private String _createby;
		private DateTime? _updateon;
		private String _updateby;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ID", TypeCode.Decimal)]
		public Decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HP_ID", TypeCode.Int32)]
		public Int32? HP_ID
		{
			set{ _hp_id=value;}
			get{return _hp_id;}
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
		[FieldMapping("IDCardNum", TypeCode.String)]
		public String IDCardNum
		{
			set{ _idcardnum=value;}
			get{return _idcardnum;}
		}
		/// <summary>
		/// M or W
		/// </summary>
		[FieldMapping("Sex", TypeCode.String)]
		public String Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 固话
		/// </summary>
		[FieldMapping("Telphone", TypeCode.String)]
		public String Telphone
		{
			set{ _telphone=value;}
			get{return _telphone;}
		}
		/// <summary>
		/// 移动电话
		/// </summary>
		[FieldMapping("Cellphone", TypeCode.String)]
		public String Cellphone
		{
			set{ _cellphone=value;}
			get{return _cellphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("Address", TypeCode.String)]
		public String Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BabyBirthDate", TypeCode.DateTime)]
		public DateTime? BabyBirthDate
		{
			set{ _babybirthdate=value;}
			get{return _babybirthdate;}
		}
		/// <summary>
		/// 母亲籍贯
		/// </summary>
		[FieldMapping("MontherPlace", TypeCode.String)]
		public String MontherPlace
		{
			set{ _montherplace=value;}
			get{return _montherplace;}
		}
		/// <summary>
		/// 父亲籍贯
		/// </summary>
		[FieldMapping("FatherPlace", TypeCode.String)]
		public String FatherPlace
		{
			set{ _fatherplace=value;}
			get{return _fatherplace;}
		}
		/// <summary>
		/// 住院号
		/// </summary>
		[FieldMapping("InHPNum", TypeCode.String)]
		public String InHPNum
		{
			set{ _inhpnum=value;}
			get{return _inhpnum;}
		}
		/// <summary>
		/// 采血日期、时间
		/// </summary>
		[FieldMapping("BloodTime", TypeCode.DateTime)]
		public DateTime? BloodTime
		{
			set{ _bloodtime=value;}
			get{return _bloodtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("MontherAge", TypeCode.Int32)]
		public Int32? MontherAge
		{
			set{ _montherage=value;}
			get{return _montherage;}
		}
		/// <summary>
		/// 胎序
		/// </summary>
		[FieldMapping("BirthRank", TypeCode.Int32)]
		public Int32? BirthRank
		{
			set{ _birthrank=value;}
			get{return _birthrank;}
		}
		/// <summary>
		/// 喂奶次数
		/// </summary>
		[FieldMapping("SuckleTimes", TypeCode.Int32)]
		public Int32? SuckleTimes
		{
			set{ _suckletimes=value;}
			get{return _suckletimes;}
		}
		/// <summary>
		/// 胎龄(周)
		/// </summary>
		[FieldMapping("BabyAge", TypeCode.Int32)]
		public Int32? BabyAge
		{
			set{ _babyage=value;}
			get{return _babyage;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BabyWeight", TypeCode.Int32)]
		public Int32? BabyWeight
		{
			set{ _babyweight=value;}
			get{return _babyweight;}
		}
		/// <summary>
		/// 围产期是否缺氧
		/// </summary>
		[FieldMapping("BabyIsHypoxia", TypeCode.String)]
		public String BabyIsHypoxia
		{
			set{ _babyishypoxia=value;}
			get{return _babyishypoxia;}
		}
		/// <summary>
		/// 0=顺产 1=剖腹产 2=早产
		/// </summary>
		[FieldMapping("DeliveryType", TypeCode.String)]
		public String DeliveryType
		{
			set{ _deliverytype=value;}
			get{return _deliverytype;}
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
		public DateTime? UpdateOn
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

