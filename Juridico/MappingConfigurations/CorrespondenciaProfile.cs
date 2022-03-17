using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Juridico.Models;
using Juridico.ViewModels;

namespace Juridico.MappingConfigurations
{
    public class CorrespondenciaProfile : Profile
    {
        public CorrespondenciaProfile()
        {
            CreateMap<Correspondencia, CorrespondenciaViewModel>()
                .ReverseMap();
                //.ForPath(x => x.HistoricoEstados, x => x.Ignore()); 
        }

    }
}
