using EntityFramework.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactorController : ControllerBase {
        private readonly Datacontext _context;

        public CharactorController(Datacontext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Charactor>>> Get(int userId)
        {
            var characters = await _context.charactors
                .Where(c => c.UserId == userId)
                .Include(o => o.Weapon)
                .Include(o => o.Skills)
                .ToListAsync();

            return characters;
        }
        [HttpPost]
        public async Task<ActionResult<List<Charactor>>> create(CreateCharacterDto  charactor)
            {
            var user = await _context.userst.FindAsync(charactor.UserId);

            if(user == null)
                return NotFound();
            var Newcharacters = new Charactor
            {
                Name = charactor.Name,
                RpgClass = charactor.RpgClass,
                User = user

            };
            _context.charactors.Add(Newcharacters);

            await _context.SaveChangesAsync();

            return await Get(charactor.UserId); 
            }

        [HttpPost("weapon")]
        public async Task<ActionResult<Charactor>> create(AddWeaponDto charactor)
        {
            var user = await _context.charactors.FindAsync(charactor.CharacterId);

            if (user == null)
                return NotFound();
            var NewWeapon = new Weapon
            {
                Name = charactor.Name,
                Damage = charactor.Damage,
                Charactor = user

            };
            _context.weapons.Add(NewWeapon);

            await _context.SaveChangesAsync();

            return user;
        }

        [HttpPost("skills")]
        public async Task<ActionResult<Charactor>> addSkills(AddCharactorSkillDTO charactor)
        {
            var characto = await _context.charactors
                .Where(c => c.Id == charactor.charactorId)
                .Include(c => c.Skills)
                .FirstOrDefaultAsync();

            if (characto == null)
                return NotFound();

            var skillId = await _context.Skills.FindAsync(charactor.skillId);
            if (skillId == null)
                return NotFound();



            characto.Skills.Add(skillId);

            await _context.SaveChangesAsync();

            return characto;
        }
    }
}
