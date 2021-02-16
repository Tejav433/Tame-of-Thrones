using System;
using System.Collections.Generic;
using System.Text;
using GoldenCrown.Models;

namespace GoldenCrown {
  public class Universe {

    public readonly string Name;
    public readonly Dictionary<string, Kingdom> Kingdoms;
    private readonly int count = 3;

    public Universe( string name, List<Kingdom> kingdoms ) {
      Name = name;
      Kingdoms = GetKingdoms( kingdoms );
    }


    public void Send( Message message ) {
      Kingdoms[message.To.ToUpper()].Send( message.From, message.Data );
    }


    public Kingdom Ruler() {
      foreach ( var kingdom in Kingdoms.Values ) {
        if ( kingdom.Allies.Count >= count )
          return kingdom;
      }
      return null;
    }


    private Dictionary<string, Kingdom> GetKingdoms( List<Kingdom> kingdoms ) {
      var newKingdoms = new Dictionary<string, Kingdom>();
      foreach ( var kingdom in kingdoms ) {
        newKingdoms.Add( kingdom.Name.ToUpper(), kingdom );
      }
      return newKingdoms;
    }


    public void DisplayRuler() {
      var ruler = Ruler();
      if ( ruler == null ) {
        Console.WriteLine( "NONE" );
        return;
      }
      var sb = new StringBuilder();
      sb.Append( ruler.Name );
      foreach ( var ally in ruler.Allies ) {
        sb.Append( " " );
        sb.Append( ally );
      }
      Console.WriteLine( sb.ToString() );
    }
  }
}
