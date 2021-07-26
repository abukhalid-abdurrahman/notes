using System.Collections.Generic;
using System.Threading.Tasks;
using notes.Domains;

namespace notes.Services.NotesService
{
    public interface INotesService
    {
        Task<Note> CreateNote(Note noteEntity);
        Task<Note> UpdateNote(Note noteEntity);
        Task<Note> DeleteNote(int noteId);
        Task<IEnumerable<Note>> GetNotes();
    }
}