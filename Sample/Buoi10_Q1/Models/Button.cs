using System;
using System.Collections.Generic;

namespace Buoi10_Q1.Models
{
    public partial class Button
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public string Color { get; set; } = null!;
    }
}
