using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("FILM_CATEGORY")]
public partial class FILM_CATEGORY
{
    [Key]
    public int ID_FILM_CATEGORY { get; set; }

    public int ID_FILM { get; set; }

    public int ID_CATEGORY { get; set; }

    [ForeignKey("ID_CATEGORY")]
    [InverseProperty("FILM_CATEGORies")]
    public virtual CATEGORY ID_CATEGORYNavigation { get; set; } = null!;

    [ForeignKey("ID_FILM")]
    [InverseProperty("FILM_CATEGORies")]
    public virtual FILM ID_FILMNavigation { get; set; } = null!;
}
