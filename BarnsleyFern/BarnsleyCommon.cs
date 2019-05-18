using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarnsleyFern
{
    class BarnsleyCommon
    {
        /*
            ....[a][b][c][d][e][f][p]
            [f1].....................
            [f2].....................
            [f3].....................
            [f4].....................
        */
        public static double[,] defaultCoeffs =
            {
            {0,     0,      0,      0.16,   0,  0,      0.01},
            {0.85,  0.04,   -0.04,  0.85,   0,  1.60,   0.85},
            {0.20,  -0.26,  0.23,   0.22,   0,  1.60,   0.07},
            {-0.15,  0.28,  0.26,   0.24,   0,  0.44,   0.07}
            };
    }
}
