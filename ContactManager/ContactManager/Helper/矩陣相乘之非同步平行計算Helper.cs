using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Helper
{
    public class 矩陣相乘之非同步平行計算Helper
    {
        #region 矩陣相乘之非同步平行計算
        public static void 矩陣相乘之非同步平行計算(double[,] matA, double[,] matB, double[,] result)
        {
            int matACols = matA.GetLength(1);
            int matBCols = matB.GetLength(1);
            int matARows = matA.GetLength(0);

            // 我們僅將最外圈的迴圈做平行計算，因為，裡面的兩個迴圈計算工作不多，若也採用平行計算方式，則會有額外的負擔產生
            Parallel.For(0, matARows, i =>
            {
                if (i == 100)
                {
                    int a = 0;
                }
                for (int j = 0; j < matBCols; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < matACols; k++)
                    {
                        temp += matA[i, k] * matB[k, j];
                    }
                    result[i, j] = temp;
                }
            }); // Parallel.For
        }
        #endregion

        #region 進行矩陣值的初始化工作
        public static double[,] 進行矩陣值的初始化工作(int rows, int cols)
        {
            double[,] matrix = new double[rows, cols];

            Random r = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = r.Next(100);
                }
            }
            return matrix;
        }

        #endregion
    }
}
