using Identity.Factory.AgeBracket;

namespace Identity.Factory
{
    /// <summary>
    /// Factory for creating an age bracket.
    /// </summary>
    public interface IAgeBracketFactory
    {
        /// <summary>
        /// Gets the age bracket based on the given age
        /// </summary>
        /// <param name="age">Age of the person</param>
        /// <returns>IAgeBracket object type with string of the age bracket</returns>
        public IAgeBracket GetAgeBracket(AgeResponse age);
    }
}
