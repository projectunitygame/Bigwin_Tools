using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;

namespace UploadFile.Lib
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
        public static void SaveError(string msg, Exception ex = null, bool sendMail = false)
        {
            try
            {
                if (ex == null)
                    SaveLogs.AddLogs(new LogInfo()
                    {
                        logType = LOG_TYPE.ERROR_LOGS,
                        msgLogs = msg
                    });
                else
                    SaveLogs.AddLogs(new LogInfo()
                    {
                        logType = LOG_TYPE.ERROR_LOGS,
                        msgLogs = msg + ": " + ex
                    });

                if (sendMail)
                {
                    ErrorLogsClass.AddErrorLogs(new ErrorLogs()
                    {
                        error = msg,
                        ex = ex
                    });
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
                SaveLogs.AddLogs(new LogInfo()
                {
                    logType = LOG_TYPE.TRACKING_LOGS,
                    msgLogs = msg
                });
            }
            catch (Exception)
            {
            }
        }

        public static void SaveCustomerLog(string msg)
        {
            try
            {
                SaveLogs.AddLogs(new LogInfo()
                {
                    logType = LOG_TYPE.CUSTOMER_LOGS,
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
            catch (Exception e)
            {
                SaveError("Error SendMailError: " + e);
            }
        }
    }

    public class SaveLogs
    {
        static readonly object _lock = new object();
        private static List<LogInfo> listLogs = new List<LogInfo>();
        public static void AddLogs(LogInfo log)
        {
            try
            {
                lock (_lock)
                {
                    if (listLogs == null)
                        listLogs = new List<LogInfo>();
                    listLogs.Add(log);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void removeLogs(LogInfo log)
        {
            try
            {
                lock (_lock)
                {
                    if (listLogs == null)
                        listLogs = new List<LogInfo>();
                    listLogs.Remove(log);
                }
            }
            catch (Exception)
            {
            }
        }

        public static List<LogInfo> GetListLogs(int size)
        {
            try
            {
                if (listLogs != null)
                {
                    lock (_lock)
                    {
                        return listLogs.Take(size).ToList();
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public class SynSaveLog
    {
        static readonly object _lock = new object();
        public bool flag = true;
        public void SaveLogFile()
        {
            while (flag)
            {
                try
                {
                    var listLogs = SaveLogs.GetListLogs(50);
                    if (listLogs != null)
                    {
                        foreach (var item in listLogs)
                        {
                            var l = new
                            {
                                DATE_LOGS = item.dateLogs,
                                INFO_LOGS = item.msgLogs
                            };
                            switch (item.logType)
                            {
                                case LOG_TYPE.TRACKING_LOGS:
                                    Logs.logTracking.Info(JsonConvert.SerializeObject(l));
                                    break;
                                case LOG_TYPE.CUSTOMER_LOGS:
                                    Logs.LogCustomers.Info(JsonConvert.SerializeObject(l));
                                    break;
                                case LOG_TYPE.ERROR_LOGS:
                                    Logs.log.Error(JsonConvert.SerializeObject(l));
                                    break;
                                default:
                                    break;
                            }
                            SaveLogs.removeLogs(item);
                        }
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    Thread.Sleep(5000); //5 second  
                }
            }
        }
    }

    public class LogInfo
    {
        public LogInfo()
        {
            dateLogs = DateTime.Now;
        }
        public LOG_TYPE logType { get; set; }
        public DateTime dateLogs { get; set; }
        public string msgLogs { get; set; }
    }

    public class ErrorLogsClass
    {
        static readonly object _lock = new object();
        private static List<ErrorLogs> LIST_ERROR_LOGS;

        public static void AddErrorLogs(ErrorLogs log)
        {
            try
            {
                lock (_lock)
                {
                    if (LIST_ERROR_LOGS == null)
                        LIST_ERROR_LOGS = new List<ErrorLogs>();
                    if (LIST_ERROR_LOGS.Count(x => x.error == log.error) == 0)
                        LIST_ERROR_LOGS.Add(log);
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("AddErrorLogs: " + ex);
            }
        }

        public static List<ErrorLogs> GetListErrorLogs(int size)
        {
            List<ErrorLogs> lst = new List<ErrorLogs>();
            try
            {
                lock (_lock)
                {
                    lst = LIST_ERROR_LOGS.Take(size).Select(x => new ErrorLogs()
                    {
                        error = x.error,
                        ex = x.ex,
                        idLog = x.idLog
                    }).ToList();
                }
            }
            catch (Exception)
            {
                lst = new List<ErrorLogs>();
            }
            return lst;
        }

        public static void RemoveErrorLog(ErrorLogs log)
        {
            lock (_lock)
            {
                var item = LIST_ERROR_LOGS.SingleOrDefault(x => x.idLog == log.idLog);
                if (item != null)
                    LIST_ERROR_LOGS.Remove(item);
            }
        }

        public static void RemoveErrorLog(List<ErrorLogs> logs)
        {
            lock (_lock)
            {
                foreach (var item in logs)
                {
                    var a = LIST_ERROR_LOGS.SingleOrDefault(x => x.idLog == item.idLog);
                    if (item != null)
                        LIST_ERROR_LOGS.Remove(a);
                }
            }
        }
    }
    public class ErrorLogs
    {
        public ErrorLogs()
        {
            idLog = Guid.NewGuid().ToString();
        }
        public string idLog { get; set; }
        public string error { get; set; }
        public Exception ex { get; set; }
    }

    /// <summary>
    /// SynErrorLog
    /// </summary>
    public class SynErrorLog
    {
        public static string SERVER_TYPE = WebConfigurationManager.AppSettings["SERVER_TYPE"];
        static readonly object _lock = new object();
        public bool flag = true;
        public void SendMail()
        {
            while (flag)
            {
                try
                {
                    var listErrorLogs = ErrorLogsClass.GetListErrorLogs(10);
                    foreach (var item in listErrorLogs)
                    {
                        Logs.SendMailError("[" + SERVER_TYPE + "]" + item.error, item.ex);
                        ErrorLogsClass.RemoveErrorLog(item);
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    Thread.Sleep(10000); //10 second  
                }
            }
        }
    }

    public enum LOG_TYPE : byte
    {
        TRACKING_LOGS = 0,
        CUSTOMER_LOGS,
        ERROR_LOGS
    }
}