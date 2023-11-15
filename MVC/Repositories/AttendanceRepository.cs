using MVC.Models;

namespace MVC.Repositories
{
    public class AttendanceRepository: Repository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(MVCDBContext dbContext) : base(dbContext)
        {
        }
    }
}
