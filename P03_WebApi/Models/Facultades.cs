using System.ComponentModel.DataAnnotations;

namespace P03_WebApi.Models
{
    public class Facultades
    {

        [Key]
        public int facultad_id { get; set; }

        public string? nombre_facultad { get; set; }

    }
}
