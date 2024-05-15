﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EksamenSem2.Models;

public partial class PlanDatum
{
    [Key]
    [Column("Plan_ID")]
    public int PlanId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Dato { get; set; }

    public TimeSpan? StartTid { get; set; }

    public TimeSpan? SlutTid { get; set; }

    public double? Overtid { get; set; }

    [Column(TypeName = "text")]
    public string Beskrivelse { get; set; }

    public int? TotalTimer { get; set; }

    [InverseProperty("Plan")]
    public virtual ICollection<VagtPlan> VagtPlans { get; set; } = new List<VagtPlan>();
}