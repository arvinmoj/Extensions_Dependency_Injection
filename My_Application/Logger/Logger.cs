namespace Logger
{
    public class Logger : Object, Interfaces.ILogger
    {
        public Logger(): base()
        {
        }

        public void Log(string message)
        {
            Console.WriteLine("Logger ==> ", message);
        }
    }
}