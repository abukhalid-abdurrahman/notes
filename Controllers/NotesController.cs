using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using notes.Domains;
using notes.Services.NotesService;

namespace notes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;

        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpPost]
        public async Task<Note> CreateNote(Note entity)
        {
            return await _notesService.CreateNote(entity);
        }
        
        
        [HttpPut]
        public async Task<Note> UpdateNote(Note entity)
        {
            return await _notesService.UpdateNote(entity);
        }
        
        
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Note>> GetAll()
        {
            return await _notesService.GetNotes();
        }
    }
}