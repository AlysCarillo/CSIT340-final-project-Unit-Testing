using Identity.Factory.AgeBracket;

namespace Identity.Factory
{
    public class AgeBracketFactory : IAgeBracketFactory
    {
        public IAgeBracket GetAgeBracket(AgeResponse age)
        {
            IAgeBracket _ageBracket;
            int ageValue = age.Age;

            switch (ageValue)
            {
                case int n when n >= 0 && n <= 9:
                    _ageBracket = new GenAlphaAgeBracket();
                    break;

                case int n when n >= 10 && n <= 25:
                    _ageBracket = new GenZAgeBracket();
                    break;

                case int n when n >= 26 && n <= 41:
                    _ageBracket = new MillennialsAgeBracket();
                    break;

                case int n when n >= 42 && n <= 57:
                    _ageBracket = new GenXAgeBracket();
                    break;

                case int n when n >= 58 && n <= 67:
                    _ageBracket = new BoomersIIAgeBracket();
                    break;

                case int n when n >= 68 && n <= 76:
                    _ageBracket = new BoomersIAgeBracket();
                    break;

                case int n when n >= 77 && n <= 94:
                    _ageBracket = new PostWarAgeBracket();
                    break;

                case int n when n >= 95 && n <= 100:
                    _ageBracket = new WWIIAgeBracket();
                    break;
                default:
                    throw new ArgumentException("Age is Invalid");
            }

            return _ageBracket;
        }
    }
}
