namespace RTS.Healths
{
    public abstract class BaseHaveHealth<TEntity> : IHaveHealth
    {
        protected readonly TEntity source;

        public BaseHaveHealth(TEntity source)
        {
            this.source = source;
        }

        public abstract void RestoreHealth(int amount);
        public abstract void TakeDamage(int amount);
    }
}