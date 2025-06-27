using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TurismoCoreApp.Pages.Notes
{
    public class ViewNotesModel : PageModel
    {
        private readonly string _notesPath;

        public ViewNotesModel()
        {
            _notesPath = Path.Combine("wwwroot", "files");
            Directory.CreateDirectory(_notesPath);
        }

        [BindProperty]
        public string NoteTitle { get; set; }

        [BindProperty]
        public string NoteContent { get; set; }

        public List<string> AvailableNotes { get; set; } = new List<string>();
        public string SelectedNoteContent { get; set; }

        public void OnGet(string selectedNote = null)
        {
            LoadAvailableNotes();

            if (!string.IsNullOrEmpty(selectedNote))
            {
                LoadNoteContent(selectedNote);
            }
        }

        public async Task<IActionResult> OnPostCreateNoteAsync()
        {
            if (string.IsNullOrWhiteSpace(NoteTitle) || string.IsNullOrWhiteSpace(NoteContent))
            {
                ModelState.AddModelError("", "Título e conteúdo são obrigatórios.");
                LoadAvailableNotes();
                return Page();
            }

            var fileName = $"{NoteTitle.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            var filePath = Path.Combine(_notesPath, fileName);

            await System.IO.File.WriteAllTextAsync(filePath, NoteContent);

            TempData["Success"] = "Nota criada com sucesso!";
            return RedirectToPage();
        }

        private void LoadAvailableNotes()
        {
            if (Directory.Exists(_notesPath))
            {
                AvailableNotes = Directory.GetFiles(_notesPath, "*.txt")
                    .Select(Path.GetFileName)
                    .ToList();
            }
        }

        private void LoadNoteContent(string fileName)
        {
            var filePath = Path.Combine(_notesPath, fileName);
            if (System.IO.File.Exists(filePath))
            {
                SelectedNoteContent = System.IO.File.ReadAllText(filePath);
            }
        }
    }
}