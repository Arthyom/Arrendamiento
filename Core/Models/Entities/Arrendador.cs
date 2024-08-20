﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Models.Entities;

[Table("arrendador")]
public partial class Arrendador : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    [Required]
    [StringLength(100)]
    public string ApellidoPaterno { get; set; }

    [Required]
    [StringLength(100)]
    public string ApellidoMaterno { get; set; }

    [StringLength(100)]
    public string Curp { get; set; }

    [StringLength(100)]
    public string Rfc { get; set; }

    [StringLength(100)]
    public string Alias { get; set; }

    [Required]
    [StringLength(100)]
    public string Direccion { get; set; }

    [StringLength(100)]
    public string Municipio { get; set; }

    [Required]
    [StringLength(100)]
    public string Colonia { get; set; }
}