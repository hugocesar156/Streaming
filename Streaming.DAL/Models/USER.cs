using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("USER")]
public partial class USER
{
    [Key]
    public int ID_USER { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string EMAIL { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string PASSWORD { get; set; } = null!;

    [StringLength(24)]
    [Unicode(false)]
    public string SALT { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? SIGN_IN_DATE { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime SIGN_UP_DATE { get; set; }

    [InverseProperty("ID_USERNavigation")]
    public virtual ICollection<PASSWORD_CODE> PASSWORD_CODEs { get; set; } = new List<PASSWORD_CODE>();

    [InverseProperty("ID_USERNavigation")]
    public virtual ICollection<PROFILE> PROFILEs { get; set; } = new List<PROFILE>();
}
