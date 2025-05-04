using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Streaming.DAL.Models;

[Table("EMAIL_SENDER")]
public partial class EMAIL_SENDER
{
    [Key]
    public int ID_EMAIL_SENDER { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string EMAIL { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string PASSWORD { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string SMTP { get; set; } = null!;

    public short PORT { get; set; }

    public bool SSL { get; set; }
}
