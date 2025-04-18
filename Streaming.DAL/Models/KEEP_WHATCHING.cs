using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("KEEP_WHATCHING")]
public partial class KEEP_WHATCHING
{
    [Key]
    public int ID_KEEP_WHATCHING { get; set; }

    public int? ID_FILM { get; set; }

    public int? ID_SERIES_EPISODE { get; set; }

    public int DURATION { get; set; }

    public int ID_PROFILE { get; set; }

    [ForeignKey("ID_PROFILE")]
    [InverseProperty("KEEP_WHATCHINGs")]
    public virtual PROFILE ID_PROFILENavigation { get; set; } = null!;
}
