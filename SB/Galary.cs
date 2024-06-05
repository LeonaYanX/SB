using System;
using System.Collections.Generic;

namespace SB;

public partial class Galary
{
    public int Id { get; set; }

    public int? IdBook { get; set; }

    public virtual Book? IdBookNavigation { get; set; }
}
