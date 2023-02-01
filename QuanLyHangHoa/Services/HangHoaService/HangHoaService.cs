using QuanLyHangHoa.Models;

namespace QuanLyHangHoa.Services.HangHoaService
{
    public class HangHoaService : IHangHoaService
    {

        private readonly DataContext _context;

        public static int PAGE_SIZE { get; set; } = 3;

        public HangHoaService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<HangHoaModel>> AddHangHoa(HangHoaModel hh)
        {
            _context.HangHoas.Add(hh);
            await _context.SaveChangesAsync();
            return await _context.HangHoas.ToListAsync();
        }

        public async Task<List<HangHoaModel>?> DeleteHangHoa(int id)
        {
            var hang = await _context.HangHoas.SingleOrDefaultAsync(hh => hh.Id == id);
            if(hang == null)
                return null;
            _context.HangHoas.Remove(hang);
            await _context.SaveChangesAsync();
            return await _context.HangHoas.ToListAsync();
        }

        public async Task<List<HangHoaModel>> GetAllHangHoa(string? name = null, int? page = null)
        {
            var allHangHoa = _context.HangHoas.AsQueryable();
            if(!string.IsNullOrEmpty(name))
            {
                allHangHoa = allHangHoa.Where(h => h.Name.Contains(name));
            }
            if(page.HasValue) 
            {
                var paging = page.GetValueOrDefault(1);
                allHangHoa = allHangHoa.Skip((paging - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            }
            return await allHangHoa.ToListAsync();
        }

        public async Task<List<HangHoaModel>?> UpdateHangHoa(HangHoaModel request, int id)
        {
            var hang = await _context.HangHoas.SingleOrDefaultAsync(hh => hh.Id == id);
            if (hang == null)
                return null;

            hang.Name = request.Name;
            hang.Picture = request.Picture;
            hang.Type= request.Type;
            hang.Manufacturer = request.Manufacturer;
            hang.Quantity = request.Quantity;

            await _context.SaveChangesAsync();
            return await _context.HangHoas.ToListAsync();
        }

        public async Task<HangHoaModel?> GetSingleHangHoa(int id)
        {
            var hang = await _context.HangHoas.SingleOrDefaultAsync(hh => hh.Id == id);
            if (hang == null)
                return null;
            return hang;
        }
    }
}
