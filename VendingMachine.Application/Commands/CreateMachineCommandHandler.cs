using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VendingMachine.Domain;

namespace VendingMachine.Application.Commands
{
    public class CreateMachineCommandHandler : IRequestHandler<CreateMachineCommand, bool>
    {
        private readonly IMachineRepository machineRepository;

        public CreateMachineCommandHandler(IMachineRepository machineRepository)
        {
            this.machineRepository = machineRepository ?? throw new ArgumentNullException(nameof(machineRepository));
        }

        public async Task<bool> Handle(CreateMachineCommand request, CancellationToken cancellationToken)
        {
            var machine = new Machine(request.Identifier);
            machine.AddPile(request.PileCount, request.PileCapacity);

            await this.machineRepository.AddAsync(machine);

            return await this.machineRepository.SaveChangesAsync() > 0;
        }
    }
}