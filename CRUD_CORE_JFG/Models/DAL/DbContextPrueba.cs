﻿
using CRUD_CORE_JFG.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_CORE_JFG.Models.DAL
{
    public class DbContextPrueba : DbContext
    {
        public DbContextPrueba(DbContextOptions<DbContextPrueba> options) : base(options)
        {

        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<CargoEmpleado> CargoEmpleados { get; set; }
    }
}
