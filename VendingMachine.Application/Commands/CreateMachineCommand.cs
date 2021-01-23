using MediatR;

namespace VendingMachine.Application.Commands
{
    public class CreateMachineCommand : IRequest<bool>
    {
        public string Identifier { get; set; }

        public int PileCount { get; set; }

        public int PileCapacity { get; set; }
    }
}