using System;
using System.Collections.Generic;

namespace PAWUNED_EdgarArias_Proyecto1.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? FechaNac { get; set; }

    public int? Altura { get; set; }

    public double? Peso { get; set; }

    public string? Genero { get; set; }

    public byte[]? FotoPerfil { get; set; }

    public virtual ICollection<ActividadFisica> ActividadFisicas { get; set; } = new List<ActividadFisica>();

    public virtual ICollection<Meta> Meta { get; set; } = new List<Meta>();

    public virtual ICollection<RegistroDietum> RegistroDieta { get; set; } = new List<RegistroDietum>();
}
