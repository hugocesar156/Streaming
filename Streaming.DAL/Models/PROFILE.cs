using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("PROFILE")]
public partial class PROFILE
{
    [Key]
    public int ID_PROFILE { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string AVATAR { get; set; } = null!;

    public int ID_USER { get; set; }

    public bool KIDS_CONTENT { get; set; }

    [ForeignKey("ID_USER")]
    [InverseProperty("PROFILEs")]
    public virtual USER ID_USERNavigation { get; set; } = null!;

    [InverseProperty("ID_PROFILENavigation")]
    public virtual ICollection<KEEP_WHATCHING> KEEP_WHATCHINGs { get; set; } = new List<KEEP_WHATCHING>();

    [InverseProperty("ID_PROFILENavigation")]
    public virtual ICollection<MY_LIST> MY_LISTs { get; set; } = new List<MY_LIST>();
}
