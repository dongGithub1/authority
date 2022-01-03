using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using YX.BLL;

namespace YX
{
    public partial class FrmLogin : Form
    {
        SystemUserInfo_Bll user_bll = new SystemUserInfo_Bll();
        public FrmLogin()
        {
            InitializeComponent();
        }
        public static string loginUserName { get; set; }
        public static string LoginUserID { get; set; }
        public static string LocalIP { get; set; }
        /// <summary>
        /// 启动时隐藏窗口
        /// </summary>
        public void delay()
        {
            this.Hide();
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                var user = user_bll.UserLogin(txt_User_Account.Text, txt_UserPwd.Text);
                if (user != null)
                {
                    this.BeginInvoke(new ThreadStart(delay));
                    loginUserName = user.User_Name;
                    LoginUserID = user.User_ID;
                    LocalIP = GetLocalIP();
                    FrmMain main = new FrmMain();
                    main.WindowState = FormWindowState.Maximized;
                    main.Show();
                    LogHelper.WriteLog(typeof(FrmLogin), loginUserName + "登录成功！");
                    System_Bll.WriteLogToDB(
                        new Entity.Base_Log
                        {
                            CreateUserID = FrmLogin.LoginUserID,
                            CreateUserName = FrmLogin.loginUserName,
                            LocalIP = FrmLogin.LocalIP,
                            LogMessage = "登录成功！",
                            Type = "系统消息",
                            ClassName = typeof(FrmLogin).ToString()

                        });
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show (ex.Message);
            }
         
    
        }
        public static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取本机IP出错:" + ex.Message);
                return "";
            }
        }
    }
}
