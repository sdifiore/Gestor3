using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Memoria
    {
        public int Id { get; set; }

        public float PvIncrementoGlobal { get; set; }

        public float DespExp { get; set; }

        [StringLength(6)]
        public string PedidoCuboTrabalhado { get; set; }

        [StringLength(6)]
        public string PedidoNotaFiscal { get; set; }
    }
}