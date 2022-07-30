namespace Logger
{
    public class SomeClass : Object
    {

        //public SomeClass(Interfaces.ILogger Logger) : base()
        //{
        //    _logger = Logger;
        //}
        //private readonly Interfaces.ILogger _logger;

        // Best Practice
        public SomeClass(Interfaces.ILogger logger) : base()
        {
            Logger = logger;
        }

        protected Interfaces.ILogger Logger { get; }

        public void DoSomething(string fullName)
        {
            string message =
                $"{ fullName } did something !";

            Logger.Log(message);
        }
    }
}