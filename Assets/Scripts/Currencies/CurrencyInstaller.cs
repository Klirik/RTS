using Zenject;

namespace RTS.Currencies
{
    public class CurrencyInstaller : MonoInstaller<CurrencyInstaller>
    {
        public override void InstallBindings()
        {
            BindFactories();
        }

        void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<CurrencyFactory>().AsSingle();
        }
    }
}