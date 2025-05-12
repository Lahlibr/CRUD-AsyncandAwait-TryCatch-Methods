using WebApplication6.Models;

namespace WebApplication6.Service
{
    public class ServiceEmployer
    {
        private readonly List<Employe> _employe = new()
        {
            new Employe {Id=1,Name="Ajsal",Department="HR",Age=21 },
            new Employe {Id=2,Name="Jomy",Department="Manager",Age =21},
        };
        public Task<List<Employe>>GetAllAsync()
        {
            return Task.FromResult(_employe);
        }
        public Task<Employe?> GetAsync(int id)
        {
            var emp = _employe.FirstOrDefault(e=>e.Id == id);
            return Task.FromResult(emp);
        }

        
        public async Task AddAsync(Employe employees)
        {
            try
            {
                employees.Id = _employe.Max(e => e.Id) + 1;
                _employe.Add(employees);
            }
            catch (Exception ex) {
                Console.WriteLine($"Error:{ex.Message}");
            }
           
        }
        public async Task<bool> UpdateAsync(int id, Employe updated)
        {
            try
            {
                var emp = _employe.FirstOrDefault(e => e.Id == id);
                if (emp == null) return false;
                emp.Name = updated.Name;
                emp.Department = updated.Department;
                emp.Age = updated.Age;
                return true;
            }
            catch (Exception ex) { 
                Console.WriteLine($"Error id{id}:{ex.Message}");
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var emp = _employe.FirstOrDefault(e => e.Id == id);
                if (emp == null) return false;
                _employe.Remove(emp);
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine($"Error {id} : {ex.Message}");
                return false;
            }
            
        }
    }
}
