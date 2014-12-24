using System;
using System.Collections.Generic; 
using System.Threading; 


namespace MercuryLogger
{
	public static class Log
	{
		public static string FilePath = "log.log"; 
		public static LogLevel HighestLevelToStdOut { get; set; }
		public static LogLevel HighestLevelToFile { get; set; }
		public static int BufferSize { get; set; }


		static Thread loggingThread; 
		static Queue<LogEntry> Buffer = new Queue<LogEntry>(); 
		static bool running = false; 
		static object _lock = new object(); 
		static AutoResetEvent doLog = new AutoResetEvent(false); 


		public static void Start(){
			if (!running) {


				running = true; 
			}
			else throw new Exception ("Already Running");

		}
		public static void Stop(){
			if (running) {
				running = false; 
			}

		}

		#region Public Logging Methods

		public static void verbose(string tag, string message){


		}
		public static void verbose(string tag, string message, params string[] args){
			verbose (tag, String.Format (message, args)); 
		}

		public static void debug(string tag, string message){

		}
		public static void debug(string tag, string message, params string[] args){
			debug (tag, String.Format (message, args)); 
		}

		public static void info(string tag, string message){

		}
		public static void info(string tag, string message, params string[] args){
			info (tag, String.Format (message, args)); 
		}
		public static void warning(string tag, string message){

		}
		public static void warning(string tag, string message, params string[] args){
			warning (tag, String.Format (message, args)); 
		}

		public static void error(string tag, string message){

		}
		public static void error(string tag, string message, params string[] args){
			error (tag, String.Format (message, args)); 
		}


		#endregion

		private static void addLogEntry(LogEntry entry){
			lock (_lock) {
				Buffer.Enqueue (entry); 
				if (Buffer.Count >= BufferSize) {
					doLog.Set (); 
				}
			}
		}
		private static void executeLogging(){
			do {


				doLog.WaitOne(); 
			} while(running); 
		}

	}
}

