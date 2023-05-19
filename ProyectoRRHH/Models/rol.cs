using System;
using System.Collections.Generic;

namespace ProyectoRRHH.Models;

public partial class rol
{
    public int id { get; set; }

    public string descripcion { get; set; }

    public virtual ICollection<usuario> usuarios { get; set; } = new List<usuario>();
}
