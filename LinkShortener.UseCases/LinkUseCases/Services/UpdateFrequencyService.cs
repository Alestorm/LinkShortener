using LinkShortener.Entities;
using LinkShortener.Entities.Interfaces.LinkContracts;
using LinkShortener.UseCases.LinkUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.UseCases.LinkUseCases.Services
{
    public class UpdateFrequencyService : IUpdateFrequencyService
    {
        private readonly IUpdateFrequency _updateFrequency;
        public UpdateFrequencyService(IUpdateFrequency updateFrequency)
        {
            _updateFrequency = updateFrequency;
        }
        public async Task<Response> UpdateFrequency(string code)
        {
            return await _updateFrequency.UpdateFrequency(code);
        }
    }
}
