using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Models;

namespace SistemaWebEmpleado.Data
{
    public class DBWebEmpleadoContext:DbContext
    {
        public DBWebEmpleadoContext(DbContextOptions<DBWebEmpleadoContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
