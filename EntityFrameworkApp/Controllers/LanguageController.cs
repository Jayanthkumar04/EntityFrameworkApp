﻿using EntityFrameworkApp.Data;
using EntityFrameworkApp.Interfaces;
using EntityFrameworkApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApp.Controllers
{
    [Route("api/Language")]
    [ApiController]
    public class LanguageController:ControllerBase
    {
        private ILanguagesRepository _repo;
        private ApplicationDbContext _context;

        public LanguageController(ILanguagesRepository repo,ApplicationDbContext context)
        {
            _context = context;
            _repo = repo;
            
        }

        [HttpPost("AddLanguage")]
        public async Task<IActionResult> AddLanguage([FromBody] Language language)
        {

            _repo.AddLanguage(language);
            return Ok(language);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllLanguages()
        {
            var result = await _repo.GetAllLanguages();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLanguageById([FromRoute] int id)
        {

            var result = await _repo.GetLanguageById(id);

            return Ok(result);
        }

        //[HttpGet("{name}")]
        //public async Task<IActionResult> GetLanguageByName([FromRoute] string name)
        //{
        //    var result = await _context.Languages.FirstOrDefaultAsync(x => x.Title == name);

        //    return Ok(result);
        //}

        //[HttpGet("{name}")]
        //public async Task<IActionResult> GetLanguageByName([FromRoute] string name, [FromQuery] string? description)
        //{
        //    var result = await _context.Languages.FirstOrDefaultAsync(x => x.Title == name
        //                                                             &&
        //                                                             (string.IsNullOrEmpty(description) || x.Description == description)
        //    );

        //    return Ok(result);
        //}

        [HttpGet("{name}")]
        public async Task<IActionResult> GetLanguageByName([FromRoute] string name, [FromQuery] string? description)
        {
            //var result = await _context.Languages.Where(x => x.Title == name
            //                                                         &&
            //                                                         (string.IsNullOrEmpty(description) || x.Description == description)
            //).ToListAsync();

            var result = await _repo.GetLanguageByName(name, description);
            return Ok(result);
        }

        [HttpPost("All")]
        public async Task<IActionResult> GetLanguagesByIds([FromBody] List<int> ids)
        {
            var result = await _context.Languages.Where(x => ids.Contains(x.Id)).ToListAsync();

            return Ok(result);

        }

        [HttpGet("GettingLanguagesAgain")]
        public async Task<IActionResult> GetAllLanguagesAgain()
        {
            var result = await _context.Languages
                           .Select(x => new
                           {
                               Id = x.Id,
                               Title = x.Title,
                           }).ToListAsync();

            return Ok(result);
        }

        [HttpDelete("delete{id}")]
        public async Task<IActionResult> DeleteLanguage([FromRoute] int id)
        {
            var result = await _repo.DeleteLanguage(id);
            if(result != null)
            return Ok(result);


        }


    }
}
