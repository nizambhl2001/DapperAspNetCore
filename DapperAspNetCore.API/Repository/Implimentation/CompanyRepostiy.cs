using Dapper;
using DapperAspNetCore.API.Data;
using DapperAspNetCore.API.Models;
using DapperAspNetCore.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace DapperAspNetCore.API.Repository.Implimentation
{
    public class CompanyRepostiy : ICompanyReposity
    {
        
        public IDbConnection db;
        public CompanyRepostiy(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("SqlConnecitonSetting"));
        }

      
        public async Task<List<Employees>> GetEmployees()
        {
       
            var companies = await db.QueryAsync<Employees>("st_getAllEmp", commandType: CommandType.StoredProcedure);
            return companies.ToList();
            
        }

        public async Task<Employees> FindEmployee(int id)
        {

            var company = await db.QuerySingleOrDefaultAsync<Employees>("st_getById", new { Id = id }, commandType: CommandType.StoredProcedure);
            return company;
        }  
        public async Task<Employees> FindEmp(int id)
        {

           IEnumerable<Employees> company = await QueryData<Employees,dynamic>("st_getById", new { Id = id });
            return company.FirstOrDefault();
        }

        public async Task<Employees> CreateEmployee(Employees employees)
        {
            var parem = new DynamicParameters();
            parem.Add("@Id", 0, DbType.Int32,direction:ParameterDirection.Output);
            parem.Add("@Name", employees.Name);
            parem.Add("@Age", employees.Age);

            await db.ExecuteAsync("st_addEmp",parem, commandType: CommandType.StoredProcedure);
            employees.Id = parem.Get<int>("Id");
            return employees;
        }
        //another way create employee
        public async Task<Employees> CreateEmp(Employees employees)
        {
            var parem = new
            {
                 employees.Id,
                employees.Name,
               employees.Age
            };
            await db.ExecuteAsync("st_addEmp", parem, commandType: CommandType.StoredProcedure);
            return employees;
        }  
        
        //another way create employee
        public async Task<Employees> CreateEmpl(Employees employees)
        {
            var parem = new
            {
                 employees.Id,
                employees.Name,
               employees.Age
            };
            await ExecuteData("st_addEmp", parem);
            return employees;
        }

        public async Task<bool> DeleteEmp(int id)
        {
            var company = await db.ExecuteAsync("st_DeleteEmp", new { @Id =id}, commandType: CommandType.StoredProcedure);
            return company > 0;
        }

        public async Task<Employees> UpdateEmployee(Employees employees)
        {
            var parem = new DynamicParameters();
            parem.Add("@Id", employees.Id,DbType.Int32);
            parem.Add("@Name", employees.Name);
            parem.Add("@Age", employees.Age);

            await db.ExecuteAsync("st_UpdateEmp", parem, commandType: CommandType.StoredProcedure);
            return employees;
        }

        public async Task<IEnumerable<T>> QueryData<T,P>(string SName, P parameters)
        {
            return await db.QueryAsync<T>(SName, parameters, commandType: CommandType.StoredProcedure);
        } 
        public async Task ExecuteData<T>(string SName, T parameters)
        {
           await db.ExecuteAsync(SName, parameters, commandType: CommandType.StoredProcedure);
         
        }
    }
}

