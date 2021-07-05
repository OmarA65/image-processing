using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Project
{
    class Filters
    {
        //filter blur 1/25
        public static double[,] BlurFilter = new double[5, 5]{       {0.04, 0.04, 0.04,0.04,0.04 },
                                                      {0.04, 0.04, 0.04,0.04,0.04 },
                                                      {0.04, 0.04, 0.04,0.04,0.04 },
                                                      {0.04, 0.04, 0.04,0.04,0.04 },
                                                      {0.04, 0.04, 0.04,0.04,0.04 } };

        public static double[,] SobelverticalEdge = new double[3, 3] { {1,2,1 },
                                                                        {0,0,0 },
                                                                        {-1,-2,-1} };

        public static double[,] SobelhorizontalEdge = new double[3, 3] { {1,0,-2 },
                                                                        {2,0,-2 },
                                                                        {1,0,-1 } };

        public static double[,] Sharpen = new double[3, 3] { {0,-1,0 },
                                                             {-1,5,-1 },
                                                             {0,-1,0 } };

    }
                                                     
}
