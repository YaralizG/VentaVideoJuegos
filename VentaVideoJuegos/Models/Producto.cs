using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VentaVideoJuegos.Models
{
    [Table("t_producto")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("nombre")]
        public string nombre { get; set; }
        [Column("categoria")]
        public string categoria { get; set; }
        [Column("precio")]
        public int precio {get; set;}
        [Column("descuento")]
        public int descuento {get; set; }    

    }
}