namespace Identity.Factory.AgeBracket
{
    /// <summary>
    /// Interface for AgeBracket
    /// </summary>
    public interface IAgeBracket
    {
        /// <summary>
        /// Gets the age bracket of the name provided
        /// </summary>
        /// <returns>String of the age bracket the name belongs to</returns>
        string Render();
    }
}
