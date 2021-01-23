using System;
using System.Threading.Tasks;
using VendingMachine.Application;
using VendingMachine.Domain;

namespace VendingMachine.SqlPersistence
{
    public class MachineRepository : IMachineRepository
    {
        private readonly MachineContext context;

        public MachineRepository(MachineContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Machine> AddAsync(Machine machine)
        {
            await this.context.AddAsync(machine);

            return machine;
        }

        public Task<int> SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();
        }
    }
}