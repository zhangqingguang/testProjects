using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITGB.UIS.EF.Base
{
    /// <summary>
    /// 定义通用的Repository接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IDisposable
        where T : class
    {
        /// <summary>
        /// 获取所有的实体对象
        /// </summary>
        /// <returns></returns>
        IQueryable<T> All();

        /// <summary>
        /// 通过Lamda表达式过滤符合条件的实体对象
        /// </summary>
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Gets the object(s) is exists in database by specified filter.
        /// </summary>
        bool Contains(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 获取实体总数
        /// </summary>
        int Count();

        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 通过键值查找并返回单个实体
        /// </summary>
        T Find(params object[] keys);

        /// <summary>
        /// 通过表达式查找复合条件的单个实体
        /// </summary>
        /// <param name="predicate"></param>
        T Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 创建实体对象
        /// </summary>
        T Create(T t);

        /// <summary>
        /// 删除实体对象
        /// </summary>
        void Delete(T t);

        /// <summary>
        /// 删除符合条件的多个实体对象
        /// </summary>
        int Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Update object changes and save to database.
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        T Update(T t);
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <param name="updateExpression">更新内容</param>
        /// <param name=""></param>
        /// <returns></returns>
        int Update(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateExpression);
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<T> Pager(IQueryable<T> where,int pageIndex,int pageSize,out int count);

        /// <summary>
        /// Clear all data items.
        /// </summary>
        /// <returns>Total clear item count</returns>
        void Clear();

        /// <summary>
        /// Save all changes.
        /// </summary>
        /// <returns></returns>
        int Submit();
    }
}
