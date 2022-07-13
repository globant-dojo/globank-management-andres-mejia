using AutoMapper;
using DojoProject.Application.Report.Dtos;
using DojoProject.Domain.Exceptions;
using DojoProject.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Report.Queries
{
    public class ReportQueryHandler : IRequestHandler<ReportQuery, ReportsDto>, IDisposable
    {

        private readonly IGenericRepository<Domain.Entities.Client> _clientRepository;
        private readonly IGenericRepository<Domain.Entities.Movement> _movementRepository;

        private IMapper _mapper;

        public ReportQueryHandler(IGenericRepository<Domain.Entities.Client> clientRepository,
            IGenericRepository<Domain.Entities.Movement> movementRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _movementRepository = movementRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<ReportsDto> Handle(ReportQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request requerido");

            var resultMovement = await _movementRepository.GetAsync(movement =>
                movement.Account.Client.Id == request.ClientId
                && movement.Date > request.dateInit
                && movement.Date < request.dateEnd
                , null, "Account");
            var resultClient = await _clientRepository.GetByIdAsync(request.ClientId);
            if (resultMovement == null || resultMovement.Count() == 0)
                throw new ArgumentNullException("No se encuentra registro de movimientos");
            ReportsDto reportsDto = new ReportsDto() { Movements = new List<ReportDto>()};

            foreach (var movement in resultMovement)
            {
                ReportDto reportDto = new ReportDto
                {
                    Fecha = movement.Date.ToShortDateString(),
                    Cliente = resultClient.Name,
                    NumeroCuenta = movement.Account.Account_Number.ToString(),
                    Estado = movement.Account.State,
                    Movimiento = movement.Value,
                    SaldoDisponible = movement.Balance,
                    SaldoInicial = movement.Account.Initial_Balance,
                    Tipo = movement.Type.ToString(),


                };

                reportsDto.Movements.Add(reportDto);

            }
            return reportsDto;
        }

        protected virtual void Dispose(bool disposing)
        {
            this._clientRepository.Dispose();
        }

    }
}
