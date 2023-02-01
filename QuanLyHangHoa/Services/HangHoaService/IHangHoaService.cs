using QuanLyHangHoa.Models;

namespace QuanLyHangHoa.Services.HangHoaService
{
    public interface IHangHoaService
    {
        Task<List<HangHoaModel>> GetAllHangHoa(string? name = null, int? page = null);
        Task<List<HangHoaModel>> AddHangHoa(HangHoaModel hh);
        Task<List<HangHoaModel>?> UpdateHangHoa(HangHoaModel request, int id);
        Task<List<HangHoaModel>?> DeleteHangHoa(int id);
        Task<HangHoaModel?> GetSingleHangHoa(int id);
    }
}
