namespace SymXchange.Service.Configuration;
/// <summary>
/// The SymXchangeException class is designed to handle exception specific to the SymXchange service. 
/// It provides flexibility in create instances of the class with different parameters depending on the specific scenario
/// </summary>
public class SymXchangeException : Exception
{

    /// <summary>
    /// The constructor takes a string parameter called message. 
    /// It calls new base Exception class constructor eht thr message parameter processed by the ProcessExceptionMessage method extension method.
    /// This constructor used to create an instance of the SymXchangeException class with a custom error message.
    /// </summary>
    /// <param name="message">error message</param>
    public SymXchangeException(string message) : base(message.ProcessExceptionMessage()) { }

    /// <summary>
    /// The SymXchangeException class is designed to handle exception specific to the SymXchange service. 
    /// It provides flexibility in creating instances of the class with different parameters depending on the specific scenario.
    /// </summary>
    /// <param name="exception">The exception.</param>
    public SymXchangeException(Exception exception) : base(
        exception.Message.ProcessExceptionMessage(), exception)
    { }

    /// <summary>
    /// The SymXchangeException class is designed to handle exception specific to the SymXchange service. 
    /// It provides flexibility in creating instances of the class with different parameters depending on the specific scenario.
    /// </summary>
    /// <param name="statusCode">The SymXchange service status code.</param>
    /// <param name="message">The error message.</param>
    public SymXchangeException(int statusCode, string message) : base(message.ProcessExceptionMessage(statusCode)) { }
}
