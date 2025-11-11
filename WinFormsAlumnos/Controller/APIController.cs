using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WinFormsAlumnos.Models;
using static System.Net.WebRequestMethods;

namespace WinFormsAlumnos.Controller
{
    internal class APIController
    {

        private static readonly HttpClient _http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        #region-->Metodo GET
        public async Task<List<AlumnoModels>> GetAlumnosAsync(string url = "https://localhost:7079/api/Alumno")
        {
            using var resp = await _http.GetAsync(url).ConfigureAwait(false);
            resp.EnsureSuccessStatusCode();

            var stream = await resp.Content.ReadAsStreamAsync().ConfigureAwait(false);
            var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var lista = await JsonSerializer.DeserializeAsync<List<AlumnoModels>>(stream, opts).ConfigureAwait(false);
            return lista ?? new List<AlumnoModels>();

        }
        #endregion

        #region-->Metodo POST
        public async Task<AlumnoModels?> PostAlumnoAsync(AlumnoModels alumno, string url = "https://localhost:7079/api/Alumno")
        {
            if (alumno == null) return null;

            try
            {
                var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var json = JsonSerializer.Serialize(alumno, opts);
                using var content = new StringContent(json, Encoding.UTF8, "application/json");

                using var resp = await _http.PostAsync(url, content).ConfigureAwait(false);
                resp.EnsureSuccessStatusCode();

                var stream = await resp.Content.ReadAsStreamAsync().ConfigureAwait(false);
                var created = await JsonSerializer.DeserializeAsync<AlumnoModels>(stream, opts).ConfigureAwait(false);
                return created;
            }
            catch
            {
                // Podrías loguear aquí o propagar la excepción según prefieras
                return null;
            }
        }
        #endregion

        #region--> metodo PUT
        public async Task<bool> PutAlumnoAsync(int id, AlumnoModels alumno, string baseUrl = "https://localhost:7079/api/Alumno")
        {
            if (alumno == null) return false;

            try
            {
                var url = $"{baseUrl}/{id}";
                var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var json = JsonSerializer.Serialize(alumno, opts);
                using var content = new StringContent(json, Encoding.UTF8, "application/json");

                using var resp = await _http.PutAsync(url, content).ConfigureAwait(false);
                return resp.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region--> metodo DELETE
        public async Task<bool> DeleteAlumnoAsync(int id, string baseUrl = "https://localhost:7079/api/Alumno")
        {
            try
            {
                var url = $"{baseUrl}/{id}";
                using var resp = await _http.DeleteAsync(url).ConfigureAwait(false);
                return resp.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}

