using LeaveAppTutorial.Contracts;
using LeaveAppTutorial.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveAppTutorial.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        public readonly AppDbContext _db;
        public LeaveRequestRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(LeaveRequest entity)
        {
            await _db.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(LeaveRequest entity)
        {
            _db.LeaveRequest.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<LeaveRequest>> FindAll()
        {
            var leavetype = await _db.LeaveRequest
                .Include(t => t.LeaveType)
                .ToListAsync();
            return leavetype;
        }

        public async Task<LeaveRequest> FindById(int id)
        {
            var request = await _db.LeaveRequest
                .Include(t => t.LeaveType)
                .FirstOrDefaultAsync();
            return request;
        }

        public async Task<bool> isExist(int id)
        {
            var exists = await _db.LeaveTypes.AnyAsync(t => t.Id == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            var save = _db.SaveChangesAsync();
            return await save > 0;
        }

        public async Task<bool> Update(LeaveRequest entity)
        {
            _db.LeaveRequest.Update(entity);
            return await Save();
        }
    }
}
