using Refit;

namespace Identity
{
    public interface INationalizeClient
    {
        /// <summary>
        /// Gets the country of the name provided
        /// </summary>
        /// <param name="name">Name of the person</param>
        /// <returns>Returns a country of type CountryResponse</returns>
        [Get("/")]
        Task<CountryResponse> GetCountry(string name);
    }
}
