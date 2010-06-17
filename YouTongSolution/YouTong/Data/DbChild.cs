using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;
using WebBasics.Utilities;
using YouTong.Model;

namespace YouTong.Data
{
    /// <summary>
    /// 孩子 数据操作
    /// </summary>
    public class DbChild
    {
        /// <summary>
        /// DbChild实例
        /// </summary>
        public static readonly DbChild Instance = new DbChild();

        DbSession dbSession = new DbSession("ut");
        readonly WhereClip NotDeleted = Child._.IsDeleted == false;
        readonly WhereClip HasDeleted = Child._.IsDeleted == true;

        /// <summary>
        /// 添加孩子
        /// </summary>
        /// <param name="Child">孩子实体</param>
        /// <returns>返回影响行数</returns>
        public Int32 AddChild(Child Child)
        {
            Child.Detach();

            if (Child.ID == Guid.Empty) Child.ID = Comb.NewComb2();
            Child.AddTime = DateTime.Now;
            Child.UpdateTime = DateTime.Now;
            return dbSession.Save<Child>(Child);
        }

        /// <summary>
        /// 修改孩子
        /// </summary>
        /// <param name="Child">孩子实体</param>
        /// <returns>返回影响行数</returns>
        public Int32 UpdateChild(Child Child)
        {
            Child.Attach();
            Child.UpdateTime = DateTime.Now;
            return dbSession.Save<Child>(Child);
        }

        /// <summary>
        /// 删除孩子
        /// </summary>
        /// <param name="id">孩子编号</param>
        /// <returns>返回影响行数</returns>
        public Int32 DeleteChild(Guid id)
        {
            return dbSession.Delete<Child>(id);
        }

        /// <summary>
        /// 删除孩子
        /// </summary>
        /// <param name="ids">孩子编号</param>
        /// <returns>返回影响行数</returns>
        public Int32 DeleteChilds(params Guid[] ids)
        {
            var where = Child._.ID.In(ids);

            return dbSession.Delete<Child>(where);
        }

        /// <summary>
        /// 更新删除标志。
        /// 如果删除标志值与需要设置的值相同，则不进行修改
        /// </summary>
        /// <param name="ids">孩子编号，一个数组</param>
        /// <param name="isDeleted">删除标志值</param>
        /// <returns>返回影响行数</returns>
        public Int32 UpdateIsDeleted(Guid[] ids, Boolean isDeleted)
        {
            var where = Child._.IsDeleted.In(ids) && Child._.IsDeleted != isDeleted;

            return dbSession.Update<Child>(
                new Field[] { Child._.IsDeleted, Child._.UpdateTime },
                new Object[] { isDeleted, DateTime.Now },
                where);
        }

        /// <summary>
        /// 获取孩子
        /// </summary>
        /// <param name="id">孩子编号</param>
        /// <returns>返回孩子实体</returns>
        public Child GetChild(Guid id)
        {
            return dbSession.Single<Child>(id);
        }

        /// <summary>
        /// 获取所有孩子列表
        /// </summary>
        /// <returns>返回孩子实体列表</returns>
        public IList<Child> GetAllChilds()
        {
            var where = NotDeleted;
            return dbSession.From<Child>()
                .Where(where).OrderBy(Child._.AddTime.Asc)
                .ToList();
        }

        /// <summary>
        /// 获取孩子
        /// </summary>
        /// <param name="ids">孩子编号，一个数组</param>
        /// <returns>返回孩子实体列表</returns>
        public IList<Child> GetChilds(params Guid[] ids)
        {
            return dbSession.From<Child>().Where(Child._.ID.In(ids)).ToList();
        }

        /// <summary>
        /// 获取孩子，根据指定家长编号
        /// </summary>
        /// <param name="parentId">家长编号</param>
        /// <returns>返回孩子实体列表</returns>
        public IList<Child> GetChildsByParent(Guid parentId)
        {
            var where = this.NotDeleted && Child._.ParentID == parentId;

            return dbSession.From<Child>().Where(where).ToList();
        }

