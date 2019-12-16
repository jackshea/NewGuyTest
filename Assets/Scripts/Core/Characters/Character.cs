namespace Core.Characters
{
    /// <summary>
    ///     角色
    /// </summary>
    public class Character
    {
        private Character()
        {
            Backpack = new Backpack();
        }

        public static Character Instance { get; } = new Character();
        public Backpack Backpack { get; }
    }
}