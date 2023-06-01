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
    public class AgendaChurrasRepository: IAgendaChurrasRepository
    {
        private readonly WebAppChurrascoContext _contexto;

        public AgendaChurrasRepository(WebAppChurrascoContext contexto)
        {
            _contexto = contexto;
        }        

        public IList<AgendaChurras> AgendaChurras(int Id)
        {
            try
            {
                using (_contexto)
                {
                    var _listaAgendaChurras = _contexto.AgendaChurras.FromSql($"sp_AgendaChurras {Id} ").ToList();
                    return _listaAgendaChurras;
                }                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
