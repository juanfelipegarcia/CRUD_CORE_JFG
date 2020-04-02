using CRUD_CORE_JFG.Clases;
using System;
using CRUD_CORE_JFG.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_CORE_JFG.Models.Abstract
{
    public interface IEmpleadoBusiness
    {
        Task<IEnumerable<EmpleadoDetalle>> obtenerEmpleadosTodos();
        Task guardarEmpleado(Empleado empleado);
        Task eliminarEmpleado(Empleado empleado);
        Task<Empleado> obtenerEmpleadoPorID(int? id);
        Task<List<CargoEmpleado>> obtenerCargoTodos();
        Task<IEnumerable<EmpleadoDetalle>> obtenerEmpleadosPorNombrePorId(string busqueda);


    }

}
