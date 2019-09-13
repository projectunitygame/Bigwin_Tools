using CMS_Tools.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using static CMS_Tools.Lib.Constants;
using static CMS_Tools.Lib.Web;

namespace CMS_Tools
{
    public class Global : System.Web.HttpApplication
    {
        //public Thread oThread;
        public Thread oThread1;
        //public Thread oThread2;
        public Thread oThread3;
        //public Entity.SynErrorLog sysErrorLog;
        public Entity.SynSaveLog sysSaveLog;
        public SynTaskList synTaskList;
        public SynPing synPing;
        public static List<string> taskList = new List<string>();
        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            Logs.SaveLog("***** SERVER START *****");
            //sysErrorLog = new Entity.SynErrorLog();
            //oThread = new Thread(new ThreadStart(sysErrorLog.SendMail));
            //oThread.Start();

            sysSaveLog = new Entity.SynSaveLog();
            oThread1 = new Thread(new ThreadStart(sysSaveLog.SaveLogFile));
            oThread1.Start();

            //synTaskList = new SynTaskList();
            //oThread2 = new Thread(new ThreadStart(synTaskList.RequestUrl));
            //oThread2.Start();

            //synPing = new SynPing();
            //oThread3 = new Thread(new ThreadStart(synPing.RequestUrl));
            //oThread3.Start();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            Logs.SaveLog("***** SERVER END *****");
        }
    }


    public class SynTaskList {
        public void RequestUrl()
        {
            while (true)
            {
                try
                {
                    var listTask = Global.taskList.ToList();
                    if (listTask != null && listTask.Count > 0)
                    {
                        foreach (var item in listTask)
                        {
                            Logs.SaveLog(item);
                            using (WebClient w = new WebClient())
                            {
                                string result = w.DownloadString(item);
                                Logs.SaveLog("Response: " + result);
                            };
                            Global.taskList.Remove(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logs.SaveError("RequestUrl", ex);
                }
                finally
                {
                    Thread.Sleep(60000); //60 second  
                }
            }
        }
    }

    public class SynPing
    {
        public void RequestUrl()
        {
            while (true)
            {
                try
                {
                    string sign = Lib.Encryptor.MD5Hash("255#####");
                    string uri = Constants.PING_URL + "?sign=" + sign + "&p=255&t=" + Guid.NewGuid();
                    using (WebClient w = new WebClient())
                    {
                        string result = w.DownloadString(uri);
                        Logs.SaveLog(uri + "\r\nResponse: " + result);
                    };                  
                }
                catch (Exception ex)
                {
                    Logs.SaveError("SynPing", ex);
                }
                finally
                {
                    Thread.Sleep(60000); //60 second  
                }
            }
        }
    }
}