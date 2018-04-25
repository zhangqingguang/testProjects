using Seagull.BarTender.Print;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string PrintName = "TSC TTP-243E Pro";//"TSC TTP-243E Pro"
                Console.WriteLine("引擎new之前");//"记录日志方便查找问题原因"
                Engine btEngine = new Engine();
                Console.WriteLine("引擎new完后，start前");
                btEngine.Start();
                Console.WriteLine("引擎开启");
                LabelFormatDocument btFormat = btEngine.Documents.Open(Path.Combine("C://Program Files (x86)//Seagull//BarTender Suite", "得力模板" + ".btw"));
                Console.WriteLine("模版打开");
                btFormat.SubStrings["dept"].Value = "研发部";//对模版相应字段进行赋值
                                                          //btFormat.SubStrings["ProjectName"].Value = DataImportOld.Material_Name;
                                                          //btFormat.SubStrings["GroupName"].Value = DataImportOld.WorkingGroup_Name;
                                                          //btFormat.SubStrings["Type"].Value = DataImportOld.Material_Type;
                                                          //btFormat.SubStrings["Color"].Value = DataImportOld.Color;
                                                          //btFormat.SubStrings["Num"].Value = Convert.ToString(True_Number);
                                                          //btFormat.SubStrings["BarCodeName"].Value = builder.ToString();
                                                          //btFormat.SubStrings["Batch"].Value = DataImportOld.Batch;
                Console.WriteLine("模版赋值");
                //btFormat.PrintSetup.Cache.FlushInterval = CacheFlushInterval.PerSession;
                //btFormat.Close(SaveOptions.DoNotSaveChanges);//不保存对打开模板的修改
                btFormat.PrintSetup.PrinterName = PrintName;
                //寻找打印机
                //PrinterSettings.StringCollection snames = PrinterSettings.InstalledPrinters;
                //bool PrintIsExist = false;
                //string logPringter = "";
                //foreach (string Name in snames)
                //{
                //    logPringter += Name + ";";
                //    if (Name.ToLower().Trim() == PrintName.ToLower().Trim())
                //    {
                //        PrintIsExist = true;
                //    }
                //}
                //Console.WriteLine("搜索的打印机有" + logPringter);

                //if (!PrintIsExist)
                //{
                //    Console.WriteLine("打印机不存在");
                //}
                Console.WriteLine("开始打印");
                btFormat.Print();
                Console.WriteLine("打印成功");
                Console.WriteLine("开始关闭引擎");
                btEngine.Stop();
                Console.WriteLine("关闭引擎成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception: " + ex.Message));
            }
        }
    }
}
