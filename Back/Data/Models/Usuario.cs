﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Back.Data.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Email { get; set; }

    public string Contrasena { get; set; }

    public bool? EsAdmin { get; set; }

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}