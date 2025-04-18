using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("MY_LIST")]
public partial class MY_LIST
{
    [Key]
    public int ID_MY_LIST { get; set; }

    public int? ID_FILM { get; set; }

    public int? ID_SERIES { get; set; }

    public int ID_PROFILE { get; set; }

    [ForeignKey("ID_PROFILE")]
    [InverseProperty("MY_LISTs")]
    public virtual PROFILE ID_PROFILENavigation { get; set; } = null!;
}
