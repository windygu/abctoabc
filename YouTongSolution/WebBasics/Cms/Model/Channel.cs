namespace WebBasics.Cms.Model {
        using System;
        using MySoft.Data;
        
        
        /// <summary>
        /// 表名：wbcms_Channel 主键列：ID
        /// </summary>
        [SerializableAttribute()]
        public partial class Channel : Entity {
            
            protected Guid _ID;
            
            protected DateTime _AddTime;
            
            protected DateTime _UpdateTime;
            
            protected Boolean _IsDeleted;
            
            protected String _Name;
            
            protected String _DisplayName;
            
            protected Guid? _ParentID;
            
            protected String _Family;
            
            public Guid ID {
                get {
                    return this._ID;
                }
                set {
                    this.OnPropertyValueChange(_.ID, _ID, value);
                    this._ID = value;
                }
            }
            
            public DateTime AddTime {
                get {
                    return this._AddTime;
                }
                set {
                    this.OnPropertyValueChange(_.AddTime, _AddTime, value);
                    this._AddTime = value;
                }
            }
            
            public DateTime UpdateTime {
                get {
                    return this._UpdateTime;
                }
                set {
                    this.OnPropertyValueChange(_.UpdateTime, _UpdateTime, value);
                    this._UpdateTime = value;
                }
            }
            
            public Boolean IsDeleted {
                get {
                    return this._IsDeleted;
                }
                set {
                    this.OnPropertyValueChange(_.IsDeleted, _IsDeleted, value);
                    this._IsDeleted = value;
                }
            }
            
            public String Name {
                get {
                    return this._Name;
                }
                set {
                    this.OnPropertyValueChange(_.Name, _Name, value);
                    this._Name = value;
                }
            }
            
            public String DisplayName {
                get {
                    return this._DisplayName;
                }
                set {
                    this.OnPropertyValueChange(_.DisplayName, _DisplayName, value);
                    this._DisplayName = value;
                }
            }
            
            public Guid? ParentID {
                get {
                    return this._ParentID;
                }
                set {
                    this.OnPropertyValueChange(_.ParentID, _ParentID, value);
                    this._ParentID = value;
                }
            }
            
            public String Family {
                get {
                    return this._Family;
                }
                set {
                    this.OnPropertyValueChange(_.Family, _Family, value);
                    this._Family = value;
                }
            }
            
            /// <summary>
            /// 获取实体对应的表名
            /// </summary>
            protected override Table GetTable() {
                return new Table<Channel>("wbcms_Channel");
            }
            
            /// <summary>
            /// 获取实体中的主键列
            /// </summary>
            protected override Field[] GetPrimaryKeyFields() {
                return new Field[] {
                        _.ID};
            }
            
            /// <summary>
            /// 获取列信息
            /// </summary>
            protected override Field[] GetFields() {
                return new Field[] {
                        _.ID,
                        _.AddTime,
                        _.UpdateTime,
                        _.IsDeleted,
                        _.Name,
                        _.DisplayName,
                        _.ParentID,
                        _.Family};
            }
            
            /// <summary>
            /// 获取列数据
            /// </summary>
            protected override object[] GetValues() {
                return new object[] {
                        this._ID,
                        this._AddTime,
                        this._UpdateTime,
                        this._IsDeleted,
                        this._Name,
                        this._DisplayName,
                        this._ParentID,
                        this._Family};
            }
            
            /// <summary>
            /// 给当前实体赋值
            /// </summary>
            protected override void SetValues(IRowReader reader) {
                if ((false == reader.IsDBNull(_.ID))) {
                    this._ID = reader.GetGuid(_.ID);
                }
                if ((false == reader.IsDBNull(_.AddTime))) {
                    this._AddTime = reader.GetDateTime(_.AddTime);
                }
                if ((false == reader.IsDBNull(_.UpdateTime))) {
                    this._UpdateTime = reader.GetDateTime(_.UpdateTime);
                }
                if ((false == reader.IsDBNull(_.IsDeleted))) {
                    this._IsDeleted = reader.GetBoolean(_.IsDeleted);
                }
                if ((false == reader.IsDBNull(_.Name))) {
                    this._Name = reader.GetString(_.Name);
                }
                if ((false == reader.IsDBNull(_.DisplayName))) {
                    this._DisplayName = reader.GetString(_.DisplayName);
                }
                if ((false == reader.IsDBNull(_.ParentID))) {
                    this._ParentID = reader.GetGuid(_.ParentID);
                }
                if ((false == reader.IsDBNull(_.Family))) {
                    this._Family = reader.GetString(_.Family);
                }
            }
            
            public override int GetHashCode() {
                return base.GetHashCode();
            }
            
            public override bool Equals(object obj) {
                if ((obj == null)) {
                    return false;
                }
                if ((false == typeof(Channel).IsAssignableFrom(obj.GetType()))) {
                    return false;
                }
                if ((((object)(this)) == ((object)(obj)))) {
                    return true;
                }
                return false;
            }
            
            public class _ {
                
                /// <summary>
                /// 表示选择所有列，与*等同
                /// </summary>
                public static AllField All = new AllField<Channel>();
                
                /// <summary>
                /// 字段名：ID - 数据类型：Guid
                /// </summary>
                public static Field ID = new Field<Channel>("ID");
                
                /// <summary>
                /// 字段名：AddTime - 数据类型：DateTime
                /// </summary>
                public static Field AddTime = new Field<Channel>("AddTime");
                
                /// <summary>
                /// 字段名：UpdateTime - 数据类型：DateTime
                /// </summary>
                public static Field UpdateTime = new Field<Channel>("UpdateTime");
                
                /// <summary>
                /// 字段名：IsDeleted - 数据类型：Boolean
                /// </summary>
                public static Field IsDeleted = new Field<Channel>("IsDeleted");
                
                /// <summary>
                /// 字段名：Name - 数据类型：String
                /// </summary>
                public static Field Name = new Field<Channel>("Name");
                
                /// <summary>
                /// 字段名：DisplayName - 数据类型：String
                /// </summary>
                public static Field DisplayName = new Field<Channel>("DisplayName");
                
                /// <summary>
                /// 字段名：ParentID - 数据类型：Nullable`1
                /// </summary>
                public static Field ParentID = new Field<Channel>("ParentID");
                
                /// <summary>
                /// 字段名：Family - 数据类型：String
                /// </summary>
                public static Field Family = new Field<Channel>("Family");
            }
        }
    }
