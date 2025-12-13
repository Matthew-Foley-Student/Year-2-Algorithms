/*
 * Matthew Foley
 * CST-201-O500
 * December 2025
 * Activity 4
 */
using System.Linq.Expressions;
using System.Text;

namespace Commparing_Sorting
{
    public partial class Form1 : Form
    {
        private StringBuilder AllInformation;
        public Form1()
        {
            InitializeComponent();
            rdo10.Checked = true;
            rdoL10.Checked = true;
        }

        private void RunTheProgram(object sender, EventArgs e)
        {
            AllInformation = new StringBuilder();
            int max =10;
            int startingListNumber = 0;
            int ListSize=0;
            int ListNumber = 1;
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Random Number Generation Settere
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            if (rdo10.Checked == true)
            {
                max = 10;
            }
            if (rdo20.Checked == true)
            {
                max = 20;
            }
            if (rdo30.Checked == true)
            {
                max = 30;
            }
            if (rdo40.Checked == true)
            {
                max = 40;
            }
            if (rdo50.Checked == true)
            {
                max = 50;
            }
            if (rdo60.Checked == true)
            {
                max = 60;
            }
            if (rdo70.Checked == true)
            {
                max = 70;
            }
            if (rdo80.Checked == true)
            {
                max = 80;
            }
            if (rdo90.Checked == true)
            {
                max = 90;
            }
            if (rdo100.Checked == true)
            {
                max = 100;
            }
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //List Size Setter
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            if (rdoL10.Checked == true)
            {
                ListSize = 10;
            }
            if (rdoL20.Checked == true)
            {
                ListSize = 20;
            }
            if (rdoL30.Checked == true)
            {
                ListSize = 30;
            }
            if (rdoL40.Checked == true)
            {
                ListSize = 40;
            }
            if (rdoL50.Checked == true)
            {
                ListSize = 50;
            }
            if (rdoL60.Checked == true)
            {
                ListSize = 60;
            }
            if (rdoL70.Checked == true)
            {
                ListSize = 70;
            }
            if (rdoL80.Checked == true)
            {
                ListSize = 80;
            }
            if (rdoL90.Checked == true)
            {
                ListSize = 90;
            }
            if (rdoL100.Checked == true)
            {
                ListSize = 100;
            }
            int fnlBuble= 0 ;
            int fnlSelection = 0;
            int fnlMerge = 0;
            int fnlQuick = 0;
            for (int RandoListMaker = 0; RandoListMaker < 100; RandoListMaker++)
            {
                List<int> sortingList = new List<int>();
                List<int> sortedList;
                startingListNumber = 0;
                while (startingListNumber < ListSize)
                {
                    Random rand = new Random();
                    sortingList.Add(rand.Next(0, max));
                    startingListNumber++;
                }
                AllInformation.AppendLine("List : " + ListNumber);
                foreach (int i in sortingList)
                {
                    AllInformation.Append(i + ",");
                }
                sortedList = sortingList.ToList();
                int bubble = BubbleSort(sortedList, sortedList.Count());                
                fnlBuble += bubble;
                sortedList = sortingList.ToList();
                int Selection = SelectionSort(sortedList);
                fnlSelection += Selection;
                sortedList = sortingList.ToList();
                int Merge = mergeSort(sortedList, 0, sortedList.Count - 1);
                fnlMerge += Merge;
                sortedList = sortingList.ToList();
                int quickList= quickSort(sortedList, 0, sortedList.Count - 1);
                fnlQuick += quickList;
                AllInformation.AppendLine();
                AllInformation.AppendLine();
                AllInformation.AppendLine("The amount of times the Buble List Check is : " + bubble);
                AllInformation.AppendLine("The amounnt of times the Selelection List Check is : " + Selection);
                AllInformation.AppendLine("The amount of times the MergeSort List Check is : " + Merge);
                AllInformation.AppendLine("The amount of times the QuickSort List Check is : " + quickList);
                AllInformation.AppendLine("-----------------------------------------------------------------------------------------------------------------------------------------------");
                AllInformation.AppendLine();
                ListNumber++;
            }//End of Making the RichTextBoxList
            fnlBuble = fnlBuble / 100;
            fnlSelection = fnlSelection / 100;
            fnlMerge = fnlMerge / 100;
            fnlQuick = fnlQuick / 100;
            AllInformation.AppendLine();
            AllInformation.AppendLine("The List Size In Question Is " + ListSize);
            AllInformation.AppendLine("The Avereidge Comparisons For The BUBBLE SORT Is : " + fnlBuble);
            AllInformation.AppendLine("The Averidge Comparison For SELECTION SORTING Is : " + fnlSelection);
            AllInformation.AppendLine("The Averidge Comparison For MERGE SORTING Is : " + fnlMerge);
            AllInformation.AppendLine("The Averidge Comparison For QUICK SORTING Is : " + fnlQuick);
            rtxtshown.Text = AllInformation.ToString();
        }//End Of the Running Button Clicker

