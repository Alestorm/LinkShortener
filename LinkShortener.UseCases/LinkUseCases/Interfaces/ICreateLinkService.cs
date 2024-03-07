using LinkShortener.DTOS.LinkDtos;
using LinkShortener.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.UseCases.LinkUseCases.Interfaces
{
    public interface ICreateLinkService
    {
        Task<Response> CreateLink(CreateLinkDto createLinkDto);
    }
}
