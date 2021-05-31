using System.Collections.Generic;

namespace Dev_Back.Api.Models
{
    public static class Stock
    {

        public static int RestockWhile(List<int> itemCount, int target)
        {
            int total = 0;
            int index = 0;
            while (true)
            {
                total += itemCount[index];
                index++;
                if (!(total <= target) || !(itemCount.Count > index))
                {
                     break;
                }

            }

            return total - target;
        }

        public static int RestockForEach(List<int> itemCount, int target)
        {
            int total = 0;

            foreach (int item in itemCount)
            {
                total += item;
                if (!(total <= target))
                {
                    break;
                }
            }

            return total - target;
        }

        public static int RestockFor(List<int> itemCount, int target)
        {
            int total = 0;

            for (int i = 0; i < itemCount.Count ; i++)
            {
                total += itemCount[i];
                if (!(total <= target))
                {
                    break;
                }
            }

            return total - target;
        }

        public static int RestockDo(List<int> itemCount, int target)
        {
            int total = 0;
            int index = 0;

            do
            {
                total += itemCount[index];
                index++;
            } while (total <= target && itemCount.Count > index);

            return total - target;
        }


    }
}
