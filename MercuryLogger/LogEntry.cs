using System;
using System.Text; 

namespace MercuryLogger
{
	public class LogEntry
	{
		public LogLevel Level { get; set; }
		public DateTime DateTime {get; set;}
		public string Tag {get; set;}
		public string Message { get; set; }
		public Exception Exception {get; set;}

		public LogEntry ()
		{
			Level = LogLevel.VERBOSE; 
			DateTime = DateTime.Now; 
			Tag = ""; 
			Message = ""; 
			Exception = null; 
		}
		
		public LogEntry(LogLevel Level, string Tag, string Message, Exception Exception = null){
			this.Level = Level; 
			this.DateTime = DateTime.UtcNow; 
			this.Tag = Tag; 
			this.Message = Message; 
			this.Exception = Exception; 
		}

		public override string ToString ()
		{
			StringBuilder sb = new StringBuilder (); 
			sb.Append (getLevelText(Level));
			sb.Append ("@"); 
			sb.Append (DateTime.ToString ("O")); 
			sb.Append ("~"); 
			sb.AppendFormat ("[{0}]:{1}",Tag,Message); 
			if (Exception != null)
				sb.AppendLine (getExceptionString (Exception)); 
			return sb.ToString (); 
		}

		public static string getExceptionString(Exception ex){
			StringBuilder sb = new StringBuilder (); 
			sb.AppendLine (ex.ToString ());
			sb.AppendLine ("Message: " + ex.Message); 
			if (ex.InnerException != null) {
				sb.AppendLine ("Inner: " + ex.InnerException.ToString ()); 
				sb.AppendLine (ex.StackTrace);
			}
			return sb.ToString ();
		}
			
		public static string getLevelText(LogLevel level){
			switch (level) {
			case LogLevel.VERBOSE:
				return "VERBOSE"; 
			case LogLevel.DEBUG: 
				return "DEBUG";
			case LogLevel.INFO:
				return "INFO"; 
			case LogLevel.WARNING: 
				return "WARNING"; 
			case LogLevel.ERROR: 
				return "ERROR"; 
			default: 
				throw new Exception ("Nonexistent LogLevel"); 
			}
		}



	}
}

