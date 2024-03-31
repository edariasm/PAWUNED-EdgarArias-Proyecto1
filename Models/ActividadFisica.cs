using System;
using System.Collections.Generic;

namespace PAWUNED_EdgarArias_Proyecto1.Models;

public partial class ActividadFisica
{
    public int IdRegActividad { get; set; }

    public int IdUsuario { get; set; }

    public string? TipoActividad { get; set; }

    public DateTime? FechaHoraActividad { get; set; }

    public int? DuracionMinutos { get; set; }

    public double? DistanciaRecorrida { get; set; }

    public double? ConsumoCalorico { get; set; }

    public string? Comentarios { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
