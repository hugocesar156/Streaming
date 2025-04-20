using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("RESOLUTION")]
public partial class RESOLUTION
{
    [Key]
    public int ID_RESOLUTION { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string DESCRIPTION { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string PIXELS { get; set; } = null!;
}
