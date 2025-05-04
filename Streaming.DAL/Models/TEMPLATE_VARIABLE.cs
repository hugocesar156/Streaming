using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("TEMPLATE_VARIABLE")]
public partial class TEMPLATE_VARIABLE
{
    [Key]
    public int ID_TEMPLATE_VARIABLES { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    public byte POSITION { get; set; }

    public int ID_TEMPLATE { get; set; }

    [ForeignKey("ID_TEMPLATE")]
    [InverseProperty("TEMPLATE_VARIABLEs")]
    public virtual TEMPLATE ID_TEMPLATENavigation { get; set; } = null!;
}
