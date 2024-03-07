using LinkShortener.DTOS.LinkDtos;
using LinkShortener.Entities;
using LinkShortener.Entities.Constants;
using LinkShortener.Entities.Errors;
using LinkShortener.UseCases.LinkUseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LinkController : ControllerBase
    {
        private readonly ICreateLinkService _createLinkService;
        private readonly IGetShortUrlService _getShortUrlService;
        private readonly IUpdateFrequencyService _updateFrequencyService;
        private readonly IGetLinkInfoService _getLinkInfoService;
        public LinkController(ICreateLinkService createLinkService, IGetShortUrlService getShortUrlService, IUpdateFrequencyService updateFrequencyService, IGetLinkInfoService getLinkInfoService)
        {
            _createLinkService = createLinkService;
            _getShortUrlService = getShortUrlService;
            _updateFrequencyService = updateFrequencyService;
            _getLinkInfoService = getLinkInfoService;
        }
        [HttpPost]
        [Route("createLink")]
        public async Task<Response> CreateLink([FromBody] CreateLinkDto createLinkDto)
        {
            if (!Uri.TryCreate(createLinkDto.Url, UriKind.Absolute, out _))
            {
                return ResponseFactory.CreateResponse(400, HttpCodes.ResponseMap[400], error: LinkErrors.NotUrlFormat);
            }
            return await _createLinkService.CreateLink(createLinkDto);
        }
        [HttpGet]
        [Route("/{code}")]
        public async Task<IActionResult> RedirectToUrl(string code)
        {
            var response = await _getShortUrlService.GetShortUrl(code);
            if (response.Status != 200)
            {
                return NotFound();
            }
            var link = response.Data as LinkDto;
            await _updateFrequencyService.UpdateFrequency(code);
            return Redirect(link!.Url);
        }

        [HttpPost]
        [Route("linkinfo")]
        public async Task<Response> GetLinkInfo([FromBody] string shorturl)
        {
            if (!Uri.TryCreate(shorturl, UriKind.Absolute, out _))
            {
                return ResponseFactory.CreateResponse(400, HttpCodes.ResponseMap[400], error: LinkErrors.NotUrlFormat);
            }
            return await _getLinkInfoService.GetLinkInfo(shorturl);
        }
    }
}
