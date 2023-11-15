using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVC.API.Models;

namespace MVC.API.Repositories
{
    public interface IAttendanceSummaryRepository :  IRepository<AttendanceSummary>
    {
        List<AttendanceSummary> GetAttendanceSummaryListByCompanyId(int ComId, int month, int year);

    }
}
