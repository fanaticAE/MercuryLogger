using System;
using System.Collections.Generic; 
using System.Threading; 


namespace MercuryLogger
{
	public static class Log
	{
		public static string FilePath { get { return logger.FilePath; } set { logger.FilePath = value; } }
		public static bool ImmediateStdOutLogging { get { return logger.ImmediateStdOutLogging; } set { logger.ImmediateStdOutLogging = value; } }
		public static bool LogToStdOut { get{ return logger.LogToStdOut; } set{ logger.LogToStdOut = value; } }
		public static LogLevel HighestLevelToStdOut { get{ return logger.HighestLevelToStdOut; } set{ logger.HighestLevelToStdOut = value; } }
		public static LogLevel HighestLevelToFile { get{ return logger.HighestLevelToFile; } set{ logger.HighestLevelToFile = value; } }
		public static LogLevel LowestCachedLevel { get{ return logger.LowestCachedLevel; } set{ logger.LowestCachedLevel = value; } }
		public static int BufferSize { get{ return logger.BufferSize; } set{ logger.BufferSize =value; } }
		public static bool Running{ get { return logger.Running; } }

		static Logger logger = new Logger(new LoggerSettings()); 

		public static void Start(){
			logger.start (); 
		}
		public static void Stop(){
			logger.stop (); 
		}

		public static void applySettings(LoggerSettings settings){
			logger.applySettings (settings);
		}

		#region Public Logging Methods

		public static void verbose(string tag, string message){
			addLogEntry (LogLevel.VERBOSE, tag, message); 

		}
		public static void verbose(string tag, string message, params object[] args){
			verbose (tag, String.Format (message, args)); 
		}
		public static void verbose(string tag, Exception exception, string message){
			addLogEntry (LogLevel.VERBOSE, tag, message, exception);
		}
		public static void verbose(string tag, Exception exception, string message, params object[] args){
			verbose (tag, exception, String.Format (message, args)); 
		}

		public static void debug(string tag, string message){	
			addLogEntry (LogLevel.DEBUG, tag, message); 
		}
		public static void debug(string tag, string message, params object[] args){
			debug (tag, String.Format (message, args)); 
		}
		public static void debug(string tag, Exception exception, string message){
			addLogEntry (LogLevel.DEBUG, tag, message,exception);
		}
		public static void debug(string tag, Exception exception, string message, params object[] args){
			debug (tag, exception, String.Format (message, args)); 
		}

		public static void info(string tag, string message){
			addLogEntry (LogLevel.INFO, tag, message); 
		}
		public static void info(string tag, string message, params object[] args){
			info (tag, String.Format (message, args)); 
		}
		public static void info(string tag, Exception exception, string message){
			addLogEntry (LogLevel.INFO, tag, message, exception); 
		}
		public static void info(string tag, Exception exception, string message, params object[] args){
			info (tag, exception, String.Format (message, args)); 
		}

		public static void warning(string tag, string message){
			addLogEntry (LogLevel.WARNING,tag, message); 
		}
		public static void warning(string tag, string message, params object[] args){
			warning (tag, String.Format (message, args)); 
		}
		public static void warning(string tag,Exception exception, string message){
			addLogEntry (LogLevel.WARNING, tag, message, exception); 
		}
		public static void warning(string tag, Exception exception, string message, params object[] args){
			warning (tag, exception, string.Format (message, args)); 
		}

		public static void error(string tag, string message){
			addLogEntry (LogLevel.ERROR, tag, message); 
		}
		public static void error(string tag, string message, params object[] args){
			error (tag, String.Format (message, args)); 
		}
		public static void error(string tag, Exception exception, string message){
			addLogEntry (LogLevel.ERROR, tag, message, exception); 
		}
		public static void error(string tag, Exception exception, string message, params object[] args){
			error (tag, exception, String.Format (message, args)); 
		}
		#endregion

		private static void addLogEntry(LogLevel logLevel, string tag, string message){
			logger.log(new LogEntry(logLevel,tag,message)); 
		}
		private static void addLogEntry(LogLevel logLevel, string tag, string message, Exception ex){
			logger.log(new LogEntry (logLevel, tag, message, ex)); 
		}


	}
}

