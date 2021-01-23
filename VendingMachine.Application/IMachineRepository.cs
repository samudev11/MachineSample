using System.Threading.Tasks;
using VendingMachine.Domain;

namespace VendingMachine.Application
{
    public interface IMachineRepository
    {
        Task<Machine> AddAsync(Machine machine);

        Task<int> SaveChangesAsync();
    }
}