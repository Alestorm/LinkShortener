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
    public class GetLinkInfoService : IGetLinkInfoService
    {
        private readonly IGetLinkInfo _getLinkInfo;
        public GetLinkInfoService(IGetLinkInfo getLinkInfo)
        {
            _getLinkInfo = getLinkInfo;
        }
        public async Task<Response> GetLinkInfo(string shorturl)
        {
            var response = await _getLinkInfo.GetLinkInfo(shorturl);
            if (response.Data != null)
            {
                var link = response.Data as Link;
                response.Data = LinkMapper.DbToLinkDto(link!);
            }
            return response;
        }
    }
}
