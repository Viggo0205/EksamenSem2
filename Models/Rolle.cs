﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EksamenSem2.Models;

[Table("Rolle")]
public partial class Rolle
{
    [Key]
    [Column("Rolle_ID")]
    public int RolleId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Navn { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Rettigheder { get; set; }

    [InverseProperty("Rolle")]
    public virtual ICollection<Medarbejder> Medarbejders { get; set; } = new List<Medarbejder>();
}