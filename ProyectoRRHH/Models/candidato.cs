using System;
using System.Collections.Generic;

namespace ProyectoRRHH.Models;

public partial class candidato
{
    public int id { get; set; }

    public string cedula { get; set; }

    public string nombre { get; set; }

    public string puestoaspira { get; set; }

    public string departamento { get; set; }

    public string salarioaspira { get; set; }

    public string capacitaciones { get; set; }

    public string explaboral { get; set; }

    public string recomendadopor { get; set; }

    public virtual capacitacione capacitacionesNavigation { get; set; }

    public virtual departamento departamentoNavigation { get; set; }

    public virtual empleado empleado { get; set; }

    public virtual explaboral explaboralNavigation { get; set; }

    public virtual puesto puestoaspiraNavigation { get; set; }

    public virtual ICollection<competencia> competencias { get; set; } = new List<competencia>();
}
