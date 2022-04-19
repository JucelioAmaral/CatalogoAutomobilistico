using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Application.Contract;
using WebMotors.Application.Dto;
using WebMotors.Domain;
using WebMotors.Infrastructure.Contract;

namespace WebMotors.Application
{
    public class AnuncioService : IAnuncioService
    {
        private readonly IAnuncioRepo _anuncioRepo;
        private readonly IMapper _mapper;

        public AnuncioService(IAnuncioRepo anuncioRepo, IMapper mapper)
        {
            _mapper = mapper;
            _anuncioRepo = anuncioRepo;
        }

        public async Task<Anuncio> GetAnuncio(string tema)
        {
            try
            {
                var anuncio = await _anuncioRepo.SelectAnuncio(tema);
                if (anuncio == null) return null;

                return anuncio;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AnuncioDto> AddAnuncio(AnuncioDto model)
        {
            try
            {
                var anuncio = _mapper.Map<Anuncio>(model);
                var anuncioAdded = await _anuncioRepo.InsertAnuncio(anuncio);
                if (anuncioAdded == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<AnuncioDto>(anuncio);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task<bool> UpdateAnuncio(int id, AnuncioDto model)
        {
            try
            {
                var anuncio = await _anuncioRepo.SelectAnuncioById(id);
                if (anuncio != null)
                {
                    var anuncioUpdate = _mapper.Map<Anuncio>(model);
                    if (await _anuncioRepo.UpdateAnuncio(id, anuncioUpdate) > 0) return true;
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAnuncio(int id)
        {
            try
            {
                var anuncio = await _anuncioRepo.SelectAnuncioById(id);
                if (anuncio != null)
                {                    
                    if (await _anuncioRepo.DeleteAnuncio(id) > 0) return true;
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
