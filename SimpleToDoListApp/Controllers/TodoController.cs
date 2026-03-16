using Microsoft.AspNetCore.Mvc;
using SimpleToDoListApp.Models;

namespace SimpleToDoListApp.Controllers
{
    public class TodoController : Controller
    {
        private static List<TodoItem> todos = new List<TodoItem>();
        public IActionResult Index()
        {
            return View(todos);
        }

        [HttpPost]
        public IActionResult Add(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                todos.Add(new TodoItem { Id = todos.Count + 1, Title = title, IsDone = false });
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Toggle(int id)
        {
            var item = todos.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.IsDone = !item.IsDone;
            }
            return RedirectToAction("Index");
        }
    }
}
