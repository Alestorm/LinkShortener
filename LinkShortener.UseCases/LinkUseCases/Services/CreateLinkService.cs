using LinkShortener.DTOS.LinkDtos;
using LinkShortener.Entities;
using LinkShortener.Entities.Constants;
using LinkShortener.Entities.Entities;
using LinkShortener.Entities.Interfaces.LinkContracts;
using LinkShortener.UseCases.LinkUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.UseCases.LinkUseCases.Services
{
    public class CreateLinkService : ICreateLinkService
    {
        private readonly ICreateLink _createLink;
        private readonly ICheckUniqueCode _checkUniqueCode;
        private readonly IHttpContextAccessor _httpContext;

        private Random _random = new();
        public CreateLinkService(ICreateLink createLink, ICheckUniqueCode checkUniqueCode, IHttpContextAccessor httpContext)
        {
            _createLink = createLink;
            _checkUniqueCode = checkUniqueCode;
            _httpContext = httpContext;

        }
        public async Task<Response> CreateLink(CreateLinkDto createLinkDto)
        {
            string code = GenerateUniqueCode();
            var link = new Link
            {
                Url = createLinkDto.Url,
                Code = code,
                ShortUrl = $"{_httpContext.HttpContext.Request.Scheme}://{_httpContext.HttpContext.Request.Host}/{code}",
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                IdUser = createLinkDto.IdUser
            };
            var response = await _createLink.CreateLink(link);
            var shortLink = response.Data as Link;
            response.Data = shortLink.ShortUrl;

            return response;

        }
        public string GenerateUniqueCode()
        {
            int numberOfChars = Constants.NumberCharsShortLink;
            string alphabet = Constants.Alphabet;
            char[] codeChars = new char[numberOfChars];
            while (true)
            {
                for (int i = 0; i < numberOfChars; i++)
                {
                    int randomIndex = _random.Next(alphabet.Length);
                    codeChars[i] = alphabet[randomIndex];
                }
                var code = new string(codeChars);

                if (!_checkUniqueCode.CheckCode(code))
                {
                    return code;
                }
            }
        }
    }
}
