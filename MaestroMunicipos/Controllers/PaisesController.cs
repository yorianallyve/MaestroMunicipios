using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MaestroMunicipos.Dtos;
using MaestroMunicipos.Logic;
using MaestroMunicipos.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MaestroMunicipos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public PaisesController(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        #region Get Paises All 
        [HttpGet("[action]")]
        public List<PaisBE> GetPaisAll()
        {
            List<PaisBE> lstpais = new List<PaisBE>();
            PaisLogic PL = new PaisLogic(_userManager, _mapper, _appDbContext);
            lstpais = PL.GetPaisAll();
            return lstpais;
        }
        #endregion
    }
}