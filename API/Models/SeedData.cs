using API.Models.Seed;
using System.Linq;

namespace API.Models
{
    public class SeedData
    {
        private readonly ApiContext _context;

        public SeedData(ApiContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            var testPhone = _context.Phones.FirstOrDefault(b => b.ID == 1);
            if (testPhone != null)
                return;

            PhoneSeed.EnsureCreated(_context);
            CameraSeed.EnsureCreated(_context);
            ScoreSeed.EnsureCreated(_context);
            QuestionSeed.EnsureCreated(_context);
            QuestionOptionSeed.EnsureCreated(_context);

            _context.SaveChanges();
        }
    }
}
