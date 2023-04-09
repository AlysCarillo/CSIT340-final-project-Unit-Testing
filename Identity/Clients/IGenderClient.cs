using Refit;

namespace Identity
{
    public interface IGenderClient
    {
        /// <summary>
        /// Gets the gender of the name provided
        /// </summary>
        /// <param name="name">Name of the person</param>
        /// <returns>Returns a gender of type GenderResponse</returns>
        [Get("/")]
        Task<GenderResponse> GetGenderRole(string name);
    }
}
