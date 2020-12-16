using Model.Battle;

namespace Model.Effets
{
    interface IEffect
    {
        Stats Apply(Stats stats);
    }
}