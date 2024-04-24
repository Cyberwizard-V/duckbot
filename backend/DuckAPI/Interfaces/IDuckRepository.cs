using DuckAPI.Models;

namespace DuckAPI.Interfaces
{
    public interface IDuckRepository
    {
        public ICollection<Duck> GetDucks();
        public Duck getDuckByID(int id);
        public Duck getDuckByName(string name);
        public bool DuckExists(int id);
    }
}
