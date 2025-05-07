namespace AppWebToDoList.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public string Estatus { get; set; }

        public DateTime FechaLimite { get; set; }

    }
}
