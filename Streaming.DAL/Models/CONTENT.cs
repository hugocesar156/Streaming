using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("CONTENT")]
public partial class CONTENT
{
    [Key]
    public int ID_CONTENT { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string DESCRIPTION { get; set; } = null!;

    [InverseProperty("ID_CONTENTNavigation")]
    public virtual ICollection<CATALOG_CONTENT> CATALOG_CONTENTs { get; set; } = new List<CATALOG_CONTENT>();
}
