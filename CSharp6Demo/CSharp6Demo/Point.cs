using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Math;

namespace CSharp6Demo
{
  public class Point
  {
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
      X = x;
      Y = y;
    }

    public override string ToString() => $"({X}, {Y})";

    public double Dist() => Sqrt(X * X + Y * Y);

    public static Point FromJson(JObject json)
    {
      if (json?["x"]?.Type != JTokenType.Integer ||
          json?["y"]?.Type != JTokenType.Integer)
      {
        throw new ArgumentException("The parameter is not shaped like a Point", "json");
      }
      return new Point((int)json["x"], (int)json["y"]);
    }

    public JObject ToJson()
    {
      var result = new JObject() { ["x"] = X, ["y"] = Y };
      return result;
    }

    public static string ToString(IEnumerable<Point> points)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("[");
      foreach (var point in points)
      {
        sb.Append($"({point.X}, {point.Y})");
      }
      sb.Append("]");
      return sb.ToString();
    }

    private static async Task<JArray> GetPointsArrayAsync(string path)
    {
      FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read,
        bufferSize: 4096, useAsync: true);

      try
      {
        StringBuilder sb = new StringBuilder();

        byte[] buffer = new byte[0x1000];
        int numRead;
        while ((numRead = await fs.ReadAsync(buffer, 0, buffer.Length)) != 0)
        {
          string text = Encoding.Unicode.GetString(buffer, 0, numRead);
          sb.Append(text);
        }
        return JArray.Parse(sb.ToString());
      }
      catch (IOException e) when (e.HResult == 0x01)
      {

      }
      finally
      {
        
      }
      return new JArray();
    }
  }
}
