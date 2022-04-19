using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Application.Dto;
using WebMotors.Domain;

namespace WebMotors.Application.Contract
{
    public interface IAnuncioService
    {
        Task<Anuncio> GetAnuncio(string temna);
        Task<AnuncioDto> AddAnuncio(AnuncioDto model);
        Task<bool> UpdateAnuncio(int id, AnuncioDto model);
        Task<bool> DeleteAnuncio(int id);
    }
}
