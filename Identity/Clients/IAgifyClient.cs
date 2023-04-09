using Refit;

namespace Identity
{
    public interface IAgifyClient
    {
        /// <summary>
        /// Gets the age of the name provided
        /// </summary>
        /// <param name="name">Name of the person</param>
        /// <returns>Returns an age of type AgeResponse</returns>
        [Get("/")]
        Task<AgeResponse> GetAge(string name);        
    }
}
