

using KoreCommon;

public class KoreElevationTile
{
    public KoreLLBox        LLBox;
    public KoreFloat2DArray ElevationData;
    public KoreMapTileCode  TileCode = new();

    // Zero tile
    public static KoreElevationTile Zero
    {
        get { return new KoreElevationTile(); }
    }

    public float GetElevation(double latDegs, double lonDegs)
    {
        KoreLLPoint pos = new() { LatDegs = latDegs, LonDegs = lonDegs };

        if (LLBox.Contains(pos))
        {
            float latFrac;
            float lonFrac;

            (latFrac, lonFrac) = LLBox.GetLatLonFraction(pos);
            float eleAtFraction = ElevationData.InterpolatedValue(lonFrac, latFrac); // lon first, X Y.

            return eleAtFraction;
        }
        return KoreElevationUtils.InvalidEle;
    }


}
