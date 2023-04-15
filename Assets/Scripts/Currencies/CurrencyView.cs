using System;
using TMPro;
using UniRx;

namespace RTS.Currencies
{
    public class CurrencyView : MonoView<Currency>
    {
        public TMP_Text Text;
        IDisposable currencyChangeStream;
        public override void Set(Currency source)
        {
            currencyChangeStream?.Dispose();
            
            base.Set(source);
            SetText(source.Value.Value);
            currencyChangeStream = source.Value.Subscribe(SetText);
        }

        void SetText(int amount) => Text.text = amount.ToString();

        void OnDestroy()
        {
            currencyChangeStream?.Dispose();
        }
    }
}