using ITGB.UIS.EF.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITGB.UIS.EFExtend.Models
{
    public class UserManager: EfUnitOfWork
    {
        private OReillyEntities _db = null;
        private OReillyEntities db
        {
            get
            {
                if(_db == null)
                {
                    _db = new OReillyEntities();
                }
                return _db;
            }
        }

        
    }
}