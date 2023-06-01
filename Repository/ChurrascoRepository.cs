using System;
using System.Collections.Generic;
using WebAppChurrasco.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebAppChurrasco.Entities;
using WebAppChurrasco.Interfaces;

namespace WebAppChurrasco.Repository
{
    public class ChurrascoRepository: IChurrascoRepository
    {
        private readonly WebAppChurrascoContext _contexto;

        public ChurrascoRepository(WebAppChurrascoContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<Churrasco> NovoChurrasco(Churrasco churrasco)
        {
			try
			{
                _contexto.Churrasco.Add(churrasco);
                await _contexto.SaveChangesAsync();
                return churrasco;

            }
			catch (Exception)
			{
                
				throw;
			}
        }

        public IEnumerable<Churrasco> ListChurrasco()
        {
            try
            {
                IEnumerable<Churrasco> _listChurrasco = _contexto.Churrasco.ToList() as IEnumerable<Churrasco>;
                return _listChurrasco;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Churrasco GetChurrascosById(int? id)
        {
            try
            {
                return _contexto.Churrasco.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
