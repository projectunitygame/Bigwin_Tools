using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS_Tools
{
    public partial class CreateJson_Chart : System.Web.UI.Page
    {
        List<chartData> json = new List<chartData>();
        protected void Page_Load(object sender, EventArgs e)
        {
            var datetime = new DateTime(2019, 06, 15, 0, 0, 0);
            for (int i = 0; i < 287; i++)
            //for (int i = 0; i < 12; i++)
            {
                datetime = datetime.AddMinutes(5);
                json.Add(new chartData()
                {
                    date = datetime.ToString("HH:mm"),
                    nhietdo0 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam0 = Lib.UtilClass.GetRandomNumber(1, 100),
                    nhietdo1 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam1 = Lib.UtilClass.GetRandomNumber(1, 100),
                    nhietdo2 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam2 = Lib.UtilClass.GetRandomNumber(1, 100),
                    nhietdo3 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam3 = Lib.UtilClass.GetRandomNumber(1, 100),
                    nhietdo4 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam4 = Lib.UtilClass.GetRandomNumber(1, 100),
                    nhietdo5 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam5 = Lib.UtilClass.GetRandomNumber(1, 100),
                    nhietdo6 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam6 = Lib.UtilClass.GetRandomNumber(1, 100),
                    nhietdo7 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam7 = Lib.UtilClass.GetRandomNumber(1, 100),
                    nhietdo8 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam8 = Lib.UtilClass.GetRandomNumber(1, 100),
                    nhietdo9 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam9 = Lib.UtilClass.GetRandomNumber(1, 100),
                    nhietdo10 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam10 = Lib.UtilClass.GetRandomNumber(1, 100),
                    nhietdo11 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam11 = Lib.UtilClass.GetRandomNumber(1, 100),
                    nhietdo12 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam12 = Lib.UtilClass.GetRandomNumber(1, 100),
                    nhietdo13 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam13 = Lib.UtilClass.GetRandomNumber(1, 100),
                    nhietdo14 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam14 = Lib.UtilClass.GetRandomNumber(1, 100),
                    nhietdo15 = Lib.UtilClass.GetRandomNumber(1, 100),
                    doam15 = Lib.UtilClass.GetRandomNumber(1, 100)
                });
            }
            Response.Write(JsonConvert.SerializeObject(json));
        }
    }


    public class chartData
    {
        public string date;
        public float nhietdo0;
        public float doam0;
        public float nhietdo1;
        public float doam1;
        public float nhietdo2;
        public float doam2;
        public float nhietdo3;
        public float doam3;
        public float nhietdo4;
        public float doam4;
        public float nhietdo5;
        public float doam5;
        public float nhietdo6;
        public float doam6;
        public float nhietdo7;
        public float doam7;
        public float nhietdo8;
        public float doam8;
        public float nhietdo9;
        public float doam9;
        public float nhietdo10;
        public float doam10;
        public float nhietdo11;
        public float doam11;
        public float nhietdo12;
        public float doam12;
        public float nhietdo13;
        public float doam13;
        public float nhietdo14;
        public float doam14;
        public float nhietdo15;
        public float doam15;
    }
}