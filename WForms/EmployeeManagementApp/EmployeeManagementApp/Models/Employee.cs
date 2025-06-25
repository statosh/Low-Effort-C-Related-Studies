namespace EmployeeManagementApp.Models {
    public class Employee {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public override string ToString() {
            return $"{FirstName} {LastName} - {Position} - {Salary:C}";
        }
    }
}
