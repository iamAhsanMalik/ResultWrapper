namespace RW.Common;

public interface IResultBase
{
    /// <summary>
    /// Gets or sets a value indicating whether the service result is valid.
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Gets or sets the message associated with the service result.
    /// </summary>
    public string Message { get; set; }


    /// <summary>
    /// Gets or sets the code associated with the service result.
    /// </summary>
    public int Code { get; set; }
}
