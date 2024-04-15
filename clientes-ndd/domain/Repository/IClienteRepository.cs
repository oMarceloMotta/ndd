using System;
using System.Threading.Tasks;
using domain.Repository.common;
using domain.Entity;

namespace domain.Repository
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<bool> IsClienteCPFUnique(string cpf);
    }

}
