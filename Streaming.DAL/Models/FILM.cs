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

    [StringLength(200)]
    [Unicode(false)]
    public string THUMBNAIL { get; set; } = null!;

    public short YEAR { get; set; }

    public int ID_LANGUAGE { get; set; }

    public short? CREDITS_START { get; set; }

    public bool KIDS_CONTENT { get; set; }

    [InverseProperty("ID_FILMNavigation")]
    public virtual ICollection<CAST> CASTs { get; set; } = new List<CAST>();

    [InverseProperty("ID_FILMNavigation")]
    public virtual ICollection<FILM_CATEGORY> FILM_CATEGORies { get; set; } = new List<FILM_CATEGORY>();

    [InverseProperty("ID_FILMNavigation")]
    public virtual ICollection<FILM_CONTENT> FILM_CONTENTs { get; set; } = new List<FILM_CONTENT>();

    [InverseProperty("ID_FILMNavigation")]
    public virtual ICollection<FILM_REGION> FILM_REGIONs { get; set; } = new List<FILM_REGION>();

    [ForeignKey("ID_LANGUAGE")]
    [InverseProperty("FILMs")]
    public virtual LANGUAGE ID_LANGUAGENavigation { get; set; } = null!;

    [InverseProperty("ID_FILMNavigation")]
    public virtual ICollection<MEDIum> MEDIa { get; set; } = new List<MEDIum>();
}
