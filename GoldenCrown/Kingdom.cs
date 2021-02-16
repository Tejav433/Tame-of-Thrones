using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldenCrown {
  public class Kingdom {

    public string Name;
    public string Emblem;
    public string KingName;
    public HashSet<string> Allies;
    private string _message;



    public Kingdom( string name, string emblem, string kingName = null ) {

      Name = name;
      Emblem = emblem;
      KingName = kingName;
      Allies = new HashSet<string>();
    }

    public void Send( Kingdom from, string msg ) {
      _message = msg;
      if ( AcceptedAllegiance() ) {
        if ( !from.Name.Equals( Name ) && !from.Allies.Contains( Name ) )
          from.Allies.Add( Name );
      }
    }

    public bool AcceptedAllegiance() {
      return CheckMessage();
    }

    private bool CheckMessage() {
      var encryptedEmblem = GetEncryptedEmblem();
      var distinctChar = encryptedEmblem.Distinct().ToArray();
      return distinctChar.All( ch => _message.ToUpper().Count( x => x == ch )
                          >= encryptedEmblem.Count( v => v == ch ) );
    }

    private string GetEncryptedEmblem() {
      var res = "";
      var start = (int) 'A';
      var end = (int) 'Z';
      foreach ( var c in Emblem.ToUpper() ) {
        var p = (int) c + Emblem.Length;
        res += Convert.ToChar( p > end ? start - 1 + p % end : p );
      }
      return res.ToUpper();
    }

  }
}
