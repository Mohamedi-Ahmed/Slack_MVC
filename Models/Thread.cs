﻿using System;
using System.Collections.Generic;

namespace TP_SlackMVC.Models;

public partial class Thread
{
    public int Id { get; set; }

    public string Label { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
