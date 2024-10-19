#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Services;
using BLL.Models;
using BLL.Interfaces;
using BLL.DLL;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class StudentsController : Controller
    {
        // Service injections:
        private readonly IGenericService<Student, StudentModel> _studentService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public StudentsController(
			IGenericService<Student, StudentModel> studentService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _studentService = studentService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Students
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _studentService.Query().ToList();
            return View(list);
        }

        // GET: Students/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _studentService.Query().SingleOrDefault(q => q.Student.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = await _studentService.Create(student.Student);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = student.Student.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(student);
        }

        // GET: Students/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _studentService.Query().SingleOrDefault(q => q.Student.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Students/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = await _studentService.Update(student.Student);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = student.Student.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(student);
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _studentService.Query().SingleOrDefault(q => q.Student.Id == id);
            return View(item);
        }

        // POST: Students/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = await _studentService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
