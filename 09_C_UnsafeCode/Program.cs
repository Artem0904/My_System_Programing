using System.Drawing;
using System.Runtime.Intrinsics.X86;

namespace _09_C_UnsafeCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            unsafe void PrintArr(int* arr, int size)
            {
                for (int* ptr = arr; ptr < arr + size; ptr++)
                {
                    Console.WriteLine(*ptr);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            unsafe
            {
                Console.Write("Enter size 1 : ");
                int size1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter size 2 : ");
                int size2 = Convert.ToInt32(Console.ReadLine());

                int* arr1 = stackalloc int[size1];
                int* arr2 = stackalloc int[size2];

                for (int* ptr1 = arr1; ptr1 < arr1 + size1; ptr1++)
                {
                    *ptr1 = new Random().Next(1, 100);
                }
                for (int* ptr2 = arr2; ptr2 < arr2 + size2; ptr2++)
                {
                    *ptr2 = new Random().Next(1, 100);
                }

                int* arrRes = stackalloc int[size1 + size2];

                for (int* ptr1 = arr1, ptrRes = arrRes; ptr1 < arr1 + size1; ptr1++, ptrRes++)
                {
                    *ptrRes = *ptr1;
                }

                for (int* ptr2 = arr2, ptrRes = arrRes + size2 - 1; ptrRes < arrRes + size2 + size2; ptr2++, ptrRes++)
                {
                    *ptrRes = *ptr2;
                }

                PrintArr(arr1, size1);
                PrintArr(arr2, size2);
                PrintArr(arrRes, size1 + size2);



            }

        }
    }
}