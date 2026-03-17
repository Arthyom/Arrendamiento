using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Enums;

namespace Core.Models.Entities;

[Table("interior")]
public class Interior: BaseEntity
{
    public string? Etiqueta { get; set; } = null!;

    // public string? Descripcion { get; set; } = null!;

    public string Alias { get; set; }   = null!;


    public decimal Precio { get; set; }

    public TypePropertyEnum TypeProperty { get; set; }


    public bool Libre { get; set; }


    public int PropiedadId { get; set; }

    public int? ArrendatarioId { get; set; }


    
    public Propiedad Propiedad { get; set; } = null!;


    public Arrendatario Arrendatario { get; set; } = null!;

}
