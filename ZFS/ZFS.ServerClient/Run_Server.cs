using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZFS.ServerLibrary;

namespace ZFS.ServerClient
{
    public partial class Run_Server : Form
    {
        public Run_Server()
        {
            InitializeComponent();
        }

        ServiceHost host;

        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (host == null)
                {
                    host = new ServiceHost(typeof(BaseService));
                    host.Open();
                    Txt_info.Text = "\r\n ZFS远程连接服务开启成功! ";
                }
            }
            catch (Exception ex)
            {
                Txt_info.Text += ex.Message;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                if (host != null)
                {
                    host.Close();
                    host.Abort();
                    host = null;
                    Txt_info.Text = "\r\n ZFS远程连接服务关闭成功！";
                }
            }
            catch (Exception ex)
            {
                Txt_info.Text += ex.Message;
            }
        }

        private void Run_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            btn_Close.PerformClick();
        }
    }
}
