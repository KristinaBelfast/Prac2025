using System;
using System.Collections.Generic;

namespace Prac.Models1;

public partial class User
{
    public int UserId { get; set; }

    public string Login { get; set; } = null!;

    public int? Password { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;
}
