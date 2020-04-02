using CRUD_CORE_JFG.Clases;
using CRUD_CORE_JFG.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_CORE_JFG.Models.Abstract
{
    public interface ICargoEmpleadoBusiness
    {
        Task<IEnumerable<CargoEmpleadoDetalle>> obtenerCargoEmpleadosTodos();
        Task guardarCargoEmpleado(CargoEmpleado cargoEmpleado);
        Task eliminarCargoEmpleado(CargoEmpleado cargoEmpleadoo);
        Task<CargoEmpleado> obtenerCargoEmpleadoPorID(int? id);
        Task<List<CargoEmpleado>> obtenerCargoTodos();
        Task<IEnumerable<CargoEmpleadoDetalle>> obtenerCargosPorNombrePorId(string busqueda);


    }
}
