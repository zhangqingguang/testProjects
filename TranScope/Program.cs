using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TranScope
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 1;
            for (int i = 0; i < length; i++)
            {
                addCategory(i);
            }
            //addContent(1);
            Console.Read();
        }


        private static void editTitle(int index)
        {
            Task.Run(() =>
            {
                try
                {
                    Console.WriteLine("Start before " + index);
                    using (var trans = new System.Transactions.TransactionScope())
                    {
                        Console.WriteLine("Starting " + index);
                        using (var db = new IntelEntities())
                        {
                            var item = db.tContents.FirstOrDefault();
                            item.CNTitle = item.CNTitle + "|" + index;
                            db.SaveChanges();
                            Console.WriteLine("Saved " + index);
                        }

                        Thread.Sleep(200);
                        trans.Complete();
                        Console.WriteLine("Completed " + index);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error " + index + " " + ex.Message);
                }
            });
        }
        private static void editContent(int index)
        {
            try
            {
                Console.WriteLine("Start before " + index);
                using (var trans = new System.Transactions.TransactionScope())
                {
                    Console.WriteLine("Starting " + index);
                    using (var db = new IntelEntities())
                    {
                        var category = db.tCategories.FirstOrDefault();
                        category.IsMultiple = category.IsMultiple;

                        var item = db.tContents.FirstOrDefault();
                        item.CNTitle = item.CNTitle + "|" + index;
                        db.SaveChanges();
                        // db.SaveChanges和trans.Dispose() 中间会锁死数据库
                        Console.WriteLine("Saved " + index);
                    }
                    index++;
                    using (var db = new IntelEntities())
                    {
                        var item = db.tContents.OrderBy(s => s.ID).Skip(1).FirstOrDefault();
                        item.CNTitle = item.CNTitle + "|" + index;
                        db.SaveChanges();
                        Console.WriteLine("Saved " + index);
                    }

                    trans.Complete();
                    Console.WriteLine("Completed " + index);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + index + " " + ex.Message);
            }
        }
        private static void addCategory(int index)
        {
            Task.Run(() =>
            {
                try
                {
                    Console.WriteLine("Start before " + index);
                    using (var trans = new System.Transactions.TransactionScope())
                    {
                        Console.WriteLine("Starting " + index);
                        using (var db = new IntelEntities())
                        {
                            // 主-外键 添加1
                            tCategory category = new tCategory()
                            {
                                Code = "Code_" + index,
                                ContentType = 1,
                                DisplayName = "Name_" + index,
                                IsAdvanceSearch = true,
                                IsMultiple = true,
                                Position = 1,
                                Sort = 1
                            };

                            tCategoryItem item = new tCategoryItem()
                            {
                                CategoryID = category.ID,
                                Code = "Code_Item_" + index,
                                Sort = 1
                            };

                            db.tCategories.Add(category);
                            db.tCategoryItems.Add(item);

                            //// 主-外键 添加2
                            //tCategory category2 = new tCategory()
                            //{
                            //    Code = "Code_" + index,
                            //    ContentType = 1,
                            //    DisplayName = "Name_" + index,
                            //    IsAdvanceSearch = true,
                            //    IsMultiple = true,
                            //    Position = 1,
                            //    Sort = 1
                            //};

                            //tCategoryItem item2 = new tCategoryItem()
                            //{
                            //    Code = "Code_Item_" + index,
                            //    Sort = 1,
                            //    tCategory = category2
                            //};

                            //db.tCategoryItems.Add(item2);



                            tCategoryItem item2 = new tCategoryItem()
                            {
                                Code = "Code_Item_" + index,
                                Sort = 1
                            };
                            tCategory category2 = new tCategory()
                            {
                                Code = "Code_" + index,
                                ContentType = 1,
                                DisplayName = "Name_" + index,
                                IsAdvanceSearch = true,
                                IsMultiple = true,
                                Position = 1,
                                Sort = 1,
                                tCategoryItems = new List<tCategoryItem> { item2 }
                            };
                            db.tCategories.Add(category2);

                            
                            db.SaveChanges();
                            Console.WriteLine("Saved " + index);
                        }

                        Thread.Sleep(200);
                        trans.Complete();

                        trans.Dispose();
                        Console.WriteLine("Completed " + index);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error " + index + " " + ex.Message);
                }
            });
        }
    }
}
