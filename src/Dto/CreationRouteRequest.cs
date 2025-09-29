using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace perla_metro_main_api.Dto
{
    public class CreationRouteRequest
    {
        [Required(ErrorMessage = "El origen es obligatorio.")]
        [StringLength(200, ErrorMessage = "El origen no puede exceder los 200 caracteres.")]
        public string originId { get; set; }

        [Required(ErrorMessage = "El destino es obligatorio.")]
        [StringLength(200, ErrorMessage = "El destino no puede exceder los 200 caracteres.")]
        public string destinationId { get; set; }

        /// <summary>
        /// Paradas intermedias
        /// </summary>
        public List<string> stopsIds { get; set; } = new();

        [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
        [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d$", 
        ErrorMessage = "La hora de inicio debe estar en formato HH:mm entre 00:00 y 23:59")]
        public string startTime { get; set; }

        [Required(ErrorMessage = "La hora de término es obligatoria.")]
        [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d$", 
        ErrorMessage = "La hora de término debe estar en formato HH:mm entre 00:00 y 23:59")]
        public string endTime { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
