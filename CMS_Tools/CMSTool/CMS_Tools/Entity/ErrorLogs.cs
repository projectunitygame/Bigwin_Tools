using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace CMS_Tools.Entity
{
    //public class ErrorLogsClass
    //{
    //    static readonly object _lock = new object();
    //    private static List<ErrorLogs> LIST_ERROR_LOGS;

    //    public static void AddErrorLogs(ErrorLogs log) {
    //        try
    //        {
    //            lock (_lock)
    //            {
    //                if (LIST_ERROR_LOGS == null)
    //                    LIST_ERROR_LOGS = new List<ErrorLogs>();
    //                if(LIST_ERROR_LOGS.Count(x=>x.error == log.error) == 0)
    //                    LIST_ERROR_LOGS.Add(log);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Lib.Logs.SaveError("AddErrorLogs: " + ex);
    //        }
    //    }

    //    public static List<ErrorLogs> GetListErrorLogs(int size) {
    //        List<ErrorLogs> lst = new List<ErrorLogs>();
    //        try
    //        {
    //            if (LIST_ERROR_LOGS == null)
    //                LIST_ERROR_LOGS = new List<ErrorLogs>();
    //            lock (_lock)
    //            {
    //                lst = LIST_ERROR_LOGS.Take(size).Select(x => new ErrorLogs()
    //                {
    //                    error = x.error,
    //                    ex = x.ex,
    //                    idLog = x.idLog
    //                }).ToList();
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            lst = new List<ErrorLogs>();
    //        }
    //        return lst;
    //    }

    //    public static void RemoveErrorLog(ErrorLogs log) {
    //        lock (_lock) {
    //            var item = LIST_ERROR_LOGS.SingleOrDefault(x => x.idLog == log.idLog);
    //            if(item != null)
    //                LIST_ERROR_LOGS.Remove(item);
    //        }
    //    }

    //    public static void RemoveErrorLog(List<ErrorLogs> logs)
    //    {
    //        lock (_lock)
    //        {
    //            foreach (var item in logs)
    //            {
    //                var a = LIST_ERROR_LOGS.SingleOrDefault(x => x.idLog == item.idLog);
    //                if (item != null)
    //                    LIST_ERROR_LOGS.Remove(a);
    //            }   
    //        }
    //    }
    //}
    //public class ErrorLogs
    //{
    //    public ErrorLogs() {
    //        idLog = Guid.NewGuid().ToString();
    //    }
    //    public string idLog { get; set; }
    //    public string error { get; set; }
    //    public Exception ex { get; set; }
    //}

    ///// <summary>
    ///// SynErrorLog
    ///// </summary>
    //public class SynErrorLog
    //{
    //    static readonly object _lock = new object();
    //    public void SendMail()
    //    {
    //        while (true)
    //        {
    //            try
    //            {
    //                var listErrorLogs = ErrorLogsClass.GetListErrorLogs(10);
    //                foreach (var item in listErrorLogs)
    //                {
    //                    Lib.Logs.SendMailError("[" + Lib.Constants.SERVER_TYPE + "]" + item.error, item.ex);
    //                    ErrorLogsClass.RemoveErrorLog(item);
    //                    Thread.Sleep(1000);
    //                }
    //            }
    //            catch (Exception)
    //            {
    //            }
    //            finally
    //            {
    //                Thread.Sleep(60000); //60 second  
    //            }
    //        }
    //    }
    //}
}