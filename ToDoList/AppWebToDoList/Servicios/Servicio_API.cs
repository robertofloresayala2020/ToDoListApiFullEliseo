using AppWebToDoList.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AppWebToDoList.Servicios
{
    public class Servicio_API : IServicio_API
    {
        private static string _baseUrl;
        //private static string _usuario;
        //private static string _clave;
        //private static string _token;

        public Servicio_API() {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            //_usuario = builder.GetSection("ApiSetting:usuario").Value;
            //_clave = builder.GetSection("ApiSetting:clave").Value;
            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        //USAR REFERENCIAS 
        //public async Task Autenticar() {

        //    var cliente = new HttpClient();
        //    cliente.BaseAddress = new Uri(_baseUrl);

        //    var credenciales = new Credencial() { usuario = _usuario, clave = _clave };

        //    var content = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");
        //    var response = await cliente.PostAsync("api/Autenticacion/Validar", content);
        //    var json_respuesta = await response.Content.ReadAsStringAsync();

        //    var resultado = JsonConvert.DeserializeObject<ResultadoCredencial>(json_respuesta);
        //    _token = resultado.token;
        //}

        public async Task<List<Tarea>> Lista() {
            List<Tarea> lista = new List<Tarea>();

            //await Autenticar();


            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await cliente.GetAsync("api/Tareas/");

            if (response.IsSuccessStatusCode) {

                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Tarea[]>(json_respuesta);
                lista = resultado.ToList();
            }

            return lista;
        }

        public async Task<Tarea> Obtener(int id)
        {
            Tarea objeto = new Tarea();

            //await Autenticar();


            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await cliente.GetAsync($"api/Tareas/{id}");

            if (response.IsSuccessStatusCode)
            {

                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Tarea>(json_respuesta);
                objeto = resultado;
            }

            return objeto;
        }

        public async Task<bool> Guardar(Tarea objeto)
        {
            bool respuesta = false;

           // await Autenticar();


            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
           // cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/Tareas/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Editar(Tarea objeto)
        {
            bool respuesta = false;

           // await Autenticar();


            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/Tareas/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool respuesta = false;

            //await Autenticar();


            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);


            var response = await cliente.DeleteAsync($"api/Tareas/{id}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

    }
}
