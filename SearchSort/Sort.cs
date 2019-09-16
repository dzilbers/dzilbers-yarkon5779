namespace SearchSort
{
    public static partial class SearchAndSort
    {
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

        // מיון הכנסה
        public static void SortInsertion1(int[] arr)
        {
            // נעבור על האלמנטים מהשני ועד סוף המערך
            for (int i = 1; i < arr.Length; ++i)
            {
                // נכניס את האלמנט לחלק במערך שלשמאלנו
                // נ.ב. החלק במערך שמשמאלנו יהיה כבר ממויין
                insertToSortedArray(arr, i, arr[i]);
            }
        }

        public static void SortInsertion2(int[] arr)
        {
            for (int i = 1; i < arr.Length; ++i)
                for (int j = i; j > 0 && arr[j] < arr[j - 1]; --j)
                    swap(arr, j, j - 1);
        }

        public static void SortInsertion3(int[] arr)
        {
            for (int i = 1; i < arr.Length; ++i)
            {
                int temp = arr[i];

                int j;
                for (j = i - 1; j >= 0 && temp < arr[j]; --j)
                    arr[j + 1] = arr[j];

                arr[j + 1] = temp;
            }
        }

        // מיון בחירה רגיל
        public static void SortSelection1(int[] arr)
        {
            // נתחיל בסוף המערך ונעבור במערך מהסוף להתחלה
            for (int i = arr.Length - 1; i >= 0; --i)
            {
                // נמצא את האלמנט עם הערך המקסימלי בחלק של המערך עד האלמנט הנוכחי כולל
                int index = findMax1(arr, i); // הפונקציה מחזירה אינדקס של האלמנט עם הערך הגדול
                if (index != i) // אם האלמנט הנוכחי אינו מקסימלי
                {
                    // נחליף ערכם בין האלמנט הנוכחי לאלמנט המקסימלי שמצאנו
                    // וכך נעביר את הערך המקסימלי לאלמנט הנוכחי
                    swap(arr, index, i);
                }
            }
        }

        // מיון בועות אחרי שני ייעולים
        public static void BubbleSort1(int[] arr)
        {
            for (int i = arr.Length; i > 0; --i)
            {
                for (int j = 0; j < arr.Length - 1; ++j) // לולאה על כל זוגות המערך בלי יעול
                    if (arr[j] > arr[j + 1]) // אם אלמנט שמאלי גדול מאלמנט שלימינו אז
                        swap(arr, j, j + 1); // נחליף ערכים בין שני אלמנטים
            }
        }

        // מיון בועות אחרי שני ייעולים
        public static void BubbleSort2(int[] arr)
        {
            for (int i = arr.Length; i > 0; --i)
            {
                for (int j = 0; j < i - 1; ++j) // לולאה על כל זוגות המערך עם יעול קטן
                    if (arr[j] > arr[j + 1]) // אם אלמנט שמאלי גדול מאלמנט שלימינו אז
                        swap(arr, j, j + 1); // נחליף ערכים בין שני אלמנטים
            }
        }

        // מיון בועות אחרי שני ייעולים
        public static void BubbleSort3(int[] arr)
        {
            bool done = false; // דגל שמסמן שעשינו מעבר בלי החלפות
            for (int i = arr.Length - 1; i >= 0 && !done; --i)
            {
                done = true; // עוד לא עשינו החלפות - נשים ערך של אמת לפני כניסה ללולאה הפנימית
                // for (int j = 0; j < arr.Length - 1; ++j) // לולאה על כל זוגות המערך בלי יעול
                for (int j = 0; j < i; ++j) // לולאה על כל זוגות המערך עם יעול קטן
                {
                    if (arr[j] > arr[j + 1]) // אם אלמנט שמאלי גדול מאלמנט שלימינו אז
                    {
                        swap(arr, j, j + 1); // נחליף ערכים בין שני אלמנטים
                        // עשינו החלפה - לכן נסמן בדגל שעוד לא סיימנו את מיון הבועות
                        done = false;
                    }
                }
            }
        }

        // מיון בועות אחרי שני ייעולים
        public static void BubbleSort4(int[] arr)
        {
            int max = arr.Length - 1; // דגל שמסמן שעשינו מעבר בלי החלפות
            for (int i = arr.Length - 1; i >= 0 && max > 0; --i)
            {
                int top = max;
                for (int j = 0; j < top; ++j) // לולאה על כל זוגות המערך עם יעול קטן
                {
                    if (arr[j] > arr[j + 1]) // אם אלמנט שמאלי גדול מאלמנט שלימינו אז
                    {
                        swap(arr, j, j + 1); // נחליף ערכים בין שני אלמנטים
                        // עשינו החלפה - לכן נסמן בדגל שעוד לא סיימנו את מיון הבועות
                        max = j;
                    }
                }
            }
        }

        // אלגוריתמים רקורסיביים

        // מיון בחירה - פוקצייה עוטפת ציבורית
        public static void SortSelectionRecursive(int[] arr)
        {
            SortSelectionRecursive(arr, arr.Length - 1);
        }
        // מיון בחירה רקורסיבי
        private static void SortSelectionRecursive(int[] arr, int last)
        {
            if (last <= 0) // recursion stop condition תנאי העצירה של רקורסיה
            {
                return;  // מערך בגודל 1 או פחות אין מה למיין 
            }

            int index = findMax1(arr, last);
            if (index != last)
            {
                swap(arr, index, last);
            }

            SortSelectionRecursive(arr, last - 1);
        }

    }
}
