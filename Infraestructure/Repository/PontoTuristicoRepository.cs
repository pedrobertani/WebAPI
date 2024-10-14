using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Repository
{
    public class PontoTuristicoRepository : IPontoTuristicoRepository
    {
        private readonly TurismoContext _context;

        public PontoTuristicoRepository(TurismoContext context)
        {
            _context = context;
        }

        public async Task<List<PontoTuristico>> GetAllAsync()
        {
            return await _context.PontoTuristico.ToListAsync();
        }

        public async Task<PontoTuristico> GetByIdAsync(int id)
        {
            return await _context.PontoTuristico.FindAsync(id);
        }

        public async Task AddAsync(PontoTuristico touristSpot)
        {
            // Inicia uma nova transação
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Adiciona o ponto turístico ao contexto
                await _context.PontoTuristico.AddAsync(touristSpot);

                // Salva as alterações no banco de dados
                await _context.SaveChangesAsync();

                // Confirma a transação
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                // Caso ocorra um erro, reverte a transação
                await transaction.RollbackAsync();
                // Opcional: você pode registrar o erro ou lançá-lo novamente
                throw new Exception("Erro ao adicionar ponto turístico", ex);
            }
        }

    }
}
