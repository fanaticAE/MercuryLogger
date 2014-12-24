using System;
using System.Collections.Generic; 
using System.Threading; 


namespace MercuryLogger
{
	public static class Log
	{
		private static string filePath = "log.log"; 


		public static string FilePath { get { return filePath; } set { filePath = value; } }
		public static bool ImmediateStdOutLogging { get; set; }
		public static bool LogToStdOut { get; set; }
		public static LogLevel HighestLevelToStdOut { get; set; }
		public static LogLevel HighestLevelToFile { get; set; }
		public static int BufferSize { get; set; }
		public static bool Running{ get { } }

		static Logger logger = new Logger(); 

		public static void Start(){

		}
		public static void Stop(){


		}

		#region Public Logging Methods

		public static void verbose(string tag, string message){
			addLogEntry (LogLevel.VERBOSE, tag, message); 

		}
		public static void verbose(string tag, string message, params string[] args){
			verbose (tag, String.Format (message, args)); 
		}
		public static void verbose(string tag, Exception exception, string message){
			addLogEntry (LogLevel.VERBOSE, tag, message, exception);
		}
		public static void verbose(string tag, Exception exception, string message, params string[] args){
			verbose (tag, exception, String.Format (message, args)); 
		}

		public static void debug(string tag, string message){	
			addLogEntry (LogLevel.DEBUG, tag, message); 
		}
		public static void debug(string tag, string message, params string[] args){
			debug (tag, String.Format (message, args)); 
		}
		public static void debug(string tag, Exception exception, string message){
			addLogEntry (LogLevel.DEBUG, tag, exception, message);
		}
		public static void debug(string tag, Exception exception, string message, params string[] args){
			debug (tag, exception, String.Format (message, args)); 
		}

		public static void info(string tag, string message){
			addLogEntry (LogLevel.INFO, tag, message); 
		}
		public static void info(string tag, string message, params string[] args){
			info (tag, String.Format (message, args)); 
		}
		public static void info(string tag, Exception exception, string message){
			addLogEntry (LogLevel.INFO, tag, message, exception); 
		}
		public static void info(string tag, Exception exception, string message, params string[] args){
			info (tag, exception, String.Format (message, args)); 
		}

		public static void warning(string tag, string message){
			addLogEntry (LogLevel.WARNING,tag, message); 
		}
		public static void warning(string tag, string message, params string[] args){
			warning (tag, String.Format (message, args)); 
		}
		public static void warning(string tag,Exception exception, string message){
			addLogEntry (LogLevel.WARNING, tag, message, exception); 
		}
		public static void warning(string tag, Exception exception, string message, params string[] args){
			warning (tag, exception, string.Format (message, args)); 
		}

		public static void error(string tag, string message){
			addLogEntry (LogLevel.ERROR, tag, message); 
		}
		public static void error(string tag, string message, params string[] args){
			error (tag, String.Format (message, args)); 
		}
		public static void error(string tag, Exception exception, string message){
			addLogEntry (LogLevel.ERROR, tag, message, exception); 
		}
		public static void error(string tag, Exception exception, string message, params string[] args){
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

