using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("FILM_CONTENT")]
public partial class FILM_CONTENT
{
    [Key]
    public int ID_FILM_CONTENT { get; set; }

    public int ID_FILM { get; set; }

    public int ID_CONTENT { get; set; }

    [ForeignKey("ID_CONTENT")]
    [InverseProperty("FILM_CONTENTs")]
    public virtual CONTENT ID_CONTENTNavigation { get; set; } = null!;

    [ForeignKey("ID_FILM")]
    [InverseProperty("FILM_CONTENTs")]
    public virtual FILM ID_FILMNavigation { get; set; } = null!;
}
