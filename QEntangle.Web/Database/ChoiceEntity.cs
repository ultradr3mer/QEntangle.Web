﻿using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace QEntangle.Web.Database
{
  public class ChoiceEntity
  {
    #region Properties

    [MaxLength(500)]
    public string DefinitiveOption { get; set; }

    [Key]
    public Guid Id { get; set; }

    [MaxLength(500)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string Options { get; set; }

    public IdentityUser User { get; set; }

    public Guid UserId { get; set; }

    #endregion Properties
  }
}