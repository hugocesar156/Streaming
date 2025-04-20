using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("SERIES_EPISODE_CONTENT")]
public partial class SERIES_EPISODE_CONTENT
{
    [Key]
    public int ID_SERIES_EPISODE_CONTENT { get; set; }

    public int ID_SERIES_EPISODE { get; set; }

    public int ID_CONTENT { get; set; }

    [ForeignKey("ID_CONTENT")]
    [InverseProperty("SERIES_EPISODE_CONTENTs")]
    public virtual CONTENT ID_CONTENTNavigation { get; set; } = null!;

    [ForeignKey("ID_SERIES_EPISODE")]
    [InverseProperty("SERIES_EPISODE_CONTENTs")]
    public virtual SERIES_EPISODE ID_SERIES_EPISODENavigation { get; set; } = null!;
}
