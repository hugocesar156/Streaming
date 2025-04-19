using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("CATEGORY")]
public partial class CATEGORY
{
    [Key]
    public int ID_CATEGORY { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    [InverseProperty("ID_CATEGORYNavigation")]
    public virtual ICollection<FILM_CATEGORY> FILM_CATEGORies { get; set; } = new List<FILM_CATEGORY>();

    [InverseProperty("ID_CATEGORYNavigation")]
    public virtual ICollection<SERIES> SERIES { get; set; } = new List<SERIES>();
}
