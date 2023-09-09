using LeaveAppTutorial.Contracts;
using LeaveAppTutorial.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveAppTutorial.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        public readonly AppDbContext _db;
        public LeaveTypeRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(LeaveType entity)
        {
            //throw new NotImplementedException();
            await _db.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(LeaveType entity)
        {
            //throw new NotImplementedException();
            _db.LeaveTypes.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<LeaveType>> FindAll()
        {
            var leavetype = await _db.LeaveTypes.ToListAsync();
            return leavetype;
        }

        public async Task<LeaveType> FindById(int id)
        {
            var leaveType = await _db.LeaveTypes.FindAsync();
            return leaveType;
        }

        public async Task<bool> isExist(int id)
        {
            var exists = await _db.LeaveTypes.AnyAsync(x => x.Id == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return await Save();
        }
    }
}
