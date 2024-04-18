using DuckAPI.Models;

namespace DuckAPI.Interfaces
{
    public interface IDuckRepository
    {
        ICollection<Duck> GetDucks();
    }
}
