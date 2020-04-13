using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp47
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] myArray;
            int arrayLenght;
            //задаём размерность массива
            for (; ; ) 
            {
                Console.WriteLine("Длинна массива:");

                if (Int32.TryParse(Console.ReadLine(), out arrayLenght))
                {
                    myArray = new float[arrayLenght];
                    break;
                }
                else
                {
                    Console.WriteLine("Не верное значение");
                }
            }

            //задаём значения элементам массива
            for (int i = 0; i < myArray.Length; i++)
            {
                for (; ; ) 
                {
                    Console.WriteLine($"Введите знчение {i + 1} элемента ");

                    if (float.TryParse(Console.ReadLine(), out float newArrayElement))
                    {
                        myArray[i] = newArrayElement;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Не верное значение");
                    }
                }
            }

            Console.WriteLine($"Наибольшее значение массива: {GetArrayMaxValue(myArray)}");
            Console.WriteLine($"Сумма установленном интервале: {GetSum(myArray)}");
            DeleteElementsOfInterval(myArray);
            Console.ReadKey();

        }
        /// <summary>
        /// Return max element of float array
        /// </summary>
        /// <param name="newArray"></param>
        /// <returns></returns>
        private static float GetArrayMaxValue(float[] newArray)
        {
            if (newArray == null) throw new Exception("array is null");
            float max = newArray[0];

            foreach(float val in newArray)
            {
                max = (val > max)? val : max;
            }

            return max;
        }

        private static float GetSum(float[] newArray)
        {
            float sum = default;
            if (newArray == null) throw new Exception("array is null");

            int lastOverZeroValue = -1;
            for (int i = 0; i < newArray.Length; i++)
            {
                if(newArray[i] > 0)
                {
                    lastOverZeroValue = i;
                }
            }
            if(lastOverZeroValue != -1)
            {
                for (int i = 0; i < lastOverZeroValue; i++)
                {
                    sum += newArray[i];
                }
            }

            return sum;
        }

        private static void DeleteElementsOfInterval(float[] newArray)
        {
            if (newArray == null) throw new Exception("array is null");

            float 
                firstPoint = default,
                lastPoint = default;
            for(; ; )
            {
                Console.WriteLine("Введите число начала интервала: ");
                if(float.TryParse(Console.ReadLine(), out firstPoint))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect value");
                }
            }
            for (; ; )
            {
                Console.WriteLine("Введите число конца интервала: ");
                if (float.TryParse(Console.ReadLine(), out lastPoint))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect value");
                }
            }
            if(firstPoint > lastPoint)
            {
                float val = firstPoint;
                firstPoint = lastPoint;
                lastPoint = val;
            }
            if(firstPoint == lastPoint)
            {
                Console.WriteLine("Начало и конец интервала равны");
                throw new Exception("firstPoint is lastPoint");
            }
            for (int i = 0; i < newArray.Length; i++)
            {
                float val = Math.Abs(newArray[i]);
                if(val > firstPoint && val < lastPoint)
                {
                    newArray[i] = 0;
                }
            }


            int ID = 0;
            for (int i = 0; i < newArray.Length; i++)
            {
                if (newArray[i] == 0)
                {
                    float o = newArray[ID];
                    newArray[ID] = newArray[i];
                    newArray[i] = o;
                    ID++;
                }
            }
            Array.Reverse(newArray);
            Console.WriteLine("Новый массив:");
            foreach (int i in newArray)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
