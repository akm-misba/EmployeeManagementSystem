using MVC.API.Models;

namespace MVC.API.Repositories
{
    public class AttendanceRepository: Repository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(MVCDBContext dbContext) : base(dbContext)
        {
        }
    }
}
