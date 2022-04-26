using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Models
{
    public class MenuItem
    {
        public string Text { get; set; }
        public bool Disabled { get; set; }
        public string Icon { get; set; }
        public string Action { get; set; }
        public List<MenuItem> Items { get; set; }
    }
}
