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
    /// 表名：ut_Child 主键列：ID
    /// </summary>
    [SerializableAttribute()]
    public partial class Child : Entity
    {

        protected Guid _ID;

        protected DateTime _AddTime;

        protected DateTime _UpdateTime;

        protected Boolean _IsDeleted;

        protected Guid? _ParentID;

        protected String _Name;

        protected String _NikcName;

        protected Byte _Gender;

        protected DateTime _Birthday;

        protected String _HeadPicture;

        protected Int32 _Care;

        protected Int32 _Popular;

        protected Int32 _City;

        protected Int32 _Region;

        protected String _CurrentSchool;

        protected Int32 _CurrentGrade;

        protected Byte _CurrentClass;

        protected Int32? _OldId;

        protected Int32 _SchoolID;

        protected String _Talent;

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

        /// <summary>
        /// 孩子家长账户ID
        /// </summary>
        public Guid? ParentID
        {
            get
            {
                return this._ParentID;
            }
            set
            {
                this.OnPropertyValueChange(_.ParentID, _ParentID, value);
                this._ParentID = value;
            }
        }

        /// <summary>
        /// 孩子姓名
        /// </summary>
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

        /// <summary>
        /// 孩子昵称
        /// </summary>
        public String NikcName
        {
            get
            {
                return this._NikcName;
            }
            set
            {
                this.OnPropertyValueChange(_.NikcName, _NikcName, value);
                this._NikcName = value;
            }
        }

        public Byte Gender
        {
            get
            {
                return this._Gender;
            }
            set
            {
                this.OnPropertyValueChange(_.Gender, _Gender, value);
                this._Gender = value;
            }
        }

        /// <summary>
        /// 孩子的生日
        /// </summary>
        public DateTime Birthday
        {
            get
            {
                return this._Birthday;
            }
            set
            {
                this.OnPropertyValueChange(_.Birthday, _Birthday, value);
                this._Birthday = value;
            }
        }

        public String HeadPicture
        {
            get
            {
                return this._HeadPicture;
            }
            set
            {
                this.OnPropertyValueChange(_.HeadPicture, _HeadPicture, value);
                this._HeadPicture = value;
            }
        }

        public Int32 Care
        {
            get
            {
                return this._Care;
            }
            set
            {
                this.OnPropertyValueChange(_.Care, _Care, value);
                this._Care = value;
            }
        }

        public Int32 Popular
        {
            get
            {
                return this._Popular;
            }
            set
            {
                this.OnPropertyValueChange(_.Popular, _Popular, value);
                this._Popular = value;
            }
        }

        public Int32 City
        {
            get
            {
                return this._City;
            }
            set
            {
                this.OnPropertyValueChange(_.City, _City, value);
                this._City = value;
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

        public String CurrentSchool
        {
            get
            {
                return this._CurrentSchool;
            }
            set
            {
                this.OnPropertyValueChange(_.CurrentSchool, _CurrentSchool, value);
                this._CurrentSchool = value;
            }
        }

        public Int32 CurrentGrade
        {
            get
            {
                return this._CurrentGrade;
            }
            set
            {
                this.OnPropertyValueChange(_.CurrentGrade, _CurrentGrade, value);
                this._CurrentGrade = value;
            }
        }

        public Byte CurrentClass
        {
            get
            {
                return this._CurrentClass;
            }
            set
            {
                this.OnPropertyValueChange(_.CurrentClass, _CurrentClass, value);
                this._CurrentClass = value;
            }
        }

        public Int32? OldId
        {
            get
            {
                return this._OldId;
            }
            set
            {
                this.OnPropertyValueChange(_.OldId, _OldId, value);
                this._OldId = value;
            }
        }

        public Int32 SchoolID
        {
            get
            {
                return this._SchoolID;
            }
            set
            {
                this.OnPropertyValueChange(_.SchoolID, _SchoolID, value);
                this._SchoolID = value;
            }
        }

        public String Talent
        {
            get
            {
                return this._Talent;
            }
            set
            {
                this.OnPropertyValueChange(_.Talent, _Talent, value);
                this._Talent = value;
            }
        }

        /// <summary>
        /// 获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<Child>("ut_Child");
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
                        _.ParentID,
                        _.Name,
                        _.NikcName,
                        _.Gender,
                        _.Birthday,
                        _.HeadPicture,
                        _.Care,
                        _.Popular,
                        _.City,
                        _.Region,
                        _.CurrentSchool,
                        _.CurrentGrade,
                        _.CurrentClass,
                        _.OldId,
                        _.SchoolID,
                        _.Talent};
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
                        this._ParentID,
                        this._Name,
                        this._NikcName,
                        this._Gender,
                        this._Birthday,
                        this._HeadPicture,
                        this._Care,
                        this._Popular,
                        this._City,
                        this._Region,
                        this._CurrentSchool,
                        this._CurrentGrade,
                        this._CurrentClass,
                        this._OldId,
                        this._SchoolID,
                        this._Talent};
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
            if ((false == reader.IsDBNull(_.ParentID)))
            {
                this._ParentID = reader.GetGuid(_.ParentID);
            }
            if ((false == reader.IsDBNull(_.Name)))
            {
                this._Name = reader.GetString(_.Name);
            }
            if ((false == reader.IsDBNull(_.NikcName)))
            {
                this._NikcName = reader.GetString(_.NikcName);
            }
            if ((false == reader.IsDBNull(_.Gender)))
            {
                this._Gender = reader.GetByte(_.Gender);
            }
            if ((false == reader.IsDBNull(_.Birthday)))
            {
                this._Birthday = reader.GetDateTime(_.Birthday);
            }
            if ((false == reader.IsDBNull(_.HeadPicture)))
            {
                this._HeadPicture = reader.GetString(_.HeadPicture);
            }
            if ((false == reader.IsDBNull(_.Care)))
            {
                this._Care = reader.GetInt32(_.Care);
            }
            if ((false == reader.IsDBNull(_.Popular)))
            {
                this._Popular = reader.GetInt32(_.Popular);
            }
            if ((false == reader.IsDBNull(_.City)))
            {
                this._City = reader.GetInt32(_.City);
            }
            if ((false == reader.IsDBNull(_.Region)))
            {
                this._Region = reader.GetInt32(_.Region);
            }
            if ((false == reader.IsDBNull(_.CurrentSchool)))
            {
                this._CurrentSchool = reader.GetString(_.CurrentSchool);
            }
            if ((false == reader.IsDBNull(_.CurrentGrade)))
            {
                this._CurrentGrade = reader.GetInt32(_.CurrentGrade);
            }
            if ((false == reader.IsDBNull(_.CurrentClass)))
            {
                this._CurrentClass = reader.GetByte(_.CurrentClass);
            }
            if ((false == reader.IsDBNull(_.OldId)))
            {
                this._OldId = reader.GetInt32(_.OldId);
            }
            if ((false == reader.IsDBNull(_.SchoolID)))
            {
                this._SchoolID = reader.GetInt32(_.SchoolID);
            }
            if ((false == reader.IsDBNull(_.Talent)))
            {
                this._Talent = reader.GetString(_.Talent);
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
            if ((false == typeof(Child).IsAssignableFrom(obj.GetType())))
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
            public static AllField All = new AllField<Child>();

            /// <summary>
            /// 字段名：ID - 数据类型：Guid
            /// </summary>
            public static Field ID = new Field<Child>("ID");

            /// <summary>
            /// 字段名：AddTime - 数据类型：DateTime
            /// </summary>
            public static Field AddTime = new Field<Child>("AddTime");

            /// <summary>
            /// 字段名：UpdateTime - 数据类型：DateTime
            /// </summary>
            public static Field UpdateTime = new Field<Child>("UpdateTime");

            /// <summary>
            /// 字段名：IsDeleted - 数据类型：Boolean
            /// </summary>
            public static Field IsDeleted = new Field<Child>("IsDeleted");

            /// <summary>
            /// 孩子家长账户ID - 字段名：ParentID - 数据类型：Nullable`1
            /// </summary>
            public static Field ParentID = new Field<Child>("ParentID");

            /// <summary>
            /// 孩子姓名 - 字段名：Name - 数据类型：String
            /// </summary>
            public static Field Name = new Field<Child>("Name");

            /// <summary>
            /// 孩子昵称 - 字段名：NikcName - 数据类型：String
            /// </summary>
            public static Field NikcName = new Field<Child>("NikcName");

            /// <summary>
            /// 字段名：Gender - 数据类型：Byte
            /// </summary>
            public static Field Gender = new Field<Child>("Gender");

            /// <summary>
            /// 孩子的生日 - 字段名：Birthday - 数据类型：DateTime
            /// </summary>
            public static Field Birthday = new Field<Child>("Birthday");

            /// <summary>
            /// 字段名：HeadPicture - 数据类型：String
            /// </summary>
            public static Field HeadPicture = new Field<Child>("HeadPicture");

            /// <summary>
            /// 字段名：Care - 数据类型：Int32
            /// </summary>
            public static Field Care = new Field<Child>("Care");

            /// <summary>
            /// 字段名：Popular - 数据类型：Int32
            /// </summary>
            public static Field Popular = new Field<Child>("Popular");

            /// <summary>
            /// 字段名：City - 数据类型：Int32
            /// </summary>
            public static Field City = new Field<Child>("City");

            /// <summary>
            /// 字段名：Region - 数据类型：Int32
            /// </summary>
            public static Field Region = new Field<Child>("Region");

            /// <summary>
            /// 字段名：CurrentSchool - 数据类型：String
            /// </summary>
            public static Field CurrentSchool = new Field<Child>("CurrentSchool");

            /// <summary>
            /// 字段名：CurrentGrade - 数据类型：Int32
            /// </summary>
            public static Field CurrentGrade = new Field<Child>("CurrentGrade");

            /// <summary>
            /// 字段名：CurrentClass - 数据类型：Byte
            /// </summary>
            public static Field CurrentClass = new Field<Child>("CurrentClass");

            /// <summary>
            /// 字段名：OldId - 数据类型：Nullable`1
            /// </summary>
            public static Field OldId = new Field<Child>("OldId");

            /// <summary>
            /// 字段名：SchoolID - 数据类型：Nullable`1
            /// </summary>
            public static Field SchoolID = new Field<Child>("SchoolID");

            /// <summary>
            /// 字段名：Talent - 数据类型：String
            /// </summary>
            public static Field Talent = new Field<Child>("Talent");
        }

    }
}
