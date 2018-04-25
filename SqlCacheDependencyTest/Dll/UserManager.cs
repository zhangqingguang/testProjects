using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace SqlCacheDependencyTest.Dll
{
    public class UserManager
    {
        //定义连接字符串

        string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCacheDependencyDBEntity"].ConnectionString;
        public void CacheTableUser()
        {
            SqlDependency.Start(conStr);//启动监听服务，ps：只需启动一次

            System.Web.Caching.SqlCacheDependencyAdmin.EnableNotifications(conStr);//设置通知的数据库连接，ps：只需设置一次

            System.Web.Caching.SqlCacheDependencyAdmin.EnableTableForNotifications(conStr, "dbo.tUser");//设置通知的数据库连接和表，ps：只需设置一次

            string sql = "select * from dbo.tUser";

            SqlConnection con = new SqlConnection(conStr);

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "cache");

            System.Web.Caching.SqlCacheDependency cd = new System.Web.Caching.SqlCacheDependency("SqlCacheDependencyDB", "dbo.tUser");//建立关联

            //添加到缓存中
            System.Web.HttpContext.Current.Cache.Insert("cache", ds, cd);
        }

        public List<tUser> GetCacheUser()
        {
            if (System.Web.HttpContext.Current.Cache["tUser"] == null)
            {
                //如果没有缓存 重新获取数据
                var users = DBContextManager.DBEntities.tUsers.AsNoTracking().ToList();
                //添加到缓存中
                System.Web.HttpContext.Current.Cache.Insert(
                    "tUser",
                    users,
                    new SqlCacheDependency("SqlCacheDependencyDB", "dbo.tUser")
                    );
                //返回数据
                return users;
            }
            //如果已经缓存 返回缓存数据
            return System.Web.HttpContext.Current.Cache["tUser"] as List<tUser>;
        }

        public List<tUser> GetEntityFrameworkCacheUser()
        {
            using (var notifer = new EntityChangeNotifier<tUser, SqlCacheDependencyDBEntities>(p => p.Name == "Lamp"))
            {
                notifer.Changed += (sender, e) =>
                {
                    Console.WriteLine(e.Results.Count());
                    foreach (var p in e.Results)
                    {
                        Console.WriteLine("  {0}", p.Name);
                    }
                };

                Console.WriteLine("Press any key to stop...");
                Console.ReadKey(true);
            }
        }
    }
}