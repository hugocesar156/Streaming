using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("PASSWORD_CODE")]
public partial class PASSWORD_CODE
{
    [Key]
    public int ID_PASSWORD_CODE { get; set; }

    public int ID_USER { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string CODE { get; set; } = null!;

    public bool VERIFIED { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATION_DATE { get; set; }

    [ForeignKey("ID_USER")]
    [InverseProperty("PASSWORD_CODEs")]
    public virtual USER ID_USERNavigation { get; set; } = null!;
}
