using System;
using System.Collections.Generic;

namespace XYZPlatform.Models.Models;

public partial class Time
{
    public int Id { get; set; }

    public DateTime DateActivity { get; set; }

    public int Hour { get; set; }

    public int IdActivity { get; set; }

    public virtual Activity IdActivityNavigation { get; set; } = null!;
}
