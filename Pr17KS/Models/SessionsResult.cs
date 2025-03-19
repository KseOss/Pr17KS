using System;
using System.Collections.Generic;

namespace Pr17KS.Models;

public partial class SessionsResult
{
    public int SudentId { get; set; }

    public string GroupIndex { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string Gender { get; set; } = null!;

    public string MaritalStatus { get; set; } = null!;

    public int? Math { get; set; }

    public int? Rus { get; set; }

    public int? Phys { get; set; }

    public int? Inf { get; set; }

    public int? Eng { get; set; }
}
