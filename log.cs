using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace logProject
{
    public class log
    {
        static string logFile = Combine(CurrentDirectory, "log.txt");
        static string errFile = Combine(CurrentDirectory, "error.txt");
        public log()
        {

        }
        public void WriteToLogFile(String s)
        {
            try
            {
                string logFile = Combine(CurrentDirectory, "log.txt");
                if (!File.Exists(logFile))
                {
                    File.Create(logFile).Dispose();
                }
                using (StreamWriter logg = File.AppendText(logFile))
                {
                    logg.WriteLine(s);
                    logg.Close();
                }

            }
            catch (Exception e)
            {
                e.ToString();
            }

        }
        public void WriteToErrFile(String s)
        {
            try
            {
                string lerrFile = Combine(CurrentDirectory, "err.txt");
                if (!File.Exists(logFile))
                {
                    File.Create(logFile).Dispose();
                }
                using (StreamWriter err = File.AppendText(errFile))
                {
                    err.WriteLine(s);
                    err.Close();
                }

            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
    }
}