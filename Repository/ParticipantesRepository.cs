using System;
using System.Collections.Generic;
using WebAppChurrasco.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebAppChurrasco.Areas.Identity.Data;
using System.Data.SqlClient;
using WebAppChurrasco.Entities;
using WebAppChurrasco.Interfaces;

namespace WebAppChurrasco.Repository
{
    public class ParticipantesRepository: IParticipantesRepository
    {
        private readonly WebAppChurrascoContext _contexto;

        public ParticipantesRepository(WebAppChurrascoContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<Participantes> AdicionarParticipantesChurras(Participantes participantes)
        {
			try
			{
                _contexto.Participantes.Add(participantes);
                await _contexto.SaveChangesAsync();

                return participantes;

            }
			catch (Exception)
			{
                
				throw;
			}
        }

        public IList<Participantes> ListParticipantesChurras(int? Id)
        {
            try
            {
                return _contexto.Participantes.Where(x => x.IdChurras == Id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<Participantes> GetParticipantes(int? Id)
        {
            try
            {
                return _contexto.Participantes.Where(x => x.IdParticipantes == Id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<WebAppChurrascoUser> GetUsers()
        {
            try
            {                
                return _contexto.Users.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }        

        public bool RemoverParticipantesChurras(Participantes participantes)
        {
            try
            {
                _contexto.Participantes.Update(participantes);
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}
