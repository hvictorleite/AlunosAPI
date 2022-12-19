﻿using AlunosAPI.Context;
using AlunosAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosAPI.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly AppDbContext _context;

        public AlunoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            try
            {
                return await _context.Alunos.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        
        public async Task<Aluno> GetAlunoById(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            return aluno;
        }

        public async Task<IEnumerable<Aluno>> GetAlunosByNome(string nome)
        {
            IEnumerable<Aluno> alunos;
            if (!string.IsNullOrEmpty(nome))
                alunos = await _context.Alunos.Where(aluno => aluno.Nome.Contains(nome)).ToListAsync();
            else
                alunos = await GetAlunos();

            return alunos;
        }

        public async Task CreateAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAluno(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAluno(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }
}
