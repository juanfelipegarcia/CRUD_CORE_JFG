using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_CORE_JFG.Models.DAL;
using CRUD_CORE_JFG.Models.Entities;
using CRUD_CORE_JFG.Models.Abstract;

namespace CRUD_CORE_JFG.Controllers
{
    public class CargoEmpleadosController : Controller
    {
        private readonly ICargoEmpleadoBusiness _context;
        private CargoEmpleado cargoEmpleado;

        public CargoEmpleadosController(ICargoEmpleadoBusiness context)
        {
            _context = context;
        }

        // GET: CargoEmpleados
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.obtenerCargoEmpleadosTodos());
        //}

        public async Task<IActionResult> Index(string busqueda)
        {
            if (!string.IsNullOrEmpty(busqueda))
                return View(await _context.obtenerCargosPorNombrePorId(busqueda));
            else
                return View(await _context.obtenerCargoEmpleadosTodos());
        }


        public async Task<IActionResult> CrearEditar(int id = 0)
        {
            if (id == 0)
                return View(new CargoEmpleado());
            else
                cargoEmpleado = await _context.obtenerCargoEmpleadoPorID(id);
            return View(cargoEmpleado);

        }

        [HttpPost]
        public async Task<IActionResult> CrearEditar([Bind("IdCargo,Cargo")] CargoEmpleado cargoEmpleado)
        
        {

            if (ModelState.IsValid)
            {
                await _context.guardarCargoEmpleado(cargoEmpleado);

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));

        }

        // GET: Empleados/Details/5
        [HttpGet]
        public async Task<ActionResult<CargoEmpleado>> EmpleadoPorID(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.obtenerCargoEmpleadoPorID(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        public async Task<IActionResult> Eliminar(int? id)
        {

            await _context.eliminarCargoEmpleado(await _context.obtenerCargoEmpleadoPorID(id));
            return RedirectToAction(nameof(Index));
        }


    }
}
