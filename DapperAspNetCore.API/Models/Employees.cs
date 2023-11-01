using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DapperAspNetCore.API.Models
{

    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
       
    }
}
