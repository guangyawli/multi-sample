using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi_sample
{

    public partial class Form1 : Form
    {
        private static CultureInfo CI;
        private static ResourceManager rm;
        private static string userUICulture;

        private void InitUICulture()
        {
            //userUICulture = Thread.CurrentThread.CurrentUICulture.Name;
            //switch (userUICulture)
            //{
            //    case "en":
            //        CI = new CultureInfo("en");
            //        Thread.CurrentThread.CurrentUICulture = CI;
            //        break;
            //    case "zh-TW":
            //        CI = new CultureInfo("zh-TW");
            //        Thread.CurrentThread.CurrentUICulture = CI;
            //        //MessageBox.Show("zh-TW");
            //        break;
            //    case "zh-CN":
            //        CI = new CultureInfo("zh-Hans");
            //        Thread.CurrentThread.CurrentUICulture = CI;
            //        break;

            //    default:
            //        userUICulture = Thread.CurrentThread.CurrentUICulture.Name;
            //        break;
            //}
            rm = new ResourceManager("multi_sample.Properties.dict", Assembly.GetExecutingAssembly());

        }

        private static void langconv(ref string msg)
        {
            string check_msg="";

            try
            {
                check_msg = rm.GetString(msg);
                if (check_msg != null)
                {
                    msg = check_msg;
                }
            }
            catch (Exception ex)
            {
                //---- Enter your exception handling code here -----
                throw ex;
            }

        }



        public Form1()
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            System.Globalization.CultureInfo currentUICulture = System.Threading.Thread.CurrentThread.CurrentUICulture;
            InitializeComponent();
            InitUICulture();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string test_msg = "Hello World";
            langconv(ref test_msg);
            MessageBox.Show(test_msg);
            MessageBox.Show(rm.GetString("test_data"));
        }
    }
}
