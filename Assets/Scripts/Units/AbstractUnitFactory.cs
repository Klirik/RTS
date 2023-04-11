using Zenject;

namespace RTS
{
    public abstract class AbstractUnitFactory : IFactory<UnitConfig, Unit>
    {
        public abstract Unit Create(UnitConfig config);
    }
}