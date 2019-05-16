using AutoMapper;
using MaestroMunicipos.Dtos;
using MaestroMunicipos.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaestroMunicipos.Logic
{
    public class DepartamentoLogic
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public DepartamentoLogic(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        #region Get all Departamentos
        public List<DepartamentoBE> GetDepartamentoAll()
        {
            List<DepartamentoBE> lstdepto = new List<DepartamentoBE>();

            try
            {
                lstdepto = (from Departamento in _appDbContext.Departamento

                            select new DepartamentoBE
                            {
                                DepartamentoId = Departamento.DepartamentoId,
                                Nombre = Departamento.Nombre,
                                PaisId = Departamento.PaisId,
                                NombrePais = Departamento.Pais.Nombre,
                            }).OrderBy(x => x.Nombre).ThenBy(x => x.NombrePais).ToList();
            }
            catch (Exception EX)
            {

            }
            finally
            {
                _appDbContext.Dispose();
            }

            return lstdepto;
        }
        #endregion


        #region Search Departamento for PaisId
        public List<DepartamentoBE> SearchDepartamentoByPaisId(int SEARIDPAIS)
        {
            List<DepartamentoBE> Departamento = new List<DepartamentoBE>();
            try
            {
                Departamento = (from departamento in _appDbContext.Departamento
                               where departamento.PaisId == SEARIDPAIS
                               select new DepartamentoBE
                               {
                                   DepartamentoId = departamento.DepartamentoId,
                                   Nombre = departamento.Nombre,
                                   PaisId = departamento.PaisId,
                                   NombrePais = departamento.Pais.Nombre,
                               }).ToList();
            }
            catch (Exception EX)
            {

            }
            finally
            {
                _appDbContext.Dispose();
            }

            return Departamento;
        }

        #endregion
    }
}
