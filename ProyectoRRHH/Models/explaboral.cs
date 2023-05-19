using System;
using System.Collections.Generic;

namespace ProyectoRRHH.Models;

public partial class explaboral
{
    public int id { get; set; }

    public string empresa { get; set; }

    public string puestoocupado { get; set; }

    public DateOnly? fechadesde { get; set; }

    public DateOnly? fechahasta { get; set; }

    public string salario { get; set; }

    public virtual ICollection<candidato> candidatos { get; set; } = new List<candidato>();
}
