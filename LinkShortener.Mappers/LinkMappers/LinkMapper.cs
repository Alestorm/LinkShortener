using LinkShortener.DTOS.LinkDtos;
using LinkShortener.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Mappers.LinkMappers
{
    public static class LinkMapper
    {
        public static LinkDto DbToLinkDto(Link link)
        {
            return new LinkDto
            {
                IdLink = link.IdLink,
                Url = link.Url,
                ShortUrl = link.ShortUrl,
                Code = link.Code,
                Frequency = link.Frequency,
                CreationDate = link.CreationDate,
                ModificationDate = link.ModificationDate,
                IdUser = link.IdUser
            };
        }
    }
}
