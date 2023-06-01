using System.Collections.Generic;
using WebAppChurrasco.Areas.Identity.Data;
using WebAppChurrasco.Entities;

namespace WebAppChurrasco.Interfaces
{
    public interface IParticipantesRepository
    {
        Task<Participantes> AdicionarParticipantesChurras(Participantes participantes);

        IList<Participantes> ListParticipantesChurras(int? Id);

        IList<WebAppChurrascoUser> GetUsers();

        IList<Participantes> GetParticipantes(int? Id);

        bool RemoverParticipantesChurras(Participantes participantes);

    }
}
