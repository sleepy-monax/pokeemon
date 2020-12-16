using Model.Battle;

namespace Model.Effets
{
    public interface IEffect
    {
        Stats Apply(Stats stats);
    }
}