using DuckAPI.Data;
using DuckAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DuckAPI.Repository
{
    public class DuckRepository : IDuckRepository
    {
        private readonly DataContext _context;
        public DuckRepository(DataContext context) 
        {
            _context = context;
        }

        public ICollection<Models.Duck> GetDucks()
        {
            return _context.Ducks.ToList();
        }
    }
}
