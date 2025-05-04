using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("TEMPLATE")]
public partial class TEMPLATE
{
    [Key]
    public int ID_TEMPLATE { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    [InverseProperty("ID_TEMPLATENavigation")]
    public virtual ICollection<TEMPLATE_CONTENT> TEMPLATE_CONTENTs { get; set; } = new List<TEMPLATE_CONTENT>();

    [InverseProperty("ID_TEMPLATENavigation")]
    public virtual ICollection<TEMPLATE_VARIABLE> TEMPLATE_VARIABLEs { get; set; } = new List<TEMPLATE_VARIABLE>();
}
