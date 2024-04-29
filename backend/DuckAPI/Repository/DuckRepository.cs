using DuckAPI.Data;
using DuckAPI.Interfaces;
using DuckAPI.Models;
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

        public bool DuckExists(int id)
        {
            return _context.Ducks.Any(p => p.DuckID == id);
        }

        public bool DuckExists(string name)
        {
            return _context.Ducks.Any(p => p.DuckName == name);
        }

        public Duck getDuckByID(int id)
        {
            return _context.Ducks.Where(p => p.DuckID == id).FirstOrDefault();
        }

        public List<Duck> getDuckByName(string name)
        {
            return _context.Ducks.Where(p => p.DuckName == name).ToList();
        }

    }
}
