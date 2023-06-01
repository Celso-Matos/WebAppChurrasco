using System.Collections.Generic;
using WebAppChurrasco.Entities;

namespace WebAppChurrasco.Interfaces
{
    public interface IChurrascoRepository
    {
        Task<Churrasco> NovoChurrasco(Churrasco churrasco);

        IEnumerable<Churrasco> ListChurrasco();

        Churrasco GetChurrascosById(int? id);

    }
}
