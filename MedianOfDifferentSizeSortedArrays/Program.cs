using System;

namespace MedianOfDifferentSizeSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Find Median of different size sorted arrays!");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Enter the elements of the first array " +
                "separated by space");
            try
            {
                String[] elements = Console.ReadLine().Split(' ');
                Console.WriteLine("Enter the second array elements separated" +
                    " by space");
                String[] elementsStr = Console.ReadLine().Split(' ');
                int[] firstArray = GetIntArrayFromString(elements);
                int[] secondArray = GetIntArrayFromString(elementsStr);
                int median = GetMedian(firstArray, secondArray);
                Console.WriteLine("Median returned is "+median);

            }
            catch (Exception exception) {
                Console.WriteLine("Exception thrown is "+exception.Message);
            }


            Console.ReadLine();
        }

        private static int GetMedian(int[] firstArray, int[] secondArray) {
            int median = 0;

            int length1 = firstArray.Length;
            int length2 = secondArray.Length;

            if (length1 < length2) {
                return _GetMedian(firstArray, secondArray);
            }
            return _GetMedian(secondArray, firstArray);
        }

        private static int _GetMedian(int[] Array1, int[] Array2) {

            int minimumIndex = 0;
            int maximumIndex = Array1.Length;

            int partitionMarker1 = 0;
            int partitionMarker2 = 0;

            while (minimumIndex <= maximumIndex) {
                
                //LowerHalf
                partitionMarker1 = (minimumIndex + maximumIndex) / 2;
                //HigherHalf
                partitionMarker2 = (((Array1.Length + Array2.Length + 1) / 2) 
                    - partitionMarker1);

                if (partitionMarker1 < Array1.Length && partitionMarker2 > 0
                    && Array2[partitionMarker2 - 1] > Array1[partitionMarker1])
                {
                    minimumIndex = partitionMarker1 + 1;
                }
                else if (partitionMarker1 > 0 && partitionMarker2 < Array2.Length &&
                  Array2[partitionMarker2] < Array1[partitionMarker1 - 1])
                {
                    maximumIndex = partitionMarker1 - 1;
                }
                else {
                    if (partitionMarker1 == 0)
                    {
                        return Array2[partitionMarker2 - 1];
                    }
                    if (partitionMarker2 == 0)
                    {
                        return Array1[partitionMarker1 - 1];
                    }
                    return Math.Max(Array1[partitionMarker1-1], 
                        Array2[partitionMarker2-1]);
                }
            }
            return 0;
        }

        private static int[] GetIntArrayFromString(String[] elements) {
            int[] intArray = new int[elements.Length];
            for (int i = 0; i < elements.Length; i++) {
                intArray[i] = int.Parse(elements[i]);
            }
            return intArray;
        }
    }
}
