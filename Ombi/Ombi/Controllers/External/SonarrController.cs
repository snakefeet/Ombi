﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ombi.Api.Sonarr;
using Ombi.Api.Sonarr.Models;
using Ombi.Attributes;
using Ombi.Core.Settings;
using Ombi.Core.Settings.Models.External;

namespace Ombi.Controllers.External
{
   [Admin]
    public class SonarrController : BaseV1ApiController
    {
        public SonarrController(ISonarrApi sonarr, ISettingsService<SonarrSettings> settings)
        {
            SonarrApi = sonarr;
            SonarrSettings = settings;
        }

        private ISonarrApi SonarrApi { get; }
        private ISettingsService<SonarrSettings> SonarrSettings { get; }

        [HttpPost("Profiles")]
        public async Task<IEnumerable<SonarrProfile>> GetProfiles([FromBody] SonarrSettings settings)
        {
            return await SonarrApi.GetProfiles(settings.ApiKey, settings.FullUri);
        }

        [HttpPost("RootFolders")]
        public async Task<IEnumerable<SonarrRootFolder>> GetRootFolders([FromBody] SonarrSettings settings)
        {
            return await SonarrApi.GetRootFolders(settings.ApiKey, settings.FullUri);
        }
    }
}