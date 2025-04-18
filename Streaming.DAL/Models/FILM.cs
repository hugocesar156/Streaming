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

    public int DURATION { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string CLASSIFICATION { get; set; } = null!;

    [StringLength(150)]
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

    public int YEAR { get; set; }

    public int ID_CONTENT { get; set; }

    public int ID_CAST { get; set; }

    public int ID_CATEGORY { get; set; }

    [ForeignKey("ID_CAST")]
    [InverseProperty("FILMs")]
    public virtual CAST ID_CASTNavigation { get; set; } = null!;

    [ForeignKey("ID_CATEGORY")]
    [InverseProperty("FILMs")]
    public virtual CATEGORY ID_CATEGORYNavigation { get; set; } = null!;

    [ForeignKey("ID_CONTENT")]
    [InverseProperty("FILMs")]
    public virtual CONTENT ID_CONTENTNavigation { get; set; } = null!;
}
