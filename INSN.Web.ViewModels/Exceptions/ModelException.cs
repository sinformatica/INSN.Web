namespace INSN.Web.ViewModels.Exceptions;

/// <summary>
/// Model Exception
/// </summary>
public class ModelException : Exception
{
    /// <summary>
    /// Property Name
    /// </summary>
    public string PropertyName { get; set; } = default!;

    /// <summary>
    /// Model Exception
    /// </summary>
    /// <param name="propertyName"></param>
    /// <param name="message"></param>
    public ModelException(string propertyName, string message)
        : base(message)
    {
        PropertyName = propertyName;
    }
}