using API.Models.Seed;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace API.Models
{
    public class SeedData
    {
        private readonly ApiContext _context;
        private readonly UserManager<UserDTO> _userManager;

        public SeedData(ApiContext context, UserManager<UserDTO> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            UserSeed.EnsureCreated(_context, _userManager);

            _context.SaveChanges();
        }
    }
}
