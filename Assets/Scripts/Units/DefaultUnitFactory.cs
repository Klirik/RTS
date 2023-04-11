namespace RTS
{
    public class DefaultUnitFactory : AbstractUnitFactory
    {
        public override Unit Create(UnitConfig config)
        {
            return new Unit(config);
        }
    }
}