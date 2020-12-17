using Model.Battle;
using Model.Creature;

namespace Model.Effets
{
    public interface IEffect
    {
        Stats Apply(Stats stats);
    }
}