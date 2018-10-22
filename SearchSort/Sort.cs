using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yarkon5779
{
    static partial class SearchAndSort
    {

        // מיון בחירה - פוקצייה עוטפת ציבורית
        public static void SortSelection1(int[] arr)
        {
            sortSelection1(arr, arr.Length - 1);
        }
        // מיון בחירה רקורסיבי
        private static void sortSelection1(int[] arr, int last)
        {
            if (last <= 0) // recursion stop condition תנאי העצירה של רקורסיה
                return;  // מערך בגודל 1 או פחות אין מה למיין 

            int index = findMax1(arr, last);
            if (index != last)
                swap(arr, index, last);
            sortSelection1(arr, last - 1);
        }

        // מיון בחירה לא רקורסיבי
        public static void SortSelection2(int[] arr)
        {
            // נתחיל בסוף המערך ונעבור במערך מהסוף להתחלה
            for (int i = arr.Length - 1; i >= 0; ++i)
            {
                // נמצא את האלמנט עם הערך המקסימלי בחלק של המערך עד האלמנט הנוכחי כולל
                int index = findMax1(arr, i);
                if (index != i) // אם האלמנט הנוכחי אינו מקסימלי
                    // נחליף ערכם בין האלמנט הנוכחי לאלמנט המקסימלי שמצאנו
                    // וכך נעביר את הערך המקסימלי לאלמנט הנוכחי
                    swap(arr, index, i);
            }
        }

        // מיון הכנסה
        public static void SortInsertion(int[] arr)
        {
            // נעבור על האלמנטים מהשני ועד סוף המערך
            for (int i = 1; i < arr.Length; ++i)
            {
                // נכניס את האלמנט לחלק במערך שלשמאלנו
                // נ.ב. החלק במערך שמשמאלנו יהיה כבר ממויין
                insertToSortedArray(arr, i, arr[i]);
            }
        }

        // הכנסה של ערך למערך ממוין
        private static void insertToSortedArray(int[] arr, int n, int num)
        {
            int i;
            // נחפש איפה להכניס מספר חדש במערך קיים ממוין
            for (i = 0; i < n && arr[i] < num; ++i);

            // נזיז ימינה את כל האלמנטים מהמקום שמצאנו ועד סוף המערך
            for (int j = n - 1; j >= i; --j)
                arr[j + 1] = arr[j];

            // נכניס את המספר החדש במקום שמצאנו
            arr[i] = num;
        }
        
        // מיון בועות אחרי שני ייעולים
        public static void BubbleSort(int[] arr)
        {
            bool done = false; // דגל שמסמן שעשינו מעבר בלי החלפות
            for (int i = arr.Length - 1; i >= 0 && !done; --i)
            {
                done = true; // עוד לא עשינו החלפות - נשים ערך של אמת לפני כניסה ללולאה הפנימית
                // for (int j = 0; j < arr.Length - 1; ++j) // לולאה על כל זוגות המערך בלי יעול
                for (int j = 0; j < i; ++j) // לולאה על כל זוגות המערך עם יעול קטן
                    if (arr[j] > arr[j + 1]) // אם אלמנט שמאלי גדול מאלמנט שלימינו אז
                    {
                        swap(arr, j, j + 1); // נחליף ערכים בין שני אלמנטים
                        // עשינו החלפה - לכן נסמן בדגל שעוד לא סיימנו את מיון הבועות
                        done = false;
                    }
            }
        }
    }
}
