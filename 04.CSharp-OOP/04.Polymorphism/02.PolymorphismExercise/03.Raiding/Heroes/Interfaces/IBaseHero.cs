namespace Raiding.Heroes.Interfaces
{
    public interface IBaseHero
    {
        string Name { get; }
        int Power { get; }
        string CastAbility();
    }
}
