using Zenject;

namespace RTS.Gathers
{
    public class ResourceInstaller : MonoInstaller<ResourceInstaller>
    {
        public ResourceView prefab;
        public override void InstallBindings()
        {
            BindFactories();
        }

        void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<ResourceFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ResourceViewFactory>().AsSingle().WithArguments(prefab);
        }
    }
}