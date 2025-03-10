using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mission10_API.Models;

public partial class Bowler
{
    public int BowlerId { get; set; }

    public string? BowlerLastName { get; set; }

    public string? BowlerFirstName { get; set; }

    public string? BowlerMiddleInit { get; set; }

    public string? BowlerAddress { get; set; }

    public string? BowlerCity { get; set; }

    public string? BowlerState { get; set; }

    public string? BowlerZip { get; set; }

    public string? BowlerPhoneNumber { get; set; }

    public int? TeamId { get; set; }

    [JsonIgnore] // Prevents circular reference issue
    public virtual ICollection<BowlerScore> BowlerScores { get; set; } = new List<BowlerScore>();

    [JsonIgnore] // Prevents infinite JSON serialization loop
    public virtual Team? Team { get; set; }
}
