using Microsoft.EntityFrameworkCore;


namespace P03_WebApi.Models
{
    public class EquiposContext : DbContext
    {
        public EquiposContext(DbContextOptions<EquiposContext> options) : base(options)
        {
        }

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<TipoEquipos> tipo_equipo { get; set; }
        public DbSet<EstadosEquipos> estados_equipo { get; set; }
        public DbSet<EstadosReserva> estados_reserva { get; set; }
        public DbSet<Carreras> carreras { get; set; }
        public DbSet<Facultades> facultades { get; set; }
        public DbSet<Reserva> reservas { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
    }
}
