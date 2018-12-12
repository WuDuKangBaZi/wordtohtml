using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace wordtohtml.src
{
    class Util
    {
        //Logger log = getLog();
        public string GetFile(FolderBrowserDialog openfolder, string text)
        {
            openfolder.Description = text;
            if (openfolder.ShowDialog() == DialogResult.OK)
            {
                return openfolder.SelectedPath;
            }
            return null;
        }

        public List<string> GetFileAll(string filePath)
        {
            List<string> list = new List<string>();
            //如果路径是文件夹，继续遍历，把新遍历出来的文件夹和文件存到list
            if (Directory.Exists(filePath))
            {
                //log.Info("获取到文件夹:{0}",filePath);
                string[] dirs = Directory.GetDirectories(filePath);
                if (dirs != null)
                {
                    foreach (string dir in dirs)
                    {
                        list.AddRange(GetFileAll(dir));
                    }
                }

                string[] files = Directory.GetFiles(filePath);
                if (files != null)
                {
                    foreach (string file in files)
                    {
                        string ex = Path.GetExtension(file);
                        string[] exlist = ex.Split('.');
                        if (string.Equals(exlist[1], "docx") || string.Equals(exlist[1], "doc"))
                        {
                            // log.Info("已添加word文档,{0}", file);
                            list.Add(file);
                        }
                        else
                        {
                            //log.Info("不是word文档,{0}", file);
                        }
                    }

                }
            }
            //如果路径是文件，添加到list
            else if (File.Exists(filePath))
            {
                //log.Info("读取到文件:{0}",filePath);
                string ex = Path.GetExtension(filePath);
                string[] exlist = ex.Split('.');
                if (string.Equals(exlist[1], "docx") || string.Equals(exlist[1], "doc") || string.Equals(exlist[1], "xls") || string.Equals(exlist[1], "xlsx")
                    || string.Equals(exlist[1], "ppt") || string.Equals(exlist[1], "pptx"))
                {
                    // log.Info("这玩意儿是word文档,{0}", filePath);
                    if (filePath.IndexOf('~') >= 1)
                    {
                        //log.Info("文件是临时文件:{0}",filePath);
                    }
                    else
                    {
                        list.Add(filePath);
                    }

                }
            }
            return list;

        }

        public bool Wordtohtml(string filePath, string savapath, string pathurl)
        {
            // sourcefile -> 需要处理的文件路径
            // savefile -> 需要保存的文件路径
            // pathurl ->  根目录的路径
            try
            {
                Console.WriteLine("线程 已经开始 FilePath:{0},SavePath:{1},pathurl{2}",filePath,savapath,pathurl);
                Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
                Type wordtype = application.GetType();
                Microsoft.Office.Interop.Word.Documents docs = application.Documents;
                Type docstype = docs.GetType();
                Microsoft.Office.Interop.Word.Document document =
                    (Microsoft.Office.Interop.Word.Document)docstype.InvokeMember("open", System.Reflection.BindingFlags.InvokeMethod, null, docs,
                    new object[] { filePath, true, true });

                Type doctype = document.GetType();
                string fileurl = Path.GetDirectoryName(filePath);
                string str = fileurl.Replace(pathurl, "");

                string pathfile = savapath + str + @"\";
                if (Directory.Exists(pathfile) == false)
                {
                    // 不存在，则创建这个目录
                    Directory.CreateDirectory(pathfile);
                }
                object savefilename = pathfile + Path.GetFileNameWithoutExtension(filePath) + @".html";
                Console.WriteLine("保存的路径:" + savefilename);
                doctype.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod,
                    null, document, new object[] {
                    savefilename,Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatHTML
                    });
                wordtype.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, application, null);
                // Thread.Sleep(1000);
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;

            }
        }
    }
}
