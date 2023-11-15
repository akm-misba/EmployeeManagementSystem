using MVC.Models;
using MVC.Repositories;
using static MVC.Models.Company;
using static MVC.Repositories.CompanyRepository;
namespace MVC.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {


        public CompanyRepository(MVCDBContext dbContext) : base(dbContext)
        {
        }

    }


    }

