using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Application.Dto;
using WebMotors.Domain;

namespace WebMotors.Application.Helpers
{
    public class WebMotorsProfile : Profile
    {
        public WebMotorsProfile()
        {
            CreateMap<Anuncio, AnuncioDto>().ReverseMap();
        }
    }
}
