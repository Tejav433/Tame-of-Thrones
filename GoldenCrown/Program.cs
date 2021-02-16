using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GoldenCrown.Models;
using Newtonsoft.Json;

namespace GoldenCrown {
  class Program {

    private static string _rulerCandidate;
    private static Universe _southeros;

    static void Main( string[] args ) {
      if ( !args.Any() ) {
        Console.WriteLine( "Please Give the path to the input file !!!" );
        return;
      }
      if ( !File.Exists( args[0] ) ) {
        Console.WriteLine( "Given input file is Invalid. Please give correct Path to the input file !!" );
        return;
      }
      BuildUniverse();
      Execute( args[0] );
      //Console.WriteLine( "\nEnter Any Key To Exit ... -)" );
      //Console.ReadKey();
    }

    private static void Execute( string path ) {
      var testCases = File.ReadAllLines( path );
      foreach ( var line in testCases ) {
        var testCase = line.Split( "\t" );
        var message = new Message {
          From = _southeros.Kingdoms[_rulerCandidate],
          To = testCase[0],
          Data = testCase[1]
        };
        _southeros.Send( message );

      }
      _southeros.DisplayRuler();
    }

    private static void BuildUniverse() {
      var kingdomlist = JsonConvert.DeserializeObject
        <IEnumerable<KingdomModel>>( File.ReadAllText( "Kingdoms.json" ) );
      var kingdoms = new List<Kingdom>();
      foreach ( var kingdom in kingdomlist ) {
        kingdoms.Add( new Kingdom( kingdom.Name, kingdom.Emblem, kingdom.KingName ) );
        if ( kingdom.RulerCandidate ) {
          _rulerCandidate = kingdom.Name;
        }
      }
      _southeros = new Universe( "Southeros", kingdoms );
    }
  }
}
