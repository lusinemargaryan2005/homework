namespace MyBubleSort
{
    public class MyInsertionSort<T> where T : IComparable<T>
    {
        public void Sort(T[] items)
        {
            if (items == null || items.Length <= 1) return;
            for (int i = 1; i < items.Length; i++)
            {
                T key = items[i]; // վերցնում ենք նոր փոփոխական որի մեջ դնում ենք մեր itemի Iրդ ինդեքսում գտնվող տարրը
                int j = i - 1; // տալիս ենք մեր նախորդ ինդեքսը
                while (j >= 0 && items[j].CompareTo(key) > 0) //մինչդեռ մեր նախորդ ինդեքսը մեծ կամ հավասար է 0ի և նախորդ էլեմենտը մեծ է թե որ
                {
                    items[j + 1] = items[j]; //գնում է մի հատ աջ 
                    j--;// հետ գնա նախորդ ինդեքս
                }
                items[j + 1] = key; //սա էլ վերջինի համար է
            }
        }
    }
}












//Lusine Margaryan