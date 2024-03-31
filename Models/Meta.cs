using System;
using System.Collections.Generic;

namespace PAWUNED_EdgarArias_Proyecto1.Models;

public partial class Meta
{
    public int IdMetaSalud { get; set; }

    public int? IdUsuario { get; set; }

    public string TipoMeta { get; set; } = null!;

    public double PesaObjetivo { get; set; }

    public DateOnly FechaObjetivo { get; set; }

    public string NivelActividad { get; set; } = null!;

    public string? ObjetivosEspecificos { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; } = null!;
}
