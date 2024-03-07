using LinkShortener.Entities;
using LinkShortener.Entities.Entities;
using LinkShortener.Entities.Interfaces.UserContracts;
using LinkShortener.Mappers.LinkMappers;
using LinkShortener.UseCases.UserUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.UseCases.UserUseCases.Services
{
    public class GetLinksService : IGetLinksService
    {
        private readonly IGetLinks _getLinks;
        public GetLinksService(IGetLinks getLinks)
        {
            _getLinks = getLinks;
        }
        public async Task<Response> GetLinks(int idUser)
        {
            var response = await _getLinks.GetLinks(idUser);
            if (response.Status == 200)
            {
                var user = response.Data as User;
                var userLinks = user!.LinkList;
                response.Data = userLinks.Select(l => LinkMapper.DbToLinkDto(l)).ToList();
            }
            return response;
        }
    }
}
