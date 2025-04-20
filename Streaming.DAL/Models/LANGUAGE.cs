using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("LANGUAGE")]
public partial class LANGUAGE
{
    [Key]
    public int ID_LANGUAGE { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string DESCRIPTION { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string CODE { get; set; } = null!;

    [InverseProperty("ID_LANGUAGENavigation")]
    public virtual ICollection<AUDIO> AUDIOs { get; set; } = new List<AUDIO>();

    [InverseProperty("ID_LANGUAGENavigation")]
    public virtual ICollection<CATALOG_REGION> CATALOG_REGIONs { get; set; } = new List<CATALOG_REGION>();

    [InverseProperty("ID_LANGUAGENavigation")]
    public virtual ICollection<FILM> FILMs { get; set; } = new List<FILM>();

    [InverseProperty("ID_LANGUAGENavigation")]
    public virtual ICollection<SERIES> SERIES { get; set; } = new List<SERIES>();

    [InverseProperty("ID_LANGUAGENavigation")]
    public virtual ICollection<SUBTITLE> SUBTITLEs { get; set; } = new List<SUBTITLE>();
}
