namespace WebAPI.Core.Exception
{
    public class ControllerException : System.Exception
    {
        public ControllerException(string message) : base(message) { }

        public ControllerException(string message, System.Exception innerException) : base(message, innerException) { }

    }
}