using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("CAST")]
public partial class CAST
{
    [Key]
    public int ID_CAST { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string CHARACTER { get; set; } = null!;

    public int? ID_FILM { get; set; }

    public int? ID_SERIES { get; set; }

    public short? SEASON { get; set; }

    [ForeignKey("ID_FILM")]
    [InverseProperty("CASTs")]
    public virtual FILM? ID_FILMNavigation { get; set; }

    [ForeignKey("ID_SERIES")]
    [InverseProperty("CASTs")]
    public virtual SERIES? ID_SERIESNavigation { get; set; }
}
