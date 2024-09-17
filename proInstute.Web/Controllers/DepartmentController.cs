
using Microsoft.AspNetCore.Mvc;
using proInstute.Domian.Entities;
using proInstute.Persistence.Interfaces;
using proInstute.Persistence.Models.Department;
using proInstute.Web.Models.Department;

namespace proInstute.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;

        #region "Acciones"
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this.departmentRepository.GetDepartments();

            return View(result);

        }


        public async Task<IActionResult> Details(int id)
        {
            DepartmentModel model;

            model = await GetDepartmentInfo(id);

            if (model is null)
            {
                return View();
            }

            return View(model);
        }



        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentSaveDto saveDto)
        {
            try
            {
                saveDto.ChangeDate = DateTime.Now;
                saveDto.ChangeUser = 1;

                Department department = new Department()
                {
                 
                    Budget = saveDto.Budget,
                    Name = saveDto.Name,
                    CreationDate = saveDto.ChangeDate,
                    CreationUser = saveDto.ChangeUser,
                    StartDate = saveDto.StartDate,
                    Administrator = saveDto.Administrator
                };

                var result = await this.departmentRepository.Save(department);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Error creando el departamento";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {

            DepartmentModel model = await GetDepartmentInfo(id);

            if (model is null)
            {
                return View();
            }


            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartmentUpdateDto updateDto)
        {
            try
            {
                updateDto.ChangeDate = DateTime.Now;
                updateDto.ChangeUser = 1;

                Department department = new Department()
                {
                    Id = updateDto.DepartmentId,
                    Budget = updateDto.Budget,
                    Name = updateDto.Name,
                    ModifyDate = updateDto.ChangeDate,
                    UserMod = updateDto.ChangeUser,
                    StartDate = updateDto.StartDate,
                    Administrator = updateDto.Administrator
                };

                var result = await this.departmentRepository.Update(department);
               
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Error modificando el departamento";
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }
        #endregion 

        #region"Metodos privados"
        private async Task<DepartmentModel> GetDepartmentInfo(int id)
        {

            DepartmentModel model = new DepartmentModel();

            var department = await this.departmentRepository.GetEntityBy(id);


            model = new DepartmentModel()
            {
                DepartmentId = department.Id,
                Budget = department.Budget,
                Name = department.Name,
                StartDate = DateTime.Now,
            };

            return model;
        }

        #endregion
    }
}
