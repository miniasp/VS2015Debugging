using System;
using System.Collections.Immutable;

using static System.Console;
using static System.Math;

namespace IDEFeatureFix
{
  class Program
  {
    static void Main(string[] args)
    {
      //var radius = 6.0;
      //var area = radius * radius * PI;
      //WriteLine(area);
      //ReadKey();

      //Arrays();
      //Console.ReadKey();

      ImmutableArrays();
      Console.ReadKey();
    }

    static void Arrays()
    {
      var a1 = new int[0];
      Console.WriteLine("a1.Length = {0}", a1.Length);

      var a2 = new int[] { 1, 2, 3, 4, 5 };
      Console.WriteLine("a2.Length = {0}", a2.Length);
    }

    static void ImmutableArrays()
    {
      Console.WriteLine("--- Immutable arrays ---");

      var a1 = ImmutableArray<int>.Empty;
      Console.WriteLine("a1.Length = {0}", a1.Length);

      var a2 = ImmutableArray.CreateRange(new int[] { 1, 2, 3, 4, 5 });
      Console.WriteLine("a2.Length = {0}", a2.Length);
    }
  }
}
