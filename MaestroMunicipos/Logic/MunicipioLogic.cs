using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MaestroMunicipos.Dtos;
using MaestroMunicipos.Model;
using Microsoft.AspNetCore.Identity;

namespace MaestroMunicipos.Logic
{
    public class MunicipioLogic
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public MunicipioLogic(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }


        #region Insert Municipio
        public AnswerResponseBE InsertMunicipio(MunicipioBE IMUNI)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            
            try
            {
                int CountMuni = 0;
                CountMuni = _appDbContext.Municipio.Where(x => x.MunicipioId == IMUNI.MunicipioId).ToList().Count();
                if (CountMuni == 0)
                {
                    Municipio MUNICIPIO = new Municipio();
                    MUNICIPIO.MunicipioId = IMUNI.MunicipioId;
                    MUNICIPIO.Nombre = IMUNI.Nombre;
                    MUNICIPIO.DepartamentoId = IMUNI.DepartamentoId;

                    _appDbContext.Municipio.Add(MUNICIPIO);
                    _appDbContext.SaveChanges();

                    AR.CodeError = 0;
                    AR.DescriptionError = "Se ha insertado el municipio correctamente";
                }
                else
                {
                    AR.CodeError = 2;
                    AR.DescriptionError = "El producto ya existe, por favor verifique la información";
                }
            }
            catch (Exception EX)
            {
                AR.CodeError = 1;
                AR.DescriptionError = "Hubo un error";
            }
            finally
            {
                _appDbContext.Dispose();
            }
            return AR;
        }
        #endregion


        #region Update Municipio
        public AnswerResponseBE UpdateMunicipio(MunicipioBE UMUNI)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            try
            {
                Municipio municipio = new Municipio();
                municipio = _appDbContext.Municipio.Where(x => x.MunicipioId == UMUNI.MunicipioId).FirstOrDefault();
                if (municipio != null)
                {
                    municipio.MunicipioId = UMUNI.MunicipioId;
                    municipio.Nombre = UMUNI.Nombre;
                    municipio.DepartamentoId = UMUNI.DepartamentoId;

                    _appDbContext.SaveChanges();

                    AR.CodeError = 0;
                    AR.DescriptionError = "Se ha actualizado el municipio correctamente";
                }
                else
                {
                    AR.CodeError = 2;
                    AR.DescriptionError = "El registro no existe, por favor verifique la información";
                }
            }
            catch (Exception EX)
            {
                AR.CodeError = 1;
                AR.DescriptionError = "Hubo un error";
            }
            finally
            {
                _appDbContext.Dispose();
            }
            return AR;
        }
        #endregion


        #region Search Municipio for MunicipioId
        public MunicipioBE SearchMunicipioId(int SEARIDMUNI)
        {
            MunicipioBE municipioId = new MunicipioBE();
            try
            {
                municipioId = (from Municipio in _appDbContext.Municipio
                              where Municipio.MunicipioId == SEARIDMUNI
                               select new MunicipioBE
                              {
                                  MunicipioId = Municipio.MunicipioId,
                                  Nombre = Municipio.Nombre,
                                  DepartamentoId = Municipio.DepartamentoId,
                                   NombreDepto = Municipio.Departamento.Nombre,
                                   PaisId = Municipio.Departamento.PaisId,
                                   NombrePais=Municipio.Departamento.Pais.Nombre,

                               }).FirstOrDefault();
            }
            catch (Exception EX)
            {

            }
            finally
            {
                _appDbContext.Dispose();
            }

            return municipioId;
        }

        #endregion


        #region Get all Municipio
        public List<MunicipioBE> GetMunicipioAll()
        {
            List<MunicipioBE> lstmuni = new List<MunicipioBE>();

            try
            {
                lstmuni = (from Municipio in _appDbContext.Municipio

                           select new MunicipioBE
                           {
                               MunicipioId = Municipio.MunicipioId,
                               Nombre = Municipio.Nombre,
                               DepartamentoId = Municipio.DepartamentoId,
                               NombreDepto = Municipio.Departamento.Nombre,
                               PaisId = Municipio.Departamento.PaisId,
                               NombrePais = Municipio.Departamento.Pais.Nombre,
                           }).OrderBy(x => x.MunicipioId).ThenBy(x => x.DepartamentoId).ToList();
            }
            catch (Exception EX)
            {

            }
            finally
            {
                _appDbContext.Dispose();
            }

            return lstmuni;
        }
        #endregion
    }
}
