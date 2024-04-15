using System;

using System.Threading.Tasks;
using domain.Entity;
using domain.Repository;
using infrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Persistence.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ClienteDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsClienteCPFUnique(string cpf)
        {
            return await _context.Cliente.AnyAsync(p => p.CPF == cpf) == false;
        }
    }
}
