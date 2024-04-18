using DuckAPI.Models;

namespace DuckAPI.Interfaces
{
    public interface IDucklore
    {
        ICollection<Ducklore> GetDucklores();
    }
}
