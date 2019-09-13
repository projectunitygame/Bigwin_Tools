using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Tools.Lib
{
    public class Logs
    {
        #region Log4net
        public static readonly ILog LogCustomers = log4net.LogManager.GetLogger("CustomerData");
        public static readonly ILog log = log4net.LogManager.GetLogger("ErrorLog");
        public static readonly ILog logTracking = log4net.LogManager.GetLogger("TrackingData");
        public static readonly ILog logSendMail = log4net.LogManager.GetLogger("SendMailError");
        #endregion

        /// <summary>
        /// SaveError
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        /// <param name="sendMail"></param>
        public static void SaveError(string msg, Exception ex = null, bool sendMail = true) {
            try
            {
                Entity.SaveLogs.AddLogs(new Entity.LogInfo()
                {
                    logType = Constants.LOG_TYPE.ERROR_LOGS,
                    msgLogs = (ex == null ? msg : msg + ": " + ex)
                });
                if (sendMail)
                {
                    if(ex == null)
                        logSendMail.Error("["+Constants.SERVER_TYPE+"]" + msg, new Exception(msg));
                    else
                        logSendMail.Error("[" + Constants.SERVER_TYPE + "]" + msg, ex);
                }
                //if (sendMail)
                //{
                //    Entity.ErrorLogsClass.AddErrorLogs(new Entity.ErrorLogs()
                //    {
                //        error = msg,
                //        ex = ex
                //    });
                //}
            }
            catch (Exception)
            {               
            }
        }

        public static void SaveLog(string msg) {
            try
            {
                Entity.SaveLogs.AddLogs(new Entity.LogInfo()
                {
                    logType = Constants.LOG_TYPE.TRACKING_LOGS,
                    msgLogs = msg
                });
            }
            catch (Exception)
            {
            }
        }

        public static void SaveCustomerLog(string msg) {
            try
            {
                Entity.SaveLogs.AddLogs(new Entity.LogInfo()
                {
                    logType = Constants.LOG_TYPE.CUSTOMER_LOGS,
                    msgLogs = msg
                });
            }
            catch (Exception)
            {
            }
        }

        public static void SendMailError(string error, Exception ex)
        {
            try
            {
                logSendMail.Error(error, ex);
            }
            catch (Exception)
            {
                //SaveError("Error SendMailError: " + e);
            }
        }
    }
}