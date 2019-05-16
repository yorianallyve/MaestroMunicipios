using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MaestroMunicipos.Dtos;
using MaestroMunicipos.Logic;
using MaestroMunicipos.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MaestroMunicipos.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartamentosController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public DepartamentosController(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        #region Get Departamentos All 
        [HttpGet("[action]")]
        public List<DepartamentoBE> GetDepartamentoAll()
        {
            List<DepartamentoBE> lstdepto = new List<DepartamentoBE>();
            DepartamentoLogic DL = new DepartamentoLogic(_userManager, _mapper, _appDbContext);
            lstdepto = DL.GetDepartamentoAll();
            return lstdepto;
        }
        #endregion


        #region  SearchDepartamentoByPaisId All 
        [HttpGet("[action]/{SEARIDPAIS}")]
        public List<DepartamentoBE> SearchDepartamentoByPaisId(int SEARIDPAIS)
        {
            List<DepartamentoBE> lstdepto = new List<DepartamentoBE>();
            DepartamentoLogic DL = new DepartamentoLogic(_userManager, _mapper, _appDbContext);
            lstdepto = DL.SearchDepartamentoByPaisId(SEARIDPAIS);
            return lstdepto;
        }
        #endregion
    }
}