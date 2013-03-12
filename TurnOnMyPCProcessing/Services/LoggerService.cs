using System;
using System.Diagnostics;

namespace TurnOnMyPCProcessing.Services
{
    public class LoggerService
    {
        public const string ApplicationLog = @"Application";
        public const string SourceName = @"TurnOnMyPC";

        public void CreateSourceIfNotExist()
        {
            try
            {
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, ApplicationLog);
                }
            }
            catch
            {
                return;
            }
        }

        #region IAnalystStudioLoggingService Members

        public void LogInformation(string eventMessage)
        {
            try
            {
                EventLog.WriteEntry(SourceName, eventMessage, EventLogEntryType.Information);
            }
            catch
            {
                return;
            }
        }

        public void LogError(string errorMessage)
        {
            try
            {
                EventLog.WriteEntry(SourceName, errorMessage, EventLogEntryType.Error);
            }
            catch
            {
                return;
            }
        }

        public void LogException(Exception ex)
        {
            try
            {
                EventLog.WriteEntry(SourceName, ex.ToString(), EventLogEntryType.Error);
#if DEBUG
                Debug.WriteLine(ex);
#endif
            }
            catch
            {
                return;
            }
        }

        #endregion
    }
}