        /// <summary>
        /// 获取孩子，根据指定家长编号
        /// </summary>
        /// <param name="parentIds"></param>
        /// <returns>返回孩子实体列表</returns>
        public IList<Child> GetChildsByParent(params Guid[] parentIds)
        {
            var where = this.NotDeleted && Child._.ParentID.In(parentIds);

            return dbSession.From<Child>().Where(where).ToList();
        }

        /// <summary>
        /// 获取孩子列表
        /// </summary>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns>返回孩子实体列表</returns>
        public IList<Child> GetChilds(int pageIndex, int pageSize)
        {
            WhereClip where = this.NotDeleted;

            return dbSession.From<Child>()
                .Where(where).OrderBy(Child._.AddTime.Desc)
                .GetPage(pageSize).ToList(pageIndex);
        }

        /// <summary>
        /// 获取孩子列表
        /// </summary>
        /// <param name="city">市</param>
        /// <param name="region">区域</param>
        /// <param name="type">学校类型</param>
        /// <param name="schoolid">学校ID</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRow">共多少条记录</param>
        /// <returns>返回孩子实体列表</returns>
        public IList<Child> GetChilds(int city, int region, int type, int schoolid, int pageIndex, int pageSize, out int totalRow)
        {
            IList<Child> list = new List<Child>();
            totalRow = 0;
            if (city != 0 || region != 0 || type != 0 || schoolid != 0)
            {
                WhereClip where = this.NotDeleted;
                if (schoolid != 0)
                {
                    where = where && Child._.SchoolID == schoolid;
                }
                else if (region != 0)
                {
                    where = where && Child._.Region == region;
                }
                else if (city != 0)
                {
                    where = where && Child._.City == city;
                }
                PageSection<Child> ps;
                if (type == 0)
                    ps = dbSession.From<Child>()
                        .Where(where).OrderBy(Child._.AddTime.Desc)
                        .GetPage(pageSize);
                else
                    ps = dbSession.From<Child>().
                        Where(where && Child._.SchoolID.In(QueryCreator.NewCreator().From<School>().AddField(School._.ID).AddWhere(School._.IsDeleted == false && School._.Level == type)))
                        .OrderBy(Child._.AddTime.Desc)
                        .GetPage(pageSize);

                totalRow = ps.RowCount;
                if (totalRow > 0)
                    list = ps.ToList(pageIndex);
            }
            return list;
        }

        /// <summary>
        /// 获取已删除孩子列表
        /// </summary>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns>返回已删除孩子实体列表</returns>
        public IList<Child> GetDeletedChilds(int pageIndex, int pageSize)
        {
            WhereClip where = this.HasDeleted;

            return dbSession.From<Child>()
                .Where(where).OrderBy(Child._.AddTime.Desc)
                .GetPage(pageSize).ToList(pageIndex);
        }

        /// <summary>
        /// 获取孩子个数，根据指定家长编号
        /// </summary>
        /// <param name="parentId">家长编号</param>
        /// <returns>返回孩子个数</returns>
        public Int32 GetChildCountByParent(Guid parentId)
        {
            var where = this.NotDeleted && Child._.ParentID == parentId;

            return dbSession.Count<Child>(where);
        }

        /// <summary>
        /// 获取孩子记录条数
        /// </summary>
        /// <returns>返回孩子记录条数</returns>
        public Int32 GetChildCount()
        {
            WhereClip where = this.NotDeleted;

            return dbSession.From<Child>()
                .Where(where).Count();
        }

        /// <summary>
        /// 获取已删除孩子记录条数
        /// </summary>
        /// <returns>返回已删除孩子记录条数</returns>
        public Int32 GetDeletedChildCount()
        {
            WhereClip where = this.HasDeleted;

            return dbSession.From<Child>()
                .Where(where).Count();
        }
    }
}
