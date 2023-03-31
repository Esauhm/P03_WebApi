using System.ComponentModel.DataAnnotations;

namespace P03_WebApi.Models
{
    public class EstadosEquipos
    {
        [Key]
        public int id_estados_equipo { get; set; }

        public string? descripcion { get; set; }

        public string? estado { get; set; }
    }
}
