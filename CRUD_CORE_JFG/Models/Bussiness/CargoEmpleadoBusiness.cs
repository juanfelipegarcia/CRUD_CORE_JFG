using CRUD_CORE_JFG.Clases;
using CRUD_CORE_JFG.Models.Abstract;
using CRUD_CORE_JFG.Models.DAL;
using CRUD_CORE_JFG.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_CORE_JFG.Models.Bussiness
{
    public class CargoEmpleadoBusiness: ICargoEmpleadoBusiness
    {
        private readonly DbContextPrueba _context;

        public CargoEmpleadoBusiness(DbContextPrueba context)
        {
            this._context = context;

        }

        public async Task<IEnumerable<CargoEmpleadoDetalle>> obtenerCargoEmpleadosTodos()
        {
            await using (_context)
            {
                IEnumerable<CargoEmpleadoDetalle> listaCargoEmpleadoDetalle =
                (from cargoEmpleado in _context.CargoEmpleados

                 select new CargoEmpleadoDetalle
                 {
                     IdCargo = cargoEmpleado.IdCargo,
                     Cargo = cargoEmpleado.Cargo,


                 }).ToList();
                return listaCargoEmpleadoDetalle;
            }
        }

        public async Task guardarCargoEmpleado(CargoEmpleado cargoEmpleado)
        {
            if (cargoEmpleado.IdCargo == 0)
                _context.Add(cargoEmpleado);
            else
                _context.Update(cargoEmpleado);

            await _context.SaveChangesAsync();
        }

        public async Task eliminarCargoEmpleado(CargoEmpleado cargoEmpleadoo)
        {
            if (cargoEmpleadoo != null)
            {
                _context.Remove(cargoEmpleadoo);
                await _context.SaveChangesAsync();

            }

        }

        //Devuelve un empleado
        public async Task<CargoEmpleado> obtenerCargoEmpleadoPorID(int? id)
        {
            CargoEmpleado cargoEmpleadoo;
            cargoEmpleadoo = null;

            if (id == null)
            {
                return cargoEmpleadoo;
            }
            else
            {
                cargoEmpleadoo = await _context.CargoEmpleados.FirstOrDefaultAsync(m => m.IdCargo == id);
                return cargoEmpleadoo;

            }

        }

        //Este metodo deberia tener estar en su clase Businesss
        public async Task<List<CargoEmpleado>> obtenerCargoTodos()
        {
            return await _context.CargoEmpleados.ToListAsync();
        }

        public async Task<IEnumerable<CargoEmpleadoDetalle>> obtenerCargosPorNombrePorId(string busqueda)
        {

            await using (_context)
            {
                IEnumerable<CargoEmpleadoDetalle> listaCargoEmpleadoDetalle =
                (from cargoEmpleado in _context.CargoEmpleados
                 
                 select new CargoEmpleadoDetalle
                 {
                      Cargo = cargoEmpleado.Cargo,
                    

                 }).ToList();
                return listaCargoEmpleadoDetalle;
            }
        }



    }
}
