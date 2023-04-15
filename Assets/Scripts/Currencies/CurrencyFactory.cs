using Zenject;

namespace RTS.Currencies
{
    public class CurrencyFactory : IFactory<CurrencyConfigSO, Currency>
    {
        public Currency Create(CurrencyConfigSO config)
        {
            return new Currency(config.InitialValue);
        }
    }
}