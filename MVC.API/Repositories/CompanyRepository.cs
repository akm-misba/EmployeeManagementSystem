using MVC.API.Models;
namespace MVC.API.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {


        public CompanyRepository(MVCDBContext dbContext) : base(dbContext)
        {
        }

    }


  }

