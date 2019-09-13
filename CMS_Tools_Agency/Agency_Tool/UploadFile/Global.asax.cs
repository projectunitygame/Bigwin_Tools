using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace UploadFile
{
    public class Global : System.Web.HttpApplication
    {
        public Thread oThread;
        public Thread oThread1;
        public Lib.SynErrorLog sysErrorLog;
        public Lib.SynSaveLog sysSaveLog;
        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            sysErrorLog = new Lib.SynErrorLog();
            oThread = new Thread(new ThreadStart(sysErrorLog.SendMail));
            oThread.Start();

            sysSaveLog = new Lib.SynSaveLog();
            oThread1 = new Thread(new ThreadStart(sysSaveLog.SaveLogFile));
            oThread1.Start();
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

        }
    }
}