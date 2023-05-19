using System;
using System.Collections.Generic;

namespace ProyectoRRHH.Models;

public partial class capacitacione
{
    public int id { get; set; }

    public string descripcion { get; set; }

    public string nivel { get; set; }

    public DateOnly? fechadesde { get; set; }

    public DateOnly? fechahasta { get; set; }

    public string institucion { get; set; }

    public virtual ICollection<candidato> candidatos { get; set; } = new List<candidato>();
}
