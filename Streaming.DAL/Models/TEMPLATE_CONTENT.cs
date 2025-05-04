using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("TEMPLATE_CONTENT")]
public partial class TEMPLATE_CONTENT
{
    [Key]
    public int ID_TEMPLATE_CONTENT { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    [Unicode(false)]
    public string CONTENT { get; set; } = null!;

    public int ID_TEMPLATE { get; set; }

    public int ID_LANGUAGE { get; set; }

    [ForeignKey("ID_LANGUAGE")]
    [InverseProperty("TEMPLATE_CONTENTs")]
    public virtual LANGUAGE ID_LANGUAGENavigation { get; set; } = null!;

    [ForeignKey("ID_TEMPLATE")]
    [InverseProperty("TEMPLATE_CONTENTs")]
    public virtual TEMPLATE ID_TEMPLATENavigation { get; set; } = null!;
}
