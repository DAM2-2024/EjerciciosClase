using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Models
{
    internal class Tarea : ICloneable
    {
        public Guid Id { get; set; }  
        public string? Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Completado { get; set; }

        public Tarea()
        {
            Id = Guid.NewGuid();
        }
        public override string ToString()
        {
            return $"ID: {Id} {Environment.NewLine}" +
                "Descripción: {Descripcion} {Environment.NewLine}" +
                $"FechaVencimiento: {FechaVencimiento} {Environment.NewLine}" +
                $"Completado: {Completado}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
