namespace Core.Character
{
    /// <summary>
    ///     角色
    /// </summary>
    public class Character
    {
        private Character()
        {
            Packaget = new Package();
        }

        public static Character Instance { get; } = new Character();
        public Package Packaget { get; }
    }
}