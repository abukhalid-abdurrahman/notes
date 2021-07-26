using System.Collections.Generic;
using System.Threading.Tasks;
using notes.DataAccess;
using notes.DataAccess.Repositories.GenericRepository;
using notes.Domains;

namespace notes.Services.NotesService
{
    public class NotesService : INotesService
    {
        private readonly IGenericRepository<Note> _repository;

        public NotesService(NotesContext context)
        {
            _repository = new GenericRepository<Note>(context);    
        }
        
        public async Task<Note> CreateNote(Note noteEntity)
        {
            if (noteEntity == null)
                return null;
            if (string.IsNullOrEmpty(noteEntity.Notetext) && !noteEntity.Taskid.HasValue)
                return null;
            await _repository.CreateAsync(noteEntity);
            return noteEntity;
        }

        public async Task<Note> UpdateNote(Note noteEntity)
        {
            if (noteEntity == null)
                return null;
            if (string.IsNullOrEmpty(noteEntity.Notetext) && !noteEntity.Taskid.HasValue)
                return null;
            await _repository.UpdateAsync(noteEntity);
            return noteEntity;
        }

        public async Task<Note> DeleteNote(int noteId)
        {
            var entity = await _repository.GetAsync(x => x.Id == noteId);
            entity.Removed = true;
            await _repository.UpdateAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<Note>> GetNotes()
        {
            return await _repository.GetAllAsync(x => x.Removed == false);
        }
    }
}