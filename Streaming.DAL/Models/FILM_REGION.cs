using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("FILM_REGION")]
public partial class FILM_REGION
{
    [Key]
    public int ID_FILM_REGION { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string CLASSIFICATION { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string SYNOPSIS { get; set; } = null!;

    public int ID_FILM { get; set; }

    public int ID_LANGUAGE { get; set; }

    [ForeignKey("ID_FILM")]
    [InverseProperty("FILM_REGIONs")]
    public virtual FILM ID_FILMNavigation { get; set; } = null!;

    [ForeignKey("ID_LANGUAGE")]
    [InverseProperty("FILM_REGIONs")]
    public virtual LANGUAGE ID_LANGUAGENavigation { get; set; } = null!;
}
