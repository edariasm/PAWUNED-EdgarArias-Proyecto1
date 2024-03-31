using System;
using System.Collections.Generic;

namespace PAWUNED_EdgarArias_Proyecto1.Models;

public partial class RegistroDietum
{
    public int IdRegDieta { get; set; }

    public int? IdUsuario { get; set; }

    public DateOnly FechaComida { get; set; }

    public string TipoComida { get; set; } = null!;

    public string AlimentosConsumidos { get; set; } = null!;

    public double CaloriasTotales { get; set; }

    public string? Comentarios { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
