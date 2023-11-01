using DapperAspNetCore.API.Models;

namespace DapperAspNetCore.API.Repository.Interface
{
    public interface ICompanyReposity
    {
        public Task<List<Employees>> GetEmployees();
        public Task<Employees> FindEmployee(int id);
        public Task<Employees> FindEmp(int id);
        public Task<Employees> CreateEmployee(Employees employees);
        public Task<Employees> CreateEmp(Employees employees);
        public Task<Employees> CreateEmpl(Employees employees);
        public Task<Employees> UpdateEmployee(Employees employees);
        public Task<bool> DeleteEmp(int id);
      
       
    }
}
