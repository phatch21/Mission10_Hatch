﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mission10_API.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public int? CaptainId { get; set; }

    [JsonIgnore] // Prevents circular reference issue
    public virtual ICollection<Bowler> Bowlers { get; set; } = new List<Bowler>();

    public virtual ICollection<TourneyMatch> TourneyMatchEvenLaneTeams { get; set; } = new List<TourneyMatch>();

    public virtual ICollection<TourneyMatch> TourneyMatchOddLaneTeams { get; set; } = new List<TourneyMatch>();
}
