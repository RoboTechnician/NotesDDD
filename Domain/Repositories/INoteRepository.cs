using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repositories
{
    public interface INoteRepository
    {
        Task<Note> GetNote(int noteId);
        Task<List<Note>> GetNotes(string userId, string subStr = null);
        Task<bool> AddNote(Note note);
        Task<bool> DeleteNote(int id);
    }
}
