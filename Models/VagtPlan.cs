﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EksamenSem2.Models;

[Table("VagtPlan")]
public partial class VagtPlan
{
    [Key]
    public int Id { get; set; }

    public int MedarbejderId { get; set; }

    public int PlanId { get; set; }

    [ForeignKey("MedarbejderId")]
    [InverseProperty("VagtPlans")]
    public virtual Medarbejder Medarbejder { get; set; }

    [ForeignKey("PlanId")]
    [InverseProperty("VagtPlans")]
    public virtual PlanDatum Plan { get; set; }
}