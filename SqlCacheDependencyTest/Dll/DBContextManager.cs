using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SqlCacheDependencyTest.Dll
{
    public class DBContextManager
    {
        private static SqlCacheDependencyDBEntities _dbEntities { get; set; }
        public static SqlCacheDependencyDBEntities DBEntities { get {
                if(_dbEntities == null)
                {
                    _dbEntities = new SqlCacheDependencyDBEntities();
                }
                return _dbEntities;
            } }
    }
}