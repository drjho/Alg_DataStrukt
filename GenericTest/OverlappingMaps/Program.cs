using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlappingMaps
{
    class Program
    {
        // https://en.wikipedia.org/wiki/Transformation_matrix#Affine_transformations
        // T * R * S
        static void Main(string[] args)
        {
            while (true)
            {
                var inputs = Console.ReadLine().Split(' ');
                var w = int.Parse(inputs[0]);
                var h = int.Parse(inputs[1]);
                if (w == 0 && h == 0)
                    return;
                var x = int.Parse(inputs[2]);
                var y = int.Parse(inputs[3]);
                var s = int.Parse(inputs[4]);
                var r = int.Parse(inputs[5]);
                Compute(w, h, x, y, s, r);
            }
        }

        static float radScale = (float)Math.PI / 180f;

        static float[] Compute(float w, float h, float x, float y, float s, float r)
        {
            var rad = radScale * r;
            var cosR = Math.Cos(rad);
            var sinR = Math.Sin(rad);
            var a = s * cosR / 100f;
            var b = s* sinR / 100f;
            //Console.WriteLine(a);
            //Console.WriteLine(b);

            var xPos = (x * b + y * a + y - x * a / b) / ((a - 1) / b - b);
            Console.WriteLine(xPos);

            //var yPos = (float)(((x * a - y * b) / (1 - a) + (x * b + y * a)) / (1 + b * b / (1 - a) - a));
            var yPos = (float)(((x * a * b + y * b * b) / (1 - a) + (x * b + y * a)) / (1 + b * b / (1 - a) - a));

            Console.WriteLine(yPos);

            return new float[] { yPos, 0f };
        }
    }
}
