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
    public class PaisLogic
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public PaisLogic(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }


        #region Get all Municipio
        public List<PaisBE> GetPaisAll()
        {
            List<PaisBE> lstpais = new List<PaisBE>();

            try
            {
                lstpais = (from Pais in _appDbContext.Pais

                           select new PaisBE
                           {
                               PaisId = Pais.PaisId,
                               Nombre = Pais.Nombre,
                           }).OrderBy(x => x.Nombre).ToList();
            }
            catch (Exception EX)
            {

            }
            finally
            {
                _appDbContext.Dispose();
            }

            return lstpais;
        }
        #endregion
    }
}
