using System;
using System.Collections.Generic;
using System.Text;

namespace GoldenCrown.Models {
  public class Message {
    public Kingdom From { get; set; }
    public string To { get; set; }
    public string Data { get; set; }
  }
}
