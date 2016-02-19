using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace CSharp6Demo
{
  public class Program
  {
    static void Main(string[] args)
    {
      var points = new[] { new Point(3, 4), new Point(-1, 0), new Point(5, -2), new Point(7, 6) };
      WriteLine(Point.ToString(points));

      var json = new JArray(from p in points select p.ToJson()).ToString();
      WriteLine(json);

      var pointsAgain =
        from j in JArray.Parse(json)
        select Point.FromJson(j as JObject);
      WriteLine(Point.ToString(pointsAgain));

      ReadKey();
    }
  }
}