        static int BubbleSort(List<int> insertedList, int x)
        {
            int swap=0;
            int i, j, temp;
            bool swapped;
            for (i = 0; i < x - 1; i++)
            {
                swapped = false;
                for (j = 0; j < x - i - 1; j++)
                {
                    if (insertedList[j] > insertedList[j + 1])
                    {
                        temp = insertedList[j];
                        insertedList[j] = insertedList[j + 1];
                        insertedList[j + 1] = temp;
                        swap++;
                        swapped = true;
                    }
                }

                // If no two elements were
                // swapped by inner loop, then break
                if (swapped == false)
                    break;
            }
            return swap;
        }

        static int SelectionSort(List<int> insertedList)
        {
            int n = insertedList.Count;
            int swap = 0;
            for (int i = 0; i < n - 1; i++)
            {

                // Assume the current position holds
                // the minimum element
                int min_idx = i;

                // Iterate through the unsorted portion
                // to find the actual minimum
                for (int j = i + 1; j < n; j++)
                {
                    if (insertedList[j] < insertedList[min_idx])
                    {

                        // Update min_idx if a smaller element
                        // is found
                        min_idx = j;
                        swap++;
                    }
                }

                // Move minimum element to its
                // correct position
                int temp = insertedList[i];
                insertedList[i] = insertedList[min_idx];
                insertedList[min_idx] = temp;
                swap++;
            }
            return swap;
        }
        static int merge(List<int> insertedList, int l, int m, int r)
        {

            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;
            int swap = 0;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = insertedList[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = insertedList[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    insertedList[k] = L[i];
                    i++;
                    swap++;
                }
                else
                {
                    insertedList[k] = R[j];
                    j++;
                    swap++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                insertedList[k] = L[i];
                i++;
                k++;
                swap++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                insertedList[k] = R[j];
                j++;
                k++;
                swap++;
            }
            return swap;
        }
        static int mergeSort(List<int> insertedList, int l, int r)
        {
            int swap = 0;
            if (l < r)
            {

                // Find the middle point
                int m = l + (r - l) / 2;

                // Sort first and second halves
                swap += mergeSort(insertedList, l, m);
                swap+=mergeSort(insertedList, m + 1, r);

                // Merge the sorted halves
               swap += merge(insertedList, l, m, r);
            }
            return swap;
        }

        static int partition(List<int> insertedList, int low, int high, out int numSwap)
        {

            // choose the pivot
            int pivot = insertedList[high];
            numSwap = 0;

            // index of smaller element and indicates 
            // the right position of pivot found so far
            int i = low - 1;

            // traverse arr[low..high] and move all smaller
            // elements to the left side. Elements from low to 
            // i are smaller after every iteration
            for (int j = low; j <= high - 1; j++)
            {
                if (insertedList[j] < pivot)
                {
                    i++;
                    QuickSwap(insertedList, i, j);
                    numSwap++;
                }
            }

            // move pivot after smaller elements and
            // return its position
            QuickSwap(insertedList, i + 1, high);
            return i + 1;
        }
        static void QuickSwap(List<int> insertedList, int i, int j)
        {
            int temp = insertedList[i];
            insertedList[i] = insertedList[j];
            insertedList[j] = temp;
        }
        static int quickSort(List<int> insertedList, int low, int high)
        {
            int swapnum = 0;
            int numSwap;
            if (low < high)
            {

                // pi is the partition return index of pivot
                int pi = partition(insertedList, low, high,out numSwap);

                // recursion calls for smaller elements
                // and greater or equals elements
                swapnum += numSwap;
                swapnum+=quickSort(insertedList, low, pi - 1);
                swapnum += quickSort(insertedList, pi + 1, high);
            }
            return swapnum;
        }

    }
}
