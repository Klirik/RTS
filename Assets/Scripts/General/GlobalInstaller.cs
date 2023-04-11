using RTS.Inputs;
using Zenject;

namespace RTS
{
    public class GlobalInstaller : MonoInstaller<GlobalInstaller>
    {
        public MarkMovementView prefab;
        public override void InstallBindings()
        {
            BindSystem();
        }

        void BindSystem()
        {
            Container.Bind<UpdateManager>().AsSingle().NonLazy();
            Container.Bind<ClickMovementSystem>().AsSingle().NonLazy();
            Container.Bind<SelectSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MarkMovementSystem>().AsSingle().WithArguments(prefab).NonLazy();
            
            BindUpdatable<NavigationSystem>();
            BindUpdatable<InputSystem>();
        }
        
        void BindUpdatable<T>() where T : ITickable
        {
            Container.BindInterfacesAndSelfTo<T>().AsSingle()
                .OnInstantiated<T>((context, obj) => Container.Resolve<UpdateManager>().Add(obj))
                .NonLazy();
        }
    }
}