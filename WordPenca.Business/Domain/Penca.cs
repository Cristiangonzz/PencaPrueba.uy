using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPenca.Business.Models
{
    public class Penca
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Ingrese un Nombre")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Fecha de Inicio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly FechaInicio { get; set; }
        [Display(Name = "Fecha de Finalizacion")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly FechaFin { get; set; }
        public Decimal Comision { get; set; }
    }
}
