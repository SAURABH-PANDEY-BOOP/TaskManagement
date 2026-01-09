using Microsoft.AspNetCore.Mvc;
using ModelLayer.TaskManagment;
using Repository.ITaskManagment;

namespace TaskManagement.Controllers
{
        public class TaskController : Controller
        {
            private readonly ITaskRepository _repo;

            public TaskController(ITaskRepository repo)
            {
                _repo = repo;
            }

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _repo.GetAllRecord());
        //}
        public async Task<IActionResult> Index(string searchText, int pageNumber = 1, int pageSize = 5)
        {
            ViewData["CurrentFilter"] = searchText;

            var allTasks = string.IsNullOrEmpty(searchText)
                ? await _repo.GetAllRecord()
                : await _repo.SearchTaskManagment(searchText);

            int totalRecords = allTasks.Count;
            int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var tasksPage = allTasks
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewData["PageNumber"] = pageNumber;
            ViewData["TotalPages"] = totalPages;
            ViewData["TotalRecords"] = totalRecords;
            ViewData["CurrentFilter"] = searchText;

            return View(tasksPage);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.CreatedById = 1;
            model.CreatedByName = "Admin";

            await _repo.CreateTaskManagment(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
            {
                return View(await _repo.GetByIdTask(id));
            }

            [HttpPost]
            public async Task<IActionResult> Edit(TaskModel model)
            {
                model.UpdatedById = 1;
                model.UpdatedByName = "Admin";

                await _repo.UpdateTaskManagment(model);
                return RedirectToAction(nameof(Index));
            }

            public async Task<IActionResult> Delete(int id)
            {
                await _repo.DeleteTaskManagment(id);
                return RedirectToAction(nameof(Index));
            }

            public async Task<IActionResult> Search(string searchText)
            {
                return View("Index", await _repo.SearchTaskManagment(searchText));
            }
        }

    }

