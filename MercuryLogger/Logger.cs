using System;
using System.IO; 
using System.Collections.Generic; 
using System.Threading; 

namespace MercuryLogger
{
	class Logger
	{
		public string FilePath { get; set;}
		public bool ImmediateStdOutLogging { get; set; }
		public bool LogToStdOut { get; set; }
		public LogLevel HighestLevelToStdOut { get; set; }
		public LogLevel HighestLevelToFile { get; set; }
		public LogLevel LowestCachedLevel { get; set; }
		public int BufferSize { get; set; }
		public bool Running {get{return this.Running;}}

		Thread loggingThread; 
		Queue<LogEntry> Buffer = new Queue<LogEntry>(); 
		bool running = false; //Thread
		bool active = false;  //Execution
		object _lock = new object(); 
		AutoResetEvent doLog = new AutoResetEvent(false); 


		public Logger (LoggerSettings settings)
		{
			this.applySettings (settings); 

		}

		public void applySettings(LoggerSettings settings){
			this.FilePath = settings.FilePath;  
			this.ImmediateStdOutLogging = settings.ImmediateStdOutLogging; 
			this.LogToStdOut = settings.LogToStdOut; 
			this.HighestLevelToStdOut = settings.HighestLevelToStdOut; 
			this.HighestLevelToFile = settings.HighestLevelToFile; 
			this.BufferSize = settings.BufferSize; 
		}



		public void start(){
			if (!running) {
				loggingThread = new Thread (executeLogging); 
				loggingThread.Start (); 
				running = true; 
			}
			else throw new Exception ("Already Running");
		}
		public void stop(){
			if (running) {
				flush (); 
				running = false; 
					if (!loggingThread.Join (1000)) { 
						loggingThread.Abort ();
						loggingThread.Join (100); 
					}
				logToFile (); 
			}
		}

		public void log(LogEntry entry){
			if (this.ImmediateStdOutLogging)
				Console.WriteLine (entry.ToString ());

			lock (_lock) {
				Buffer.Enqueue (entry); 
				if ((Buffer.Count >= BufferSize || entry.Level > LowestCachedLevel) && this.running && !this.active) // Also checking if not currently actively writing to file
					doLog.Set (); 
			}
		}
		public void flush(){
			if (running && !active) {
				doLog.Set (); 
			}
		}
		private void logToStdOut(LogEntry entry){
			if (entry.Level <= HighestLevelToStdOut)
				Console.WriteLine (entry.ToString ()); 
		}
		private bool itemsInQueue(){
			lock (_lock) {
				return (Buffer.Count > 0); 
			}
		}
		private LogEntry getNextEntry(){
			lock (_lock) {
				return Buffer.Dequeue (); 
			}
		}
		private void logToFile(){
			List<string> writeBuffer = new List<string>(); 
			while(itemsInQueue()){
				LogEntry entry = getNextEntry(); 

				if(entry.Level <= HighestLevelToFile)
					writeBuffer.Add(entry.ToString()); 

				if(!ImmediateStdOutLogging && LogToStdOut)
					logToStdOut(entry); 
			}
			File.AppendAllLines(FilePath,writeBuffer); 
		}
		private void executeLogging(){
			do {
				doLog.WaitOne(); 
				this.active = true; 

				//...
				logToFile(); 
				//...

				this.active = false; 
			} while(running); 
		}

	}
}

