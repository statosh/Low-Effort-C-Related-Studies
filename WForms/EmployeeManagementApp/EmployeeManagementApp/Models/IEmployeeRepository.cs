using System.Collections.Generic;

namespace EmployeeManagementApp.Models {
    public interface IEmployeeRepository {
        List<Employee> GetAll();
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        List<Employee> Search(string query);
    }
}
