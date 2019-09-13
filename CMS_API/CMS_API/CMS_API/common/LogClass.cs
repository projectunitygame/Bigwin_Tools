using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace api_cms.common
{
    public struct LogClass
    {
        #region Log4net
        public static readonly ILog LogCustomers = log4net.LogManager.GetLogger("CustomerData");
        public static readonly ILog log = log4net.LogManager.GetLogger("ErrorLog");
        public static readonly ILog logTracking = log4net.LogManager.GetLogger("TrackingData");
        public static readonly ILog logSendMail = log4net.LogManager.GetLogger("SendMailError");
        public static readonly ILog logTrackingDB = log4net.LogManager.GetLogger("TrackingDB");
        public static readonly ILog logTrackingOrders = log4net.LogManager.GetLogger("TrackingOrders");
        private static string SERVER_TYPE = WebConfigurationManager.AppSettings["SERVER_TYPE"] + " ";
        #endregion

        /// <summary>
        /// SaveError
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        /// <param name="sendMail"></param>
        public static void SaveError(string msg, Exception ex = null, bool sendMail = false)
        {
            try
            {
                log.Error(SERVER_TYPE + msg + (ex != null ? ex.ToString() : ""));
                if (sendMail)
                {
                    logSendMail.Info(SERVER_TYPE + msg, ex);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void SaveLog(string msg)
        {
            try
            {
                logTracking.Info(SERVER_TYPE + msg);
            }
            catch (Exception)
            {
            }
        }

        public static void SaveCustomerLog(string msg)
        {
            try
            {
                LogCustomers.Info(SERVER_TYPE + msg);
            }
            catch (Exception)
            {
            }
        }

        public static void SaveDBLog(string msg)
        {
            try
            {
                logTrackingDB.Info(SERVER_TYPE + msg);
            }
            catch (Exception)
            {
            }
        }

        public static void SaveOrdersLog(string msg)
        {
            try
            {
                logTrackingOrders.Info("\r\n" + SERVER_TYPE + msg);
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
            catch (Exception e)
            {
                SaveError("Error SendMailError: " + e);
            }
        }
    }
}