namespace NakaEngine.Interfaces
{
    public interface ILoadable
    {
        public float Priority => 1f;

        public void Load();

        public void Unload();
    }
}
