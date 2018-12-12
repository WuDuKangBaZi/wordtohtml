using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using wordtohtml.src;

namespace wordtohtml
{
    public partial class demo : Form
    {
        public demo()
        {
            InitializeComponent();
        }
        public static int surrce = 0;
        public static int fail = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string path = new Util().GetFile(openfolder, "请选择源文件目录");
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("文件夹路径获取错误");
            }
            else {
                surrce = 0;
                fail = 0;
                FeilsURL.Text = path;
                FeilList.Items.Clear();
                Util u = new Util();
                List<string> list = u.GetFileAll(path);
                foreach (string item in list)
                {
                    FeilList.Items.Add(item);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = new Util().GetFile(openfolder, "请选择保存文件目录");
            if (!string.IsNullOrEmpty(path))
            {
                saveurl.Text = path;
                //选了保存路径就开始转换
                button1.Enabled = false;
                button2.Enabled = false;
                int recount = 0;
                ThreadPool.SetMaxThreads(300, 300);
                for (int i = 0; i < FeilList.Items.Count; i++)
                {
                    Console.WriteLine("开始执行for循环,第{0}个",i);
                    // 多线程
                    ThreadPool.QueueUserWorkItem(doRun, i);
                }
            }
            else {
                MessageBox.Show("文件路径选择错误");
            }
        }
        private void doRun(object i)
        {
            int index = (int)i;
            bool re = false;
            string pathname = FeilList.Items[index].ToString();
            Console.WriteLine("当前文件的后缀为{0}", Path.GetExtension(pathname));
            if (Path.GetExtension(pathname).Equals(".doc") || Path.GetExtension(pathname).Equals(".docx"))
            {
                re = new Util().Wordtohtml(FeilList.Items[index].ToString(), saveurl.Text, FeilsURL.Text);
                
            }
            else
            {
                Console.WriteLine("进了else false");
                FeilList.SetItemChecked(index, false);
               
            }
            if (re)
            {
                FeilList.SetItemChecked(index, true);
                surrce += 1;
            }
            else
            {
                FeilList.SetItemChecked(index, false);
                fail += 1;
            }
            Console.WriteLine("当前surrce{0}",surrce);
            if (surrce+fail == FeilList.Items.Count) {
                button1.Enabled = true;
                button2.Enabled = true;
                MessageBox.Show("批量转换完成");
            }
         
        }
       

       
    }
}
