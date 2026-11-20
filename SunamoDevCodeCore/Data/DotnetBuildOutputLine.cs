namespace SunamoDevCodeCore.Data;

/// <summary>
/// Represents the dotnet build output line type.
/// </summary>
public class DotnetBuildOutputLine
{
    /// <summary>
    /// Gets or sets the path.
    /// </summary>
    public string Path { get; set; } = null!;

    /// <summary>
    /// Gets or sets the line.
    /// </summary>
    public int Line { get; set; }

    /// <summary>
    /// Gets or sets the column.
    /// </summary>
    public int Column { get; set; }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// Gets or sets the error code.
    /// </summary>
    public string ErrorCode { get; set; } = null!;

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    public string Message { get; set; } = null!;

    /// <summary>
    /// Deconstruct.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="line">The line.</param>
    /// <param name="column">The column.</param>
    /// <param name="type">The type.</param>
    /// <param name="errorCode">The error code.</param>
    /// <param name="message">The message.</param>
    public void Deconstruct(out string path, out int line, out int column, out string type, out string errorCode, out string message)
    {
        path = Path;
        line = Line;
        column = Column;
        type = Type;
        errorCode = ErrorCode;
        message = Message;
    }
}