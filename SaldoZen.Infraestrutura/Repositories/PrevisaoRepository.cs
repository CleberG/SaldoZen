using Microsoft.EntityFrameworkCore;
using SaldoZen.Domain.Interfaces;
using SaldoZen.Domain.Model;
using SaldoZen.Infraestrutura.Context;
using SaldoZen.Infraestrutura.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaldoZen.Infraestrutura.Repositories
{
    public class PrevisaoRepository : RepositoryBase<Previsao>, IPrevisaoRepository
    {
        public PrevisaoRepository(SaldoZenContext context) : base(context)
        {
        }

        public async Task<Previsao> GetByIdWithIncludesAsync(int id)
        {
            return await ListBy(p => p.Id == id)
                .Include(p => p.Categoria)
                .Include(p => p.Baixas)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Previsao>> GetAllWithIncludesAsync()
        {
            return await _context.Set<Previsao>()
                .Include(p => p.Categoria)
                .Include(p => p.Baixas)
                .ToListAsync();
        }
    }
}



