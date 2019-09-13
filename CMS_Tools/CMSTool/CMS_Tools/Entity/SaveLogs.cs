using CMS_Tools.Lib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using static CMS_Tools.Lib.Constants;

namespace CMS_Tools.Entity
{
    public class SaveLogs
    {
        static readonly object _lock = new object();
        private static List<LogInfo> listLogs = new List<LogInfo>();
        public static void AddLogs(LogInfo log) {
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

        public static void removeLogs(LogInfo log) {
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

        public static List<LogInfo> GetListLogs(int size) {
            try
            {
                if(listLogs != null)
                {
                    lock (_lock) {
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
        public void SaveLogFile()
        {
            while (true)
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
                                DATE_LOGS = item.dateLogs.ToString("dd/MM/yyyy hh:mm:ss"),
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
                                    Logs.logSendMail.Error(JsonConvert.SerializeObject(l));
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
                    Thread.Sleep(10000); //10 second  
                }
            }
        }
    }

    public class LogInfo
    {
        public LogInfo() {
            dateLogs = DateTime.Now;
        }
        public LOG_TYPE logType { get; set; }
        public DateTime dateLogs { get; set; }
        public string msgLogs { get; set; }
    }
}