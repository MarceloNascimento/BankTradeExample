using MediatR;
using Microsoft.Extensions.Logging;
using SampleBank.Challenge.BankTrades.API.ViewModels;
using SampleBank.Challenge.BankTrades.Domain.Entities;
using SampleBank.Challenge.BankTrades.Domain.Interfaces.Repositories;

namespace SampleBank.Challenge.BankTrades.Application.Commands.ClientListAll
{
    public class ClassifyTradesCommand 
    {
        protected readonly IClientRepository ClientRepository;
        private readonly ILogger _logger;

        public ClassifyTradesCommand(ILogger logger, IClientRepository ClientRepository)
        {
            this._logger = logger;
            this.ClientRepository = ClientRepository;
        }

        public async Task<ClassifyTradesViewModel> Handle(ClassifyTradesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null || request.Id is 0) { return await Task.FromResult(new ClassifyTradesViewModel()); }

                var Client = await this.ClientRepository.GetAsync(request.Id, cancellationToken);
                if (Client != null)
                {
                    var TaskDelete = this.ClientRepository.DeleteAsync(Client, cancellationToken);
                    return new ClassifyTradesViewModel() { IsDeleted = await TaskDelete };
                }

                return new ClassifyTradesViewModel() { IsDeleted = false };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Processing request from {nameof(Handle)}", ex.Message);
                return await Task.FromResult(new ClassifyTradesViewModel());
            }
        }
    }
}