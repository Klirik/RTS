namespace RTS.Healths
{
    public interface IHaveHealth : IDamageable
    {
        void RestoreHealth(int amount);
    }
}