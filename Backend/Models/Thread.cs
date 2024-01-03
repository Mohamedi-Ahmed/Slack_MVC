using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TP_SlackMVC.Models;

public partial class Thread
{
    public int Id { get; set; }

    [Required]
    public required string Label { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}