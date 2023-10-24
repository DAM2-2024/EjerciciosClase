using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Models
{
    internal class ListaTareas 
    {
        public List<Tarea> Tareas { get; set; }
        private static ListaTareas _instance;
        private ListaTareas()
        {
            Tareas = new List<Tarea>();
        }
        public static ListaTareas GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ListaTareas();
            }
            return _instance;
        }
        public string ListarTareas()
        {
            return ListarListaTareas(Tareas);
        }
        private string ListarListaTareas(IEnumerable<Tarea> tareas)
        {
            StringBuilder builder = new StringBuilder();
            foreach(Tarea tarea in tareas)
            {
                builder.AppendLine(tarea.ToString());
            }
            return builder.ToString();
        }
        public string ListarTareasIncompletas()
        {
            return ListarListaTareas(Tareas.Where(x=>!x.Completado));
        }
        public string ListartareasOrdenFechaVencimiento()
        {
            return ListarListaTareas(Tareas.OrderByDescending(x => x.FechaVencimiento));
        }
        public void AgregarTarea(string descripcion, DateTime fechaVencimiento)
        {
            Tareas.Add(new Tarea
            {
                Descripcion = descripcion,
                FechaVencimiento = fechaVencimiento,
                Completado = false
            });
        }

        public void CompletarTarea(string id)
        {
            if (Guid.TryParse(id, out Guid resultado))
            {
                Tarea tareaEncontrada = Tareas.FirstOrDefault(x => x.Id == resultado);
                if (tareaEncontrada == null)
                {
                    tareaEncontrada.Completado = true;
                }
            }
        }


        public void CargarListaAuxiliar(List<Tarea> listaAuxiliar)
        {
            listaAuxiliar.ForEach(x =>
            {
                if (!listaAuxiliar.Any(z => z.Id == x.Id))
                {
                    Tareas.Add(x);
                }
            });
        }
    }
}
