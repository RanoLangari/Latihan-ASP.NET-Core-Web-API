using System;
using System.Collections.Generic;

namespace CRUD_ASP.Entities;

public partial class TblBarang
{
    public int IdBarang { get; set; }

    public string NamaBarang { get; set; } = null!;

    public string KategoriBarang { get; set; } = null!;

    public string KeteranganBarang { get; set; } = null!;
}
