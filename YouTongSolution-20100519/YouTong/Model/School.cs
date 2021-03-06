﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.4927
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YouTong.Model
{
	using System;
	using MySoft.Data;


	/// <summary>
	/// 表名：ut_School 主键列：ID
	/// </summary>
	[SerializableAttribute()]
	public partial class School : Entity
	{

		protected Int32 _ID;

		protected DateTime _AddTime;

		protected DateTime _UpdateTime;

		protected Boolean _IsDeleted;

		protected String _Name;

		protected String _Website;

		protected Int32 _Speciality;

		protected Int32 _Region;

		protected String _Address;

		protected String _Charger;

		protected String _Cellphone;

		protected String _Email;

		protected Int32 _Type;

		protected Byte _Level;

		protected String _Description;

		protected Int32? _AlbumID;

		protected String _Announcement;

		public Int32 ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				this.OnPropertyValueChange(_.ID, _ID, value);
				this._ID = value;
			}
		}

		public DateTime AddTime
		{
			get
			{
				return this._AddTime;
			}
			set
			{
				this.OnPropertyValueChange(_.AddTime, _AddTime, value);
				this._AddTime = value;
			}
		}

		public DateTime UpdateTime
		{
			get
			{
				return this._UpdateTime;
			}
			set
			{
				this.OnPropertyValueChange(_.UpdateTime, _UpdateTime, value);
				this._UpdateTime = value;
			}
		}

		public Boolean IsDeleted
		{
			get
			{
				return this._IsDeleted;
			}
			set
			{
				this.OnPropertyValueChange(_.IsDeleted, _IsDeleted, value);
				this._IsDeleted = value;
			}
		}

		public String Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this.OnPropertyValueChange(_.Name, _Name, value);
				this._Name = value;
			}
		}

		public String Website
		{
			get
			{
				return this._Website;
			}
			set
			{
				this.OnPropertyValueChange(_.Website, _Website, value);
				this._Website = value;
			}
		}

		public Int32 Speciality
		{
			get
			{
				return this._Speciality;
			}
			set
			{
				this.OnPropertyValueChange(_.Speciality, _Speciality, value);
				this._Speciality = value;
			}
		}

		public Int32 Region
		{
			get
			{
				return this._Region;
			}
			set
			{
				this.OnPropertyValueChange(_.Region, _Region, value);
				this._Region = value;
			}
		}

		public String Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				this.OnPropertyValueChange(_.Address, _Address, value);
				this._Address = value;
			}
		}

		public String Charger
		{
			get
			{
				return this._Charger;
			}
			set
			{
				this.OnPropertyValueChange(_.Charger, _Charger, value);
				this._Charger = value;
			}
		}

		public String Cellphone
		{
			get
			{
				return this._Cellphone;
			}
			set
			{
				this.OnPropertyValueChange(_.Cellphone, _Cellphone, value);
				this._Cellphone = value;
			}
		}

		public String Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				this.OnPropertyValueChange(_.Email, _Email, value);
				this._Email = value;
			}
		}

		public Int32 Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this.OnPropertyValueChange(_.Type, _Type, value);
				this._Type = value;
			}
		}

		public Byte Level
		{
			get
			{
				return this._Level;
			}
			set
			{
				this.OnPropertyValueChange(_.Level, _Level, value);
				this._Level = value;
			}
		}

		public String Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				this.OnPropertyValueChange(_.Description, _Description, value);
				this._Description = value;
			}
		}

		public Int32? AlbumID
		{
			get
			{
				return this._AlbumID;
			}
			set
			{
				this.OnPropertyValueChange(_.AlbumID, _AlbumID, value);
				this._AlbumID = value;
			}
		}

		public String Announcement
		{
			get
			{
				return this._Announcement;
			}
			set
			{
				this.OnPropertyValueChange(_.Announcement, _Announcement, value);
				this._Announcement = value;
			}
		}

		/// <summary>
		/// 获取实体对应的表名
		/// </summary>
		protected override Table GetTable()
		{
			return new Table<School>("ut_School");
		}

		/// <summary>
		/// 获取实体中的标识列
		/// </summary>
		protected override Field GetIdentityField()
		{
			return _.ID;
		}

		/// <summary>
		/// 获取实体中的主键列
		/// </summary>
		protected override Field[] GetPrimaryKeyFields()
		{
			return new Field[] {
                        _.ID};
		}

		/// <summary>
		/// 获取列信息
		/// </summary>
		protected override Field[] GetFields()
		{
			return new Field[] {
                        _.ID,
                        _.AddTime,
                        _.UpdateTime,
                        _.IsDeleted,
                        _.Name,
                        _.Website,
                        _.Speciality,
                        _.Region,
                        _.Address,
                        _.Charger,
                        _.Cellphone,
                        _.Email,
                        _.Type,
                        _.Level,
                        _.Description,
                        _.AlbumID,
                        _.Announcement};
		}

		/// <summary>
		/// 获取列数据
		/// </summary>
		protected override object[] GetValues()
		{
			return new object[] {
                        this._ID,
                        this._AddTime,
                        this._UpdateTime,
                        this._IsDeleted,
                        this._Name,
                        this._Website,
                        this._Speciality,
                        this._Region,
                        this._Address,
                        this._Charger,
                        this._Cellphone,
                        this._Email,
                        this._Type,
                        this._Level,
                        this._Description,
                        this._AlbumID,
                        this._Announcement};
		}

		/// <summary>
		/// 给当前实体赋值
		/// </summary>
		protected override void SetValues(IRowReader reader)
		{
			if ((false == reader.IsDBNull(_.ID)))
			{
				this._ID = reader.GetInt32(_.ID);
			}
			if ((false == reader.IsDBNull(_.AddTime)))
			{
				this._AddTime = reader.GetDateTime(_.AddTime);
			}
			if ((false == reader.IsDBNull(_.UpdateTime)))
			{
				this._UpdateTime = reader.GetDateTime(_.UpdateTime);
			}
			if ((false == reader.IsDBNull(_.IsDeleted)))
			{
				this._IsDeleted = reader.GetBoolean(_.IsDeleted);
			}
			if ((false == reader.IsDBNull(_.Name)))
			{
				this._Name = reader.GetString(_.Name);
			}
			if ((false == reader.IsDBNull(_.Website)))
			{
				this._Website = reader.GetString(_.Website);
			}
			if ((false == reader.IsDBNull(_.Speciality)))
			{
				this._Speciality = reader.GetInt32(_.Speciality);
			}
			if ((false == reader.IsDBNull(_.Region)))
			{
				this._Region = reader.GetInt32(_.Region);
			}
			if ((false == reader.IsDBNull(_.Address)))
			{
				this._Address = reader.GetString(_.Address);
			}
			if ((false == reader.IsDBNull(_.Charger)))
			{
				this._Charger = reader.GetString(_.Charger);
			}
			if ((false == reader.IsDBNull(_.Cellphone)))
			{
				this._Cellphone = reader.GetString(_.Cellphone);
			}
			if ((false == reader.IsDBNull(_.Email)))
			{
				this._Email = reader.GetString(_.Email);
			}
			if ((false == reader.IsDBNull(_.Type)))
			{
				this._Type = reader.GetInt32(_.Type);
			}
			if ((false == reader.IsDBNull(_.Level)))
			{
				this._Level = reader.GetByte(_.Level);
			}
			if ((false == reader.IsDBNull(_.Description)))
			{
				this._Description = reader.GetString(_.Description);
			}
			if ((false == reader.IsDBNull(_.AlbumID)))
			{
				this._AlbumID = reader.GetInt32(_.AlbumID);
			}
			if ((false == reader.IsDBNull(_.Announcement)))
			{
				this._Announcement = reader.GetString(_.Announcement);
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if ((obj == null))
			{
				return false;
			}
			if ((false == typeof(School).IsAssignableFrom(obj.GetType())))
			{
				return false;
			}
			if ((((object)(this)) == ((object)(obj))))
			{
				return true;
			}
			return false;
		}

		public class _
		{

			/// <summary>
			/// 表示选择所有列，与*等同
			/// </summary>
			public static AllField All = new AllField<School>();

			/// <summary>
			/// 字段名：ID - 数据类型：Int32
			/// </summary>
			public static Field ID = new Field<School>("ID");

			/// <summary>
			/// 字段名：AddTime - 数据类型：DateTime
			/// </summary>
			public static Field AddTime = new Field<School>("AddTime");

			/// <summary>
			/// 字段名：UpdateTime - 数据类型：DateTime
			/// </summary>
			public static Field UpdateTime = new Field<School>("UpdateTime");

			/// <summary>
			/// 字段名：IsDeleted - 数据类型：Boolean
			/// </summary>
			public static Field IsDeleted = new Field<School>("IsDeleted");

			/// <summary>
			/// 字段名：Name - 数据类型：String
			/// </summary>
			public static Field Name = new Field<School>("Name");

			/// <summary>
			/// 字段名：Website - 数据类型：String
			/// </summary>
			public static Field Website = new Field<School>("Website");

			/// <summary>
			/// 字段名：Speciality - 数据类型：Int32
			/// </summary>
			public static Field Speciality = new Field<School>("Speciality");

			/// <summary>
			/// 字段名：Region - 数据类型：Int32
			/// </summary>
			public static Field Region = new Field<School>("Region");

			/// <summary>
			/// 字段名：Address - 数据类型：String
			/// </summary>
			public static Field Address = new Field<School>("Address");

			/// <summary>
			/// 字段名：Charger - 数据类型：String
			/// </summary>
			public static Field Charger = new Field<School>("Charger");

			/// <summary>
			/// 字段名：Cellphone - 数据类型：String
			/// </summary>
			public static Field Cellphone = new Field<School>("Cellphone");

			/// <summary>
			/// 字段名：Email - 数据类型：String
			/// </summary>
			public static Field Email = new Field<School>("Email");

			/// <summary>
			/// 字段名：Type - 数据类型：Int32
			/// </summary>
			public static Field Type = new Field<School>("Type");

			/// <summary>
			/// 字段名：Level - 数据类型：Byte
			/// </summary>
			public static Field Level = new Field<School>("Level");

			/// <summary>
			/// 字段名：Description - 数据类型：String
			/// </summary>
			public static Field Description = new Field<School>("Description");

			/// <summary>
			/// 字段名：AlbumID - 数据类型：Nullable`1
			/// </summary>
			public static Field AlbumID = new Field<School>("AlbumID");

			/// <summary>
			/// 字段名：Announcement - 数据类型：String
			/// </summary>
			public static Field Announcement = new Field<School>("Announcement");
		}
	}
}
