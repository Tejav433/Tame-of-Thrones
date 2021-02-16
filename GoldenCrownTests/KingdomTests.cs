using System.Linq;
using GoldenCrown;
using Xunit;

namespace GoldenCrownTests {
  public class KingdomTests {

    private readonly Kingdom _space;
    private readonly Kingdom _land;
    private readonly Kingdom _water;
    private readonly Kingdom _ice;
   
    public KingdomTests() {
      _space = new Kingdom( "SPACE", "Gorilla", "Shan" );
      _land = new Kingdom( "LAND", "Panda" );
      _water = new Kingdom( "WATER", "Octopus" );
      _ice = new Kingdom( "ICE", "Mammoth" );

    }

    [Fact]
    public void AcceptAllegiance_When_Message_Isvalid() {
      _ice.Send( _space, "STHSTSTVSASOS" );
      Assert.True( _ice.AcceptedAllegiance() );
    }

    [Fact]
    public void AcceptAllegiance_When_Message_Isvalid_IgnoreCase() {
      _ice.Send( _space, "SthststvsaSOS" );
      Assert.True( _ice.AcceptedAllegiance() );
    }

    [Fact]
    public void AcceptAllegiance_When_Message_IsInvalid() {
      _ice.Send( _space, "ROZO" );
      Assert.False( _ice.AcceptedAllegiance() );
    }

    [Fact]
    public void AddingAllies_When_AcceptedAlligiance() {
      _land.Send( _water, "FDIXXSOKKOFBBMU" );
      Assert.True( _land.AcceptedAllegiance() );
      Assert.True( _water.Allies.Count == 1 );
      Assert.True( _water.Allies.First().Equals( "LAND" ) );
    }

    [Fact]
    public void NoAddingAllies_When_RejectedAlligiance() {
      _land.Send( _water, "MOMAMVTMTMHTM" );
      Assert.False( _land.AcceptedAllegiance() );
      Assert.True( _water.Allies.Count == 0 );
    }

    [Fact]
    public void AddingAllies_When_AcceptedAlligiance_IgnoreCase() {
      _land.Send( _water, "fdixxsokkOFBBMU" );
      Assert.True( _land.AcceptedAllegiance() );
      Assert.True( _water.Allies.Count == 1 );
      Assert.True( _water.Allies.First().Equals( "LAND" ) );
    }

  }
}
