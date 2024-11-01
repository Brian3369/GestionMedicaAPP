using GestionMedicaAPP.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMedicaAPP.Application.Contracts
{
    public interface IAppointmentsService : IBaseService<RutaResponse, RutaSaveDto, RutaUpdateDto>
    {
    }
}
