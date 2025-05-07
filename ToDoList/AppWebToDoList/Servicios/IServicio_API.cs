using AppWebToDoList.Models;

namespace AppWebToDoList.Servicios
{
    public interface IServicio_API
    {
        Task<List<Tarea>> Lista();
        Task<Tarea> Obtener(int id);

        Task<bool> Guardar(Tarea objeto);

        Task<bool> Editar(Tarea objeto);

        Task<bool> Eliminar(int Tarea);
    }
}
