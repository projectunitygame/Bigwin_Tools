using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS_Tools
{
    public partial class Test : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string n = "1.703";
            float f = (float)Convert.ToDecimal(n);
            //for (int i = 0; i < 10; i++)
            //{
            //    ClassB.AddList(new ClassA()
            //    {
            //        a = i+1,
            //        b = Guid.NewGuid().ToString()
            //    });
            //}

            //var d = ClassB.GetList();
            //foreach (var item in d)
            //{
            //    if (item.a == 2)
            //        item.RemoveThis();
            //}
            //var c = ClassB.GetList();
        }
    }


    public class ClassA
    {
        public int a { get; set; }
        public string b { get; set; }
        public void RemoveThis() {
            ClassB.RemoveList(this);
        }
    }

    public class ClassB
    {
        private static List<ClassA> listA = new List<ClassA>();
        public static List<ClassA> GetList() {
            return listA.ToList();
        }

        public static void RemoveList(ClassA a) {
            listA.Remove(a);
        }

        public static void AddList(ClassA a)
        {
            listA.Add(a);
        }
    }
}