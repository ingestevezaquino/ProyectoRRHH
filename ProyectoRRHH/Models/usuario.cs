using System;
using System.Collections.Generic;

namespace ProyectoRRHH.Models;

public partial class usuario
{
    public int id { get; set; }

    public string nombre { get; set; }

    public string correo { get; set; }

    public string clave { get; set; }

    public int? idrol { get; set; }

    public virtual rol idrolNavigation { get; set; }
}
