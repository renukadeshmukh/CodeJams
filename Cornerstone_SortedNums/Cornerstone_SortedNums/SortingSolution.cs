using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeCS
{
    public class SortingSolution
    {
        public List<int> SortNumericList(List<int> arr) {
            List<int> sortedList = new List<int>();
            for (int i = 0; i < arr.Count(); i++)
            {
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        //Swapping values
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
           return arr;
            
        }

        public void SortNumericListInPlace(List<int> arr)
        {
            List<int> sortedList = new List<int>();
            for (int i = 0; i < arr.Count(); i++)
            {
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        //Swapping values
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
           
        }

        public int GetProductOfAllValues(List<int> arr) {

            int product = 1;

            foreach (var item in arr)
            {
                if (item == 0)
                    return 0;
                product *= item;
            }
            return product;
        }
    }
}
