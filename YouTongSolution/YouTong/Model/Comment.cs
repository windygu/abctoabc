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
	/// 表名：ut_Comment 主键列：ID
	/// </summary>
	[SerializableAttribute()]
	public partial class Comment : Entity
	{

		protected Guid _ID;

		protected DateTime _AddTime;

		protected DateTime _UpdateTime;

		protected Boolean _IsDeleted;

		protected Guid? _Reviewer;

		protected Int16 _Score;

		protected String _Entity;

		protected Guid _EntityID;

		protected String _Title;

		protected String _Body;

		public Guid ID
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

		public Guid? Reviewer
		{
			get
			{
				return this._Reviewer;
			}
			set
			{
				this.OnPropertyValueChange(_.Reviewer, _Reviewer, value);
				this._Reviewer = value;
			}
		}

		public Int16 Score
		{
			get
			{
				return this._Score;
			}
			set
			{
				this.OnPropertyValueChange(_.Score, _Score, value);
				this._Score = value;
			}
		}

		public String Entity
		{
			get
			{
				return this._Entity;
			}
			set
			{
				this.OnPropertyValueChange(_.Entity, _Entity, value);
				this._Entity = value;
			}
		}

		public Guid EntityID
		{
			get
			{
				return this._EntityID;
			}
			set
			{
				this.OnPropertyValueChange(_.EntityID, _EntityID, value);
				this._EntityID = value;
			}
		}

		public String Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				this.OnPropertyValueChange(_.Title, _Title, value);
				this._Title = value;
			}
		}

		public String Body
		{
			get
			{
				return this._Body;
			}
			set
			{
				this.OnPropertyValueChange(_.Body, _Body, value);
				this._Body = value;
			}
		}

		/// <summary>
		/// 获取实体对应的表名
		/// </summary>
		protected override Table GetTable()
		{
			return new Table<Comment>("ut_Comment");
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
                        _.Reviewer,
                        _.Score,
                        _.Entity,
                        _.EntityID,
                        _.Title,
                        _.Body};
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
                        this._Reviewer,
                        this._Score,
                        this._Entity,
                        this._EntityID,
                        this._Title,
                        this._Body};
		}

		/// <summary>
		/// 给当前实体赋值
		/// </summary>
		protected override void SetValues(IRowReader reader)
		{
			if ((false == reader.IsDBNull(_.ID)))
			{
				this._ID = reader.GetGuid(_.ID);
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
			if ((false == reader.IsDBNull(_.Reviewer)))
			{
				this._Reviewer = reader.GetGuid(_.Reviewer);
			}
			if ((false == reader.IsDBNull(_.Score)))
			{
				this._Score = reader.GetInt16(_.Score);
			}
			if ((false == reader.IsDBNull(_.Entity)))
			{
				this._Entity = reader.GetString(_.Entity);
			}
			if ((false == reader.IsDBNull(_.EntityID)))
			{
				this._EntityID = reader.GetGuid(_.EntityID);
			}
			if ((false == reader.IsDBNull(_.Title)))
			{
				this._Title = reader.GetString(_.Title);
			}
			if ((false == reader.IsDBNull(_.Body)))
			{
				this._Body = reader.GetString(_.Body);
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
			if ((false == typeof(Comment).IsAssignableFrom(obj.GetType())))
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
			public static AllField All = new AllField<Comment>();

			/// <summary>
			/// 字段名：ID - 数据类型：Guid
			/// </summary>
			public static Field ID = new Field<Comment>("ID");

			/// <summary>
			/// 字段名：AddTime - 数据类型：DateTime
			/// </summary>
			public static Field AddTime = new Field<Comment>("AddTime");

			/// <summary>
			/// 字段名：UpdateTime - 数据类型：DateTime
			/// </summary>
			public static Field UpdateTime = new Field<Comment>("UpdateTime");

			/// <summary>
			/// 字段名：IsDeleted - 数据类型：Boolean
			/// </summary>
			public static Field IsDeleted = new Field<Comment>("IsDeleted");

			/// <summary>
			/// 字段名：Reviewer - 数据类型：Nullable`1
			/// </summary>
			public static Field Reviewer = new Field<Comment>("Reviewer");

			/// <summary>
			/// 字段名：Score - 数据类型：Int16
			/// </summary>
			public static Field Score = new Field<Comment>("Score");

			/// <summary>
			/// 字段名：Entity - 数据类型：String
			/// </summary>
			public static Field Entity = new Field<Comment>("Entity");

			/// <summary>
			/// 字段名：EntityID - 数据类型：Guid
			/// </summary>
			public static Field EntityID = new Field<Comment>("EntityID");

			/// <summary>
			/// 字段名：Title - 数据类型：String
			/// </summary>
			public static Field Title = new Field<Comment>("Title");

			/// <summary>
			/// 字段名：Body - 数据类型：String
			/// </summary>
			public static Field Body = new Field<Comment>("Body");
		}
	}
}
