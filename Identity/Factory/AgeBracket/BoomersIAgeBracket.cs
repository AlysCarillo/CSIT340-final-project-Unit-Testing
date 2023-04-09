using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Identity.Factory.AgeBracket
{
    public class BoomersIAgeBracket : IAgeBracket
    {
        public string Render()
        {
            return "Boomers I";
        }
    }
}
