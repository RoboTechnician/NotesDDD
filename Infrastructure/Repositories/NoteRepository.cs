using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories;
using Infrastructure.Context;
using Domain.Models;

namespace Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        NotesDBContext _context;

        public NoteRepository(NotesDBContext context)
        {
            _context = context;
        }

        public async Task<Note> GetNote(int noteId)
        {
            return await _context.Notes.Include(Note => Note.User).SingleAsync(n => n.Id == noteId);
        }

        public async Task<List<Note>> GetNotes(string userId, string subStr = null)
        {
            if (subStr == null || subStr == "")
                return await _context.Notes.Where(n => n.User.Id == userId).ToListAsync();
            return await _context.Notes.Where(n => n.User.Id == userId &&
            (n.Text.ToLower().Contains(subStr.ToLower()) || n.Title.ToLower().Contains(subStr.ToLower()))).ToListAsync();
        }

        public async Task<bool> AddNote(Note note)
        {
            _context.Notes.Add(note);
            return await _context.SaveChangesAsync() != 0;
        }

        public async Task<bool> DeleteNote(int id)
        {
            _context.Notes.Remove(_context.Notes.Find(id));
            return await _context.SaveChangesAsync() != 0;
        }
    }
}
