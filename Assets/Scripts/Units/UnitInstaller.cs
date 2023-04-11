using RTS.UI;
using Zenject;

namespace RTS
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
            Container.BindInterfacesAndSelfTo<DefaultUnitFactory>().AsSingle();
            Container.BindIFactory<UnitView>()
                .FromComponentInNewPrefab(prefab).AsSingle();

        }
    }
}