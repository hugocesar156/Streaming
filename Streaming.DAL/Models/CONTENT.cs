using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("CONTENT")]
public partial class CONTENT
{
    [Key]
    public int ID_CONTENT { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string DESCRIPTION { get; set; } = null!;

    [InverseProperty("ID_CONTENTNavigation")]
    public virtual ICollection<FILM> FILMs { get; set; } = new List<FILM>();

    [InverseProperty("ID_CONTENTNavigation")]
    public virtual ICollection<SERIES_EPISODE> SERIES_EPISODEs { get; set; } = new List<SERIES_EPISODE>();
}
