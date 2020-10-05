using Microsoft.AspNetCore.Mvc;
using slambot.Common.Configuration;
using slambot.Services;
using System;
using System.Threading.Tasks;

namespace slambot.Api.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
        }

        /*
         * all action history             - GET api/admin/###
         * all player action history      - GET api/admin/players/###
         * specific player action history - GET api/admin/player/id/#/###
         * all match action history       - GET api/admin/matches/###
         * specific match action  history - GET api/admin/match/id/#/###
         */

        [HttpGet]
        [Route("{results:int?}")]
        public async Task<IActionResult> All([FromRoute] int results = AdminConfiguration.DefaultRecordsToShow)
        {
            try
            {
                return Ok(await _adminRepository.HistoryAsync(results));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("players/{results:int?}")]
        public async Task<IActionResult> Players([FromRoute] int results = AdminConfiguration.DefaultRecordsToShow)
        {
            try
            {
                return Ok(await _adminRepository.PlayerHistoryAsync(results, -1));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("player/id/{id:int}/{results:int?}")]
        public async Task<IActionResult> Player([FromRoute] int id, [FromRoute] int results = AdminConfiguration.DefaultRecordsToShow)
        {
            try
            {
                return Ok(await _adminRepository.PlayerHistoryAsync(results, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("matches/{results:int?}")]
        public async Task<IActionResult> Matches([FromRoute] int results = AdminConfiguration.DefaultRecordsToShow)
        {
            try
            {
                return Ok(await _adminRepository.MatchHistoryAsync(results, -1));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("match/id/{id:int}/{results:int?}")]
        public async Task<IActionResult> Match([FromRoute] int id, [FromRoute] int results = AdminConfiguration.DefaultRecordsToShow)
        {
            try
            {
                return Ok(await _adminRepository.MatchHistoryAsync(results, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
