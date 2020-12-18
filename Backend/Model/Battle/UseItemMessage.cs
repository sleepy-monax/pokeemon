namespace Model.Battle
{
    class UseItemMessage : BattleMessage
    {
        public string Item { get; set; }
        public bool TargetEnemy { get; set; }
        public int CreatureIndex { get; set; }
    }
}
