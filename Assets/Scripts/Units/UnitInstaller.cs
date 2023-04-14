using RTS.UI;
using Zenject;

namespace RTS.Units
{
    public class UnitInstaller : MonoInstaller<UnitInstaller>
    {
        public UnitView prefab;
        public override void InstallBindings()
        {
            BindDefaultFactoryUnit();
        }

        void BindDefaultFactoryUnit()
        {
            Container.BindInterfacesAndSelfTo<UnitMovement>().AsSingle();
            Container.BindInterfacesAndSelfTo<UnitFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<UnitViewFactory>().AsSingle().WithArguments(prefab);
        }
    }
}