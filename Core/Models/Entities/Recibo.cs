﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Models.Entities;

[Table("recibo")]
public partial class Recibo : BaseEntity
{
    public int ArrendatarioId { get; set; }

    public int ReImpresionId { get; set; }

    public int ArrendadorId { get; set; }

    public int PropiedadId { get; set; }

    public bool Pagado { get; set; }

    public string Concepto { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? FechaPago { get; set; }

    [Required]
    [StringLength(100)]
    public string Identificador { get; set; }

    [Precision(10, 0)]
    public decimal Total { get; set; }

    public List<ReImpresion> ReImpresion { get; set; } = new List<ReImpresion>();


}