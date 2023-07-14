using System.Diagnostics.CodeAnalysis;

namespace employeeManagementAPI.Models
{
    public class Employees
    {
        #region Properties
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string EmpDesignation { get; set; }
        public double EmpSalary { get; set; }
        public bool EmpIsPermenant { get; set; }
        public string EmpEmail { get; set; }
        #endregion

        #region Data

        static List<Employees> eList = new List<Employees>()
        {
            new Employees(){ EmpNo=101, EmpName="Karan", EmpDesignation="Sales", EmpEmail="karan@gmail.com", EmpIsPermenant=true, EmpSalary=5000},
            new Employees(){ EmpNo=102, EmpName="Sumit", EmpDesignation="HR", EmpEmail="sumit@gmail.com", EmpIsPermenant=true, EmpSalary=15000},
            new Employees(){ EmpNo=103, EmpName="Priya", EmpDesignation="Sales", EmpEmail="priya@gmail.com", EmpIsPermenant=false, EmpSalary=25000},
            new Employees(){ EmpNo=104, EmpName="Riya", EmpDesignation="Sales", EmpEmail="riya@gmail.com", EmpIsPermenant=true, EmpSalary=5000},
            new Employees(){ EmpNo=105, EmpName="Isha", EmpDesignation="HR", EmpEmail="isha@gmail.com", EmpIsPermenant=true, EmpSalary=35000},
            new Employees(){ EmpNo=106, EmpName="Ashok", EmpDesignation="Sales", EmpEmail="ashok@gmail.com", EmpIsPermenant=false, EmpSalary=5000},
            new Employees(){ EmpNo=107, EmpName="Mahesh", EmpDesignation="Sales", EmpEmail="mahesh@gmail.com", EmpIsPermenant=true, EmpSalary=2000},
            new Employees(){ EmpNo=108, EmpName="Vivek", EmpDesignation="Sales", EmpEmail="vivek@gmail.com", EmpIsPermenant=false, EmpSalary=5000},
        };

        #endregion

        #region Get Data
        public List<Employees> GetAllEmployees()
        {
            return eList;
        }

        public Employees GetEmpById(int id)
        {
            var emp = eList.Find(em => em.EmpNo == id);
            if (emp != null)
            {
                return emp;
            }
            throw new Exception("Employee Not found");
        }

        public int GetTotalEmployees()
        {
            var total = eList.Count;
            return total;
        }
        public List<Employees> GetEmpByDesignation(string designation)
        {
            var emp = eList.FindAll(em => em.EmpDesignation == designation);
            return emp;
        }
        #endregion

        #region Add, Update and Delete
        public string AddEmployee(Employees newEmp)
        {
            eList.Add(newEmp);
            return "Employee Added Successfully";
        }

        public string UpdateEmployee(Employees update)
        {
            var emp = eList.Find(em => em.EmpNo == update.EmpNo);
            if (emp != null)
            {
                emp.EmpName = update.EmpName;
                emp.EmpDesignation = update.EmpDesignation;
                emp.EmpSalary = update.EmpSalary;
                emp.EmpIsPermenant = update.EmpIsPermenant;
                emp.EmpEmail = update.EmpEmail;
                return "Employee Infortmation updated successfully";
            }
            throw new Exception("Employee not found");
        }
        public string DeleteEmployee(int id)
        {
            var emp = eList.Find(em => em.EmpNo == id);
            if (emp != null)
            {
                eList.Remove(emp);
                return "Employee deleted";
            }
            throw new Exception("Emplyee Not found and thus not deleted");
        }
        #endregion
    }
}
