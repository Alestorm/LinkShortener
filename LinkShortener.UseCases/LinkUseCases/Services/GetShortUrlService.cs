using LinkShortener.Entities;
using LinkShortener.Entities.Entities;
using LinkShortener.Entities.Interfaces.LinkContracts;
using LinkShortener.Mappers.LinkMappers;
using LinkShortener.UseCases.LinkUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.UseCases.LinkUseCases.Services
{
    public class GetShortUrlService : IGetShortUrlService
    {
        private readonly IGetShortUrl _getShortUrl;
        public GetShortUrlService(IGetShortUrl getShortUrl)
        {
            _getShortUrl = getShortUrl;
        }
        public async Task<Response> GetShortUrl(string code)
        {
            var response = await _getShortUrl.GetShortUrl(code);
            if(response.Data != null)
            {
                var link = response.Data as Link;
                response.Data = LinkMapper.DbToLinkDto(link);
            }
            return response;
        }
    }
}