using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BusinessServices
{
    public static class ErrorLog
    {
        public static string CreateErrorMessage(Exception ex, string ctrlName, string actionName)
        {
            StringBuilder messageBuilder = new StringBuilder();
            try
            {
                messageBuilder.Append("The Exception is:-" + Environment.NewLine);
                messageBuilder.Append("Exception::" + ex.ToString() + Environment.NewLine);
                messageBuilder.Append("Controller::" + ctrlName + Environment.NewLine);
                messageBuilder.Append("Action Name::" + actionName + Environment.NewLine);
                if (ex.InnerException != null)
                {
                    messageBuilder.Append("Inner Exception" + ex.InnerException.ToString() + Environment.NewLine);
                }
                return messageBuilder.ToString();
            }
            catch (Exception)
            {
                messageBuilder.Append("Exception::Unknown Exception." + Environment.NewLine);
                messageBuilder.Append("Controller::" + ctrlName + Environment.NewLine);
                messageBuilder.Append("Action Name::" + actionName + Environment.NewLine); 
                return messageBuilder.ToString();
            }
        }

        public static void LogFileWrite(string message)
        {
            FileStream filestream = null;
            StreamWriter streamwriter = null;
            try
            {
                string logFilePath = HttpContext.Current.Server.MapPath("~/Logs/");
                logFilePath = logFilePath + " ProgramLog " + "-" + DateTime.Today.ToString("yyyyMMdd") + "." + "txt";
                if (logFilePath.Equals(""))
                    return;
                #region Create the log File directory if it does not exists
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (logDirInfo.Exists) logDirInfo.Create();
                #endregion Create the Log File directory if it does not exists
                if (!logFileInfo.Exists)
                {
                    filestream = logFileInfo.Create();
                }
                else
                {
                    filestream = new FileStream(logFilePath, FileMode.Append);
                }
                streamwriter = new StreamWriter(filestream);
                streamwriter.WriteLine(message);
            }
            finally
            {
                if (streamwriter != null) streamwriter.Close();
                if (filestream != null) filestream.Close();
            }
        }
    }
}
