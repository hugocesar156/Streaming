using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("SERIES_EPISODE")]
public partial class SERIES_EPISODE
{
    [Key]
    public int ID_SERIES_EPISODE { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    public short SEASON { get; set; }

    public short EPISODE { get; set; }

    public short DURATION { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string SYNOPSIS { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string THUMBNAIL { get; set; } = null!;

    public short YEAR { get; set; }

    public int ID_SERIES { get; set; }

    public short? OPENING_START { get; set; }

    public short? CREDITS_START { get; set; }

    [InverseProperty("ID_SERIES_EPISODENavigation")]
    public virtual ICollection<AUDIO> AUDIOs { get; set; } = new List<AUDIO>();

    [InverseProperty("ID_SERIES_EPISODENavigation")]
    public virtual ICollection<CATALOG_CONTENT> CATALOG_CONTENTs { get; set; } = new List<CATALOG_CONTENT>();

    [InverseProperty("ID_SERIES_EPISODENavigation")]
    public virtual ICollection<CATALOG_REGION_ITEM> CATALOG_REGION_ITEMs { get; set; } = new List<CATALOG_REGION_ITEM>();

    [ForeignKey("ID_SERIES")]
    [InverseProperty("SERIES_EPISODEs")]
    public virtual SERIES ID_SERIESNavigation { get; set; } = null!;

    [InverseProperty("ID_SERIES_EPISODENavigation")]
    public virtual ICollection<MEDIum> MEDIa { get; set; } = new List<MEDIum>();

    [InverseProperty("ID_SERIES_EPISODENavigation")]
    public virtual ICollection<SUBTITLE> SUBTITLEs { get; set; } = new List<SUBTITLE>();
}
