public struct Coord
{
    public ushort X { get; }
    public ushort Y { get; }

    public override int GetHashCode() => HashCode.Combine(X, Y);
    public override string ToString() => $"X:{X}, Y:{Y}";

    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public override bool Equals(object? obj) =>
        obj is not Coord other
        ? false
        : X == other.X &&
        Y == other.Y;

}

public struct Plot
{
    // TODO: Complete implementation of the Plot struct
    public Coord Coord1 { get; }
    public Coord Coord2 { get; }
    public Coord Coord3 { get; }
    public Coord Coord4 { get; }
    public int sumX;

    public override int GetHashCode() => HashCode.Combine(Coord1, Coord2, Coord3, Coord4);
    public override string ToString() => $"Coord1:{Coord1}, Coord2:{Coord2}, Coord3:{Coord3}, Coord4:{Coord4}";

    public Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4) {
        Coord1 = coord1;
        Coord2 = coord2;
        Coord3 = coord3;
        Coord4 = coord4;

        sumX = coord1.X + coord2.X + coord3.X + coord4.X;
    }

    public override bool Equals(object? obj) =>
        obj is not Plot other
        ? false
        : Coord1.Equals(other.Coord1) &&
        Coord2.Equals(other.Coord2) &&
        Coord3.Equals(other.Coord3) &&
        Coord4.Equals(other.Coord4);
}


public class ClaimsHandler
{
    private readonly HashSet<Plot> _claimsHash = new();
    private IList<Plot> _claims = new List<Plot>();
    private Plot? _lastClaim;

    public bool IsClaimStaked(Plot plot) => _claimsHash.Contains(plot);
    public bool IsLastClaim(Plot plot) => _lastClaim.HasValue && _lastClaim.Value.Equals(plot);

    public void StakeClaim(Plot plot) {
        _claimsHash.Add(plot);
        _claims.Add(plot);
        _lastClaim = plot;
    } 

    public Plot GetClaimWithLongestSide()
    {
        int x = 0;
        Plot plotwithLongestSide = new Plot();

        foreach (Plot p in _claims) {
            if (p.sumX > x) {
                x = p.sumX;
                plotwithLongestSide = p;
            }
        }
        return plotwithLongestSide;
    }
}
