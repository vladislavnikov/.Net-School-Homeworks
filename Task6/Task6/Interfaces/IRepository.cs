namespace Task6.Interfaces
{
    public interface IRepository
    {
        void Save(Catalog catalog, string path);
        Catalog Load(string path);
    }
}
