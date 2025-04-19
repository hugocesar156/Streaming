using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("FILM")]
public partial class FILM
{
    [Key]
    public int ID_FILM { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    public short DURATION { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string CLASSIFICATION { get; set; } = null!;

    [Unicode(false)]
    public string SYNOPSIS { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string THUMBNAIL { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string MEDIA { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string PREVIEW { get; set; } = null!;

    public short YEAR { get; set; }

    [InverseProperty("ID_FILMNavigation")]
    public virtual ICollection<CAST> CASTs { get; set; } = new List<CAST>();

    [InverseProperty("ID_FILMNavigation")]
    public virtual ICollection<FILM_CATEGORY> FILM_CATEGORies { get; set; } = new List<FILM_CATEGORY>();

    [InverseProperty("ID_FILMNavigation")]
    public virtual ICollection<FILM_CONTENT> FILM_CONTENTs { get; set; } = new List<FILM_CONTENT>();
}
