using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Project
{
    class Model
    {
        public static bool correlation(double [,] img, double[,] filter, int width, int height, int Lfilter, int Wfilter)
        {
            double result = 0;
            int newJ=0, newI=0;
            for (int i = 0; i < width - 6; i++)
            {
                for (int j = 0; j < height - 6; j++)
                {
                    result = 0;
                    newI = 0;
                    for (int x = i; x < i + Lfilter; x++)
                    {
                        newJ = 0;
                        for (int y = j; y < j + Wfilter; y++)
                        {
                            result += (img[x, y] * filter[newI,newJ]);
                            newJ++;
                        }
                        newI++;
                    }
                    if(result<0)
                    {
                        result = 0;
                    }
                    if(result>255)
                    {
                        result = 255;
                    }
                    img[i, j] = result;
                }

            }
            return true;
        }
    }
}
