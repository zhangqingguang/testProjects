//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TranScope
{
    using System;
    using System.Collections.Generic;
    
    public partial class tCategory
    {
        public tCategory()
        {
            this.tCategoryItems = new HashSet<tCategoryItem>();
        }
    
        public int ID { get; set; }
        public int ContentType { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public int Sort { get; set; }
        public bool IsAdvanceSearch { get; set; }
        public bool IsMultiple { get; set; }
        public int Position { get; set; }
    
        public virtual ICollection<tCategoryItem> tCategoryItems { get; set; }
    }
}