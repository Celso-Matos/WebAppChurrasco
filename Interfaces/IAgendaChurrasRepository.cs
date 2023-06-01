using System.Collections.Generic;
using WebAppChurrasco.Areas.Identity.Data;
using WebAppChurrasco.Entities;

namespace WebAppChurrasco.Interfaces
{
    public interface IAgendaChurrasRepository
    {
        IList<AgendaChurras> AgendaChurras(int Id);

    }
}
