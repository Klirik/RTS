using System.Collections.Generic;
using RTS.Currencies;

namespace RTS
{
    public class FactionState
    {
        public CurrenciesCollection CurrenciesCollection;
        CurrencyFactory currencyFactory;

        public FactionState(CurrenciesCollection currenciesCollection, CurrencyFactory currencyFactory)
        {
            CurrenciesCollection = currenciesCollection;
            this.currencyFactory = currencyFactory;
        }

        public void FillCurrencies(List<CurrencyConfigSO> currencies, List<CurrencyView> currencyViews)
        {
            for (var i = 0; i < currencies.Count; i++)
            {
                var config = currencies[i];
                var currency = currencyFactory.Create(config);
                CurrenciesCollection.Add(config.Type, currency);
                currencyViews[i].Set(currency);
            }
        }
    }
}