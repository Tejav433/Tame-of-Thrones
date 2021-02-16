using System.Collections.Generic;
using GoldenCrown;
using GoldenCrown.Models;
using Xunit;

namespace GoldenCrownTests {
  public class UniverseTests {

    private readonly Kingdom _space;
    private readonly Kingdom _land;
    private readonly Kingdom _water;
    private readonly Kingdom _ice;
    private readonly Kingdom _air;
    private readonly Kingdom _fire;

    private readonly Universe _southeros;

    public UniverseTests() {
      _space = new Kingdom( "SPACE", "Gorilla", "Shan" );
      _land = new Kingdom( "LAND", "Panda" );
      _water = new Kingdom( "WATER", "Octopus" );
      _ice = new Kingdom( "ICE", "Mammoth" );
      _air = new Kingdom( "AIR", "Owl" );
      _fire = new Kingdom( "Fire", "Dragon" );

      _southeros = new Universe( "Southeros", new List<Kingdom> { _space, _land, _water, _ice, _air, _fire } );

    }

    [Fact]
    public void NoKingdom_Has_3Allies() {
      Assert.True( _southeros.Ruler() == null );
    }

    [Fact]
    public void NoKingdom_Has_GreaterthanOrEqual3Allies() {
      _southeros.Send( new Message { From = _space, To = "AIR", Data = "ROZO" } );
      _southeros.Send( new Message { From = _space, To = "LAND", Data = "FAIJWJSOOFAMAU" } );
      Assert.True( _southeros.Ruler() == null );
    }

    [Fact]
    public void Kingdom_Has_GreaterthanOrEqual3Allies_1() {
      _southeros.Send( new Message { From = _space, To = "AIR", Data = "ROZO" } );
      _southeros.Send( new Message { From = _space, To = "LAND", Data = "FAIJWJSOOFAMAU" } );
      _southeros.Send( new Message { From = _space, To = "ICE", Data = "STHSTSTVSASOS" } );
      Assert.True( _southeros.Ruler() != null );
      Assert.True( _southeros.Ruler().Name.Equals( _space.Name ) );
      Assert.True( _southeros.Ruler().Allies.Count >= 3 );
    }

    [Fact]
    public void Kingdom_Has_GreaterthanOrEqual3Allies_2() {
      _southeros.Send( new Message { From = _space, To = "LAND", Data = "FDIXXSOKKOFBBMU" } );
      _southeros.Send( new Message { From = _space, To = "ICE", Data = "MOMAMVTMTMHTM" } );
      _southeros.Send( new Message { From = _space, To = "WATER", Data = "SUMMER IS COMING" } );
      _southeros.Send( new Message { From = _space, To = "AIR", Data = "OWLAOWLBOWLC" } );
      _southeros.Send( new Message { From = _space, To = "FIRE", Data = "AJXGAMUTA" } );
      Assert.True( _southeros.Ruler() != null );
      Assert.True( _southeros.Ruler().Name.Equals( _space.Name ) );
      Assert.True( _southeros.Ruler().Allies.Count >= 3 );
    }

    [Fact]
    public void Kingdom_Has_GreaterthanOrEqual3Allies_3() {
      _southeros.Send( new Message { From = _space, To = "AIR", Data = "OWLAOWLBOWLC" } );
      _southeros.Send( new Message { From = _space, To = "LAND", Data = "OFBBMUFDICCSO" } );
      _southeros.Send( new Message { From = _space, To = "ICE", Data = "VTBTBHTBBBOBAB" } );
      _southeros.Send( new Message { From = _space, To = "WATER", Data = "SUMMER IS COMING" } );
      Assert.True( _southeros.Ruler() == null );
    }

    [Fact]
    public void Kingdom_Has_GreaterthanOrEqual3Allies_IgnoreCase() {
      _southeros.Send( new Message { From = _space, To = "Air", Data = "Rozo" } );
      _southeros.Send( new Message { From = _space, To = "Land", Data = "FAiJwJsOOFAMAU" } );
      _southeros.Send( new Message { From = _space, To = "IcE", Data = "STHStsTvsasOS" } );
      Assert.True( _southeros.Ruler() != null );
      Assert.True( _southeros.Ruler().Name.Equals( _space.Name ) );
      Assert.True( _southeros.Ruler().Allies.Count >= 3 );
    }

    [Fact]
    public void Kingdom_Has_DuplicateAllies() {
      _southeros.Send( new Message { From = _space, To = "Air", Data = "Rozo" } );
      _southeros.Send( new Message { From = _space, To = "Air", Data = "Rozo" } );
      _southeros.Send( new Message { From = _space, To = "Air", Data = "Rozo" } );
      Assert.True( _southeros.Ruler() == null );
    }


  }
}
