using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model.Models
{
    public class ResultadoApi
    {
        public string mensaje { get; set; }
        public List<Tarea> tarea { get; set; }
        public Tarea objeto { get; set; }
    }
}
