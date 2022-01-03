using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using YX.Entity;

using WeifenLuo.WinFormsUI.Docking;
namespace YX
{

    public partial class FrmExpress : WindowParent
    {
        public FrmExpress(string ParentId)
        {
            InitializeComponent();
          
        }
       
        private void FrmExpress_Load(object sender, EventArgs e)
        {
            List<ExpressCompany> list = new List<ExpressCompany>();
            list.Add(new ExpressCompany { CompanyName = "中通", CompanyValue = "zhongtong" });
            list.Add(new ExpressCompany { CompanyName = "德邦", CompanyValue = "debangwuliu" });
            list.Add(new ExpressCompany { CompanyName = "京东", CompanyValue = "jd" });
            list.Add(new ExpressCompany { CompanyName = "天天", CompanyValue = "tiantian" });
            list.Add(new ExpressCompany { CompanyName = "圆通", CompanyValue = "yuantong" });
            list.Add(new ExpressCompany { CompanyName = "宅急送", CompanyValue = "zhaijisong" });
            list.Add(new ExpressCompany { CompanyName = "顺丰", CompanyValue = "shunfeng" });
            list.Add(new ExpressCompany { CompanyName = "申通", CompanyValue = "shentong" });
            list.Add(new ExpressCompany { CompanyName = "EMS", CompanyValue = "ems" });
            list.Add(new ExpressCompany { CompanyName = "邮政", CompanyValue = "youzhengguonei" });
            list.Add(new ExpressCompany { CompanyName = "国通", CompanyValue = "guotongkuaidi" });
            list.Add(new ExpressCompany { CompanyName = "韵达", CompanyValue = "yunda" });
            list.Add(new ExpressCompany { CompanyName = "百世汇通", CompanyValue = "huitongkuaidi" });
            //list.Add(new ExpressCompany { CompanyName = "百世汇通", CompanyValue = "huitongkuaidi" });
            //list.Add(new ExpressCompany { CompanyName = "百世汇通", CompanyValue = "huitongkuaidi" });
            //list.Add(new ExpressCompany { CompanyName = "AAE全球专递", CompanyValue = "aae" });
            //list.Add(new ExpressCompany { CompanyName = "安捷快递", CompanyValue = "anjiekuaidi" });
            //list.Add(new ExpressCompany { CompanyName = "安信达快递", CompanyValue = "anxindakuaixi" });
            //list.Add(new ExpressCompany { CompanyName = "百福东方", CompanyValue = "baifudongfang" });
            //list.Add(new ExpressCompany { CompanyName = "彪记快递", CompanyValue = "biaojikuaidi" });
            //list.Add(new ExpressCompany { CompanyName = "BHT", CompanyValue = "bht" });
            //list.Add(new ExpressCompany { CompanyName = "希伊艾斯快递", CompanyValue = "cces" });
            //list.Add(new ExpressCompany { CompanyName = "中国东方", CompanyValue = "Coe" });
            //list.Add(new ExpressCompany { CompanyName = "长宇物流", CompanyValue = "changyuwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "大田物流", CompanyValue = "datianwuliu" });
 
            //list.Add(new ExpressCompany { CompanyName = "DPEX", CompanyValue = "dpex" });
            //list.Add(new ExpressCompany { CompanyName = "DHL", CompanyValue = "dhl" });
            //list.Add(new ExpressCompany { CompanyName = "D速快递", CompanyValue = "dsukuaidi" });
            //list.Add(new ExpressCompany { CompanyName = "fedex", CompanyValue = "fedex" });
            //list.Add(new ExpressCompany { CompanyName = "飞康达物流", CompanyValue = "feikangda" });
            //list.Add(new ExpressCompany { CompanyName = "凤凰快递", CompanyValue = "fenghuangkuaidi" });
            //list.Add(new ExpressCompany { CompanyName = "港中能达物流", CompanyValue = "ganzhongnengda" });
            //list.Add(new ExpressCompany { CompanyName = "广东邮政物流", CompanyValue = "guangdongyouzhengwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "汇通快运", CompanyValue = "huitongkuaidi" });
            //list.Add(new ExpressCompany { CompanyName = "恒路物流", CompanyValue = "hengluwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "华夏龙物流", CompanyValue = "huaxialongwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "佳怡物流", CompanyValue = "jiayiwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "京广速递", CompanyValue = "jinguangsudikuaijian" });
     
            //list.Add(new ExpressCompany { CompanyName = "急先达", CompanyValue = "jixianda" });
            //list.Add(new ExpressCompany { CompanyName = "佳吉物流", CompanyValue = "jiajiwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "加运美", CompanyValue = "jiayunmeiwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "快捷速递", CompanyValue = "kuaijiesudi" });
            //list.Add(new ExpressCompany { CompanyName = "联昊通物流", CompanyValue = "lianhaowuliu" });
            //list.Add(new ExpressCompany { CompanyName = "龙邦物流", CompanyValue = "longbanwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "民航快递", CompanyValue = "minghangkuaidi" });
            //list.Add(new ExpressCompany { CompanyName = "配思货运", CompanyValue = "peisihuoyunkuaidi" });
            //list.Add(new ExpressCompany { CompanyName = "全晨快递", CompanyValue = "quanchenkuaidi" });
            //list.Add(new ExpressCompany { CompanyName = "全际通物流", CompanyValue = "quanjitong" });
            //list.Add(new ExpressCompany { CompanyName = "全日通快递", CompanyValue = "quanritongkuaidi" });
            //list.Add(new ExpressCompany { CompanyName = "全一快递", CompanyValue = "quanyikuaidi" });
            //list.Add(new ExpressCompany { CompanyName = "盛辉物流", CompanyValue = "shenghuiwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "速尔物流", CompanyValue = "suer" });
            //list.Add(new ExpressCompany { CompanyName = "盛丰物流", CompanyValue = "shengfengwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "天地华宇", CompanyValue = "tiandihuayu" });
           
            //list.Add(new ExpressCompany { CompanyName = "TNT", CompanyValue = "tnt" });
            //list.Add(new ExpressCompany { CompanyName = "UPS", CompanyValue = "ups" });
            //list.Add(new ExpressCompany { CompanyName = "万家物流", CompanyValue = "wanjiawuliu" });
            //list.Add(new ExpressCompany { CompanyName = "文捷航空速递", CompanyValue = "wenjiesudi" });
            //list.Add(new ExpressCompany { CompanyName = "伍圆速递", CompanyValue = "wuyuansudi" });
            //list.Add(new ExpressCompany { CompanyName = "万象物流", CompanyValue = "wanxiangwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "新邦物流", CompanyValue = "xinbangwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "信丰物流", CompanyValue = "xinfengwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "星晨急便", CompanyValue = "xingchengjibian" });
            //list.Add(new ExpressCompany { CompanyName = "鑫飞鸿物流", CompanyValue = "xinhongyukuaidi" });
            //list.Add(new ExpressCompany { CompanyName = "亚风速递", CompanyValue = "yafengsudi" });
            //list.Add(new ExpressCompany { CompanyName = "一邦速递", CompanyValue = "yibangwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "优速物流", CompanyValue = "youshuwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "远成物流", CompanyValue = "yuanchengwuliu" });
        
            //list.Add(new ExpressCompany { CompanyName = "源伟丰快递", CompanyValue = "yuanweifeng" });
            //list.Add(new ExpressCompany { CompanyName = "元智捷诚快递", CompanyValue = "yuanzhijiecheng" });
            //list.Add(new ExpressCompany { CompanyName = "越丰物流", CompanyValue = "yuefengwuliu" });
            //list.Add(new ExpressCompany { CompanyName = "韵达快递", CompanyValue = "yunda" });
            //list.Add(new ExpressCompany { CompanyName = "源安达", CompanyValue = "yuananda" });
            //list.Add(new ExpressCompany { CompanyName = "运通快递", CompanyValue = "yuntongkuaidi" });
        
            //list.Add(new ExpressCompany { CompanyName = "中铁快运", CompanyValue = "zhongtiewuliu" });
        
            //list.Add(new ExpressCompany { CompanyName = "中邮物流", CompanyValue = "zhongyouwuliu" });
            comboBox1.ValueMember = "CompanyValue";
            comboBox1.DisplayMember = "CompanyName";
            comboBox1.DataSource = list;
           // comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;


        }
        private void btn_query_Click(object sender, EventArgs e)
        {
            string num = txt_expressNo.Text.Trim();
            string com = comboBox1.SelectedValue.ToString();
            //string path = string.Format("https://m.kuaidi100.com/result.jsp?nu={0}", num);

            string path = string.Format("https://m.kuaidi100.com/query?type={0}&postid={1}&id=1&valicode=&temp=0.003665506564913601",com,num);
          dataGridView1.DataSource=  HttpGet(path).data;

        }

        public static ExpressInfo HttpGet(string Url)
        {
            string retString = string.Empty;
            HttpWebResponse response=null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.Timeout = 5000;
                response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                retString = myStreamReader.ReadToEnd();

                JsonSerializer serializer = new JsonSerializer();
                StringReader sr = new StringReader(retString);
                object o = serializer.Deserialize(new JsonTextReader(sr), typeof(ExpressInfo));
                ExpressInfo t = o as ExpressInfo;
              
                myStreamReader.Close();
                myResponseStream.Close();

                return t;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                response.Close();
            }
            //return retString;
        }


    }
}
