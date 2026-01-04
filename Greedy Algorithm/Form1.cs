/*
 * Matthew Foley
 * CST-201-O500
 * December 2025
 * Activity 6
 */
using System.Text;
using GreedyLibrary.Model;

namespace Greedy_Algorithm
{
    public partial class Form1 : Form
    {
        private StringBuilder AllInformation;
        public int TotalWeight = 280;
        public Form1()
        {
            AllInformation = new StringBuilder();
            InitializeComponent();
            AllInformation.Append("The List Of Items In The Inventory Are;");
            AllInformation.AppendLine();
            List<ItemModel> totalItems = new List<ItemModel>();
            List<ItemModel> testingList = new List<ItemModel>();
            totalItems.Add(new ItemModel { Name = "Item 1", Price = 70, Weight = 20, Amount = 1 });
            totalItems.Add(new ItemModel { Name = "Item 2", Price = 80, Weight = 30, Amount = 2 });
            totalItems.Add(new ItemModel { Name = "Item 3", Price = 90, Weight = 40, Amount = 1 });
            totalItems.Add(new ItemModel { Name = "Item 4", Price = 110, Weight = 60, Amount = 3 });
            totalItems.Add(new ItemModel { Name = "Item 5", Price = 120, Weight = 70, Amount = 1 });
            totalItems.Add(new ItemModel { Name = "Item 6", Price = 200, Weight = 90, Amount = 2 });
            foreach (ItemModel item in totalItems)
            {
                AllInformation.AppendLine(item.Name + " with A Price Of " + item.Price + " And A Weight Of " + item.Weight + "; There are " + item.Amount+" In Stock");

            }            
            AllInformation.AppendLine("Without Considering Stock The Sorted Lists In Question Are:");
            AllInformation.AppendLine("----------------------------------------------------------------------------");
            AllInformation.AppendLine("The First List is");

            List<ItemModel> CheckedList = totalItems;
            CheckedList.Reverse();
            int FinalWeight = TotalWeight;
            int FinalCost = 0;
            List<ItemModel> tempList = new List<ItemModel>();
            foreach (ItemModel item in CheckedList)
            {
                if (FinalWeight-item.Weight >= 0)
                {
                         FinalWeight = FinalWeight - item.Weight;
                         tempList.Add(item);
                         FinalCost += item.Price;
                }
            }
            foreach(ItemModel item in tempList)
            {
                AllInformation.AppendLine(item.Name + " with A Price Of " + item.Price + " And A Weight Of " + item.Weight + "; There are " + item.Amount + " In Stock");
            }
            AllInformation.AppendLine("There Is A Left Over Weight Of: " + FinalWeight);
            AllInformation.AppendLine("There Is A Total Of $" + FinalCost + " In the Bag");
            List<ItemModel> FinalList = tempList;
            List<ItemModel> SecondTempList = new List<ItemModel>();
            tempList = totalItems;
            tempList.RemoveAt(0);
            int tempPrice = 0;
            int TempWeight = TotalWeight;


            AllInformation.AppendLine("----------------------------------------------------------------------------");
            AllInformation.AppendLine("The Second List is");            
            foreach(ItemModel item in tempList)
            {
                while (TempWeight - item.Weight >= 0)
                {
                    if (TempWeight - item.Weight >= 0)
                    {
                        SecondTempList.Add(item);
                        TempWeight = TempWeight - item.Weight;
                        tempPrice += item.Price;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            foreach (ItemModel item in SecondTempList)
            {
                AllInformation.AppendLine(item.Name + " with A Price Of " + item.Price + " And A Weight Of " + item.Weight + "; There are " + item.Amount + " In Stock");
            }
            AllInformation.AppendLine("There Is A Total Of $" + tempPrice + " In the Bag");
            if (tempPrice>FinalCost)
            {
                FinalList = SecondTempList;
                FinalCost = tempPrice;
                FinalWeight = TempWeight;
            }
            SecondTempList.Clear();
            tempList = totalItems;
            tempList.RemoveAt(0);
            tempPrice = 0;
            TempWeight = TotalWeight;


            AllInformation.AppendLine("----------------------------------------------------------------------------");
            AllInformation.AppendLine("The Third List is");
            foreach (ItemModel item in tempList)
            {
                while (TempWeight - item.Weight >= 0)
                {
                    if (TempWeight - item.Weight >= 0)
                    {
                        SecondTempList.Add(item);
                        TempWeight = TempWeight - item.Weight;
                        tempPrice += item.Price;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            foreach (ItemModel item in SecondTempList)
            {
                AllInformation.AppendLine(item.Name + " with A Price Of " + item.Price + " And A Weight Of " + item.Weight + "; There are " + item.Amount + " In Stock");
            }
            AllInformation.AppendLine("There Is A Left Over Weight Of: " + TempWeight);
            AllInformation.AppendLine("There Is A Total Of $" + tempPrice + " In the Bag");
            if (tempPrice > FinalCost)
            {
                FinalList = SecondTempList;
                FinalCost = tempPrice;
                FinalWeight = TempWeight;
            }
            SecondTempList.Clear();
            tempList = totalItems;
            tempList.RemoveAt(0);
            tempPrice = 0;
            TempWeight = TotalWeight;


            AllInformation.AppendLine("----------------------------------------------------------------------------");
            AllInformation.AppendLine("The Fourth List is");
            foreach (ItemModel item in tempList)
            {
                while (TempWeight - item.Weight >= 0)
                {
                    if (TempWeight - item.Weight >= 0)
                    {
                        SecondTempList.Add(item);
                        TempWeight = TempWeight - item.Weight;
                        tempPrice += item.Price;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            foreach (ItemModel item in SecondTempList)
            {
                AllInformation.AppendLine(item.Name + " with A Price Of " + item.Price + " And A Weight Of " + item.Weight + "; There are " + item.Amount + " In Stock");
            }
            AllInformation.AppendLine("There Is A Left Over Weight Of: " + TempWeight);
            AllInformation.AppendLine("There Is A Total Of $" + tempPrice + " In the Bag");
            if (tempPrice > FinalCost)
            {
                FinalList = SecondTempList;
                FinalCost = tempPrice;
                FinalWeight = TempWeight;
            }
            SecondTempList.Clear();
            tempList = totalItems;
            tempList.RemoveAt(0);
            tempPrice = 0;
            TempWeight = TotalWeight;


            AllInformation.AppendLine("----------------------------------------------------------------------------");
            AllInformation.AppendLine("The Fith List is");
            foreach (ItemModel item in tempList)
            {
                while (TempWeight - item.Weight >= 0)
                {
                    if (TempWeight - item.Weight >= 0)
                    {
                        SecondTempList.Add(item);
                        TempWeight = TempWeight - item.Weight;
                        tempPrice += item.Price;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            foreach (ItemModel item in SecondTempList)
            {
                AllInformation.AppendLine(item.Name + " with A Price Of " + item.Price + " And A Weight Of " + item.Weight + "; There are " + item.Amount + " In Stock");
            }
            AllInformation.AppendLine("There Is A Left Over Weight Of: " + TempWeight);
            AllInformation.AppendLine("There Is A Total Of $" + tempPrice + " In the Bag");
            if (tempPrice > FinalCost)
            {
                FinalList = SecondTempList;
                FinalCost = tempPrice;
                FinalWeight = TempWeight;
            }


            AllInformation.AppendLine("----------------------------------------------------------------------------");
            AllInformation.AppendLine("The Sixth List is");
            SecondTempList.Clear();
            tempList = totalItems;
            tempList.RemoveAt(0);
            tempPrice = 0;
            TempWeight = TotalWeight;
            foreach (ItemModel item in tempList)
            {
                while (TempWeight - item.Weight >= 0)
                {
                    if (TempWeight - item.Weight >= 0)
                    {
                        SecondTempList.Add(item);
                        TempWeight = TempWeight - item.Weight;
                        tempPrice += item.Price;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            foreach (ItemModel item in SecondTempList)
            {
                AllInformation.AppendLine(item.Name + " with A Price Of " + item.Price + " And A Weight Of " + item.Weight + "; There are " + item.Amount + " In Stock");
            }
            AllInformation.AppendLine("There Is A Left Over Weight Of: " + TempWeight);
            AllInformation.AppendLine("There Is A Total Of $" + tempPrice + " In the Bag");
            if (tempPrice > FinalCost)
            {
                FinalList = SecondTempList;
                FinalCost = tempPrice;
                FinalWeight = TempWeight;
            }


            AllInformation.AppendLine("----------------------------------------------------------------------------");
            AllInformation.AppendLine("The Final List is");
            foreach (ItemModel item in FinalList)
            {
                AllInformation.AppendLine(item.Name + " with A Price Of " + item.Price + " And A Weight Of " + item.Weight + "; There are " + item.Amount + " In Stock");
            }
            AllInformation.AppendLine("There Is A Left Over Weight Of: " + FinalWeight);
            AllInformation.AppendLine("There Is A Total Of $" + FinalCost + " In the Bag");
            AllInformation.AppendLine("----------------------------------------------------------------------------");
            AllInformation.AppendLine("If We Consider The Amount Of Stock In Them, Then Our Lists Will Look Much Diffrent");
            AllInformation.AppendLine("----------------------------------------------------------------------------");
            AllInformation.AppendLine("The First List is:");
            totalItems = new List<ItemModel>();
            totalItems.Add(new ItemModel { Name = "Item 1", Price = 70, Weight = 20, Amount = 1 });
            totalItems.Add(new ItemModel { Name = "Item 2", Price = 80, Weight = 30, Amount = 2 });
            totalItems.Add(new ItemModel { Name = "Item 3", Price = 90, Weight = 40, Amount = 1 });
            totalItems.Add(new ItemModel { Name = "Item 4", Price = 110, Weight = 60, Amount = 3 });
            totalItems.Add(new ItemModel { Name = "Item 5", Price = 120, Weight = 70, Amount = 1 });
            totalItems.Add(new ItemModel { Name = "Item 6", Price = 200, Weight = 90, Amount = 2 });
            tempList = totalItems;
            tempPrice = 0;
            TempWeight = TotalWeight;
            FinalWeight = TotalWeight;
            FinalCost = 0;
            FinalList.Clear();
            int endLoop = 0;
            foreach(ItemModel item in tempList)
            {
                endLoop = item.Amount;
                while (endLoop > 0)
                {
                    if (TempWeight - item.Weight >= 0)
                    {
                        SecondTempList.Add(item);
                        TempWeight = TempWeight - item.Weight;
                        tempPrice += item.Price;
                    }
                    endLoop--;
                }
            }
            foreach (ItemModel item in SecondTempList)
            {
                AllInformation.AppendLine(item.Name + " with A Price Of " + item.Price + " And A Weight Of " + item.Weight + "; There are " + item.Amount + " In Stock");
            }
            AllInformation.AppendLine("There Is A Left Over Weight Of: " + TempWeight);
            AllInformation.AppendLine("There Is A Total Of $" + tempPrice + " In the Bag");
            AllInformation.AppendLine("----------------------------------------------------------------------------");
            AllInformation.AppendLine("The Second List is:");
            if (tempPrice > FinalCost)
            {
                FinalList.Clear();
                FinalList = SecondTempList;
                FinalList = FinalList;
                FinalCost = tempPrice;
                FinalWeight = TempWeight;
            }
            SecondTempList.Clear();
            tempList = totalItems;
            tempList.RemoveAt(0);
            tempPrice = 0;
            TempWeight = TotalWeight;
            foreach (ItemModel item in tempList)
            {
                endLoop = item.Amount;
                while (endLoop > 0)
                {
                    if (TempWeight - item.Weight >= 0)
                    {
                        FinalList.Clear();
                        SecondTempList.Add(item);
                        TempWeight = TempWeight - item.Weight;
                        tempPrice += item.Price;
                    }
                    endLoop--;
                }
            }
            foreach (ItemModel item in SecondTempList)
            {
                AllInformation.AppendLine(item.Name + " with A Price Of " + item.Price + " And A Weight Of " + item.Weight + "; There are " + item.Amount + " In Stock");
            }
            AllInformation.AppendLine("There Is A Left Over Weight Of: " + TempWeight);
            AllInformation.AppendLine("There Is A Total Of $" + tempPrice + " In the Bag");
            AllInformation.AppendLine("----------------------------------------------------------------------------");
            AllInformation.AppendLine("The Third List is:");
            if (tempPrice > FinalCost)
            {
                FinalList.Clear();
                FinalList = SecondTempList;
                FinalList = FinalList;
                FinalCost = tempPrice;
                FinalWeight = TempWeight;
            }
            SecondTempList.Clear();
            tempList = totalItems;
            tempList.RemoveAt(0);
            tempPrice = 0;
            TempWeight = TotalWeight;
            foreach (ItemModel item in tempList)
            {
                endLoop = item.Amount;
                while (endLoop > 0)
                {
                    if (TempWeight - item.Weight >= 0)
                    {
                        FinalList.Clear();
                        SecondTempList.Add(item);
                        TempWeight = TempWeight - item.Weight;
                        tempPrice += item.Price;
                    }
                    endLoop--;
                }
            }
            foreach (ItemModel item in SecondTempList)
            {
                AllInformation.AppendLine(item.Name + " with A Price Of " + item.Price + " And A Weight Of " + item.Weight + "; There are " + item.Amount + " In Stock");
            }
            AllInformation.AppendLine("There Is A Left Over Weight Of: " + TempWeight);
            AllInformation.AppendLine("There Is A Total Of $" + tempPrice + " In the Bag");
            if (tempPrice > FinalCost)
            {
                FinalList = SecondTempList;
                FinalCost = tempPrice;
                FinalWeight = TempWeight;
            }
            AllInformation.AppendLine("----------------------------------------------------------------------------");
            AllInformation.AppendLine("The Fourth List is:");
            tempList.Clear();
            totalItems.Clear();
            SecondTempList.Clear();
            totalItems = new List<ItemModel>();
            totalItems.Add(new ItemModel { Name = "Item 1", Price = 70, Weight = 20, Amount = 1 });
            totalItems.Add(new ItemModel { Name = "Item 2", Price = 80, Weight = 30, Amount = 2 });
            totalItems.Add(new ItemModel { Name = "Item 3", Price = 90, Weight = 40, Amount = 1 });
            totalItems.Add(new ItemModel { Name = "Item 4", Price = 110, Weight = 60, Amount = 3 });
            totalItems.Add(new ItemModel { Name = "Item 5", Price = 120, Weight = 70, Amount = 1 });
            totalItems.Add(new ItemModel { Name = "Item 6", Price = 200, Weight = 90, Amount = 2 });
            tempList = totalItems;
            tempList.Reverse();
            tempPrice = 0;
            TempWeight = TotalWeight;

             endLoop = 0;
            foreach (ItemModel item in tempList)
            {
                endLoop = item.Amount;
                while (endLoop > 0)
                {
                    if (TempWeight - item.Weight >= 0)
                    {
                        SecondTempList.Add(item);
                        testingList.Add(item);
                        TempWeight = TempWeight - item.Weight;
                        tempPrice += item.Price;
                    }
                    endLoop--;
                }
            }            

            foreach (ItemModel item in SecondTempList)
            {
                AllInformation.AppendLine(item.Name + " with A Price Of " + item.Price + " And A Weight Of " + item.Weight + "; There are " + item.Amount + " In Stock");
            }
            AllInformation.AppendLine("There Is A Left Over Weight Of: " + TempWeight);
            AllInformation.AppendLine("There Is A Total Of $" + tempPrice + " In the Bag");
            if (tempPrice > FinalCost)
            {
                FinalList = SecondTempList;
                FinalCost = tempPrice;
                FinalWeight = TempWeight;
            }
            AllInformation.AppendLine("----------------------------------------------------------------------------");
            AllInformation.AppendLine("The Fith List is:");
            tempList = totalItems;
            SecondTempList.Clear();
            tempList.RemoveAt(0);
            tempPrice = 0;
            TempWeight = TotalWeight;

            endLoop = 0;
            foreach (ItemModel item in tempList)
            {
                endLoop = item.Amount;
                while (endLoop > 0)
                {
                    if (TempWeight - item.Weight >= 0)
                    {
                        SecondTempList.Add(item);
                        TempWeight = TempWeight - item.Weight;
                        tempPrice += item.Price;
                    }
                    endLoop--;
                }
            }
            foreach (ItemModel item in SecondTempList)
            {
                AllInformation.AppendLine(item.Name + " with A Price Of " + item.Price + " And A Weight Of " + item.Weight + "; There are " + item.Amount + " In Stock");
            }
            AllInformation.AppendLine("There Is A Left Over Weight Of: " + TempWeight);
            AllInformation.AppendLine("There Is A Total Of $" + tempPrice + " In the Bag");

            AllInformation.AppendLine("----------------------------------------------------------------------------");
            AllInformation.AppendLine("The Sixth List is:");
            tempList.RemoveAt(0);
            tempList.RemoveAt(0);
            SecondTempList.Clear();
            tempPrice = 0;
            TempWeight = TotalWeight;

            endLoop = 0;
            foreach (ItemModel item in tempList)
            {
                endLoop = item.Amount;
                while (endLoop > 0)
                {
                    if (TempWeight - item.Weight >= 0)
                    {
                        SecondTempList.Add(item);
                        TempWeight = TempWeight - item.Weight;
                        tempPrice += item.Price;
                    }
                    endLoop--;
                }
            }
            foreach (ItemModel item in SecondTempList)
            {
                AllInformation.AppendLine(item.Name + " with A Price Of " + item.Price + " And A Weight Of " + item.Weight + "; There are " + item.Amount + " In Stock");
            }
            AllInformation.AppendLine("There Is A Left Over Weight Of: " + TempWeight);
            AllInformation.AppendLine("There Is A Total Of $" + tempPrice + " In the Bag");
            AllInformation.AppendLine("----------------------------------------------------------------------------");
            AllInformation.AppendLine("The Final List is");
            AllInformation.AppendLine("The Final List is");
            SecondTempList.Clear();

            foreach (ItemModel item in testingList)
            {
                AllInformation.AppendLine(item.Name + " with A Price Of " + item.Price + " And A Weight Of " + item.Weight + "; There are " + item.Amount + " In Stock");
            }
            AllInformation.AppendLine("There Is A Left Over Weight Of: " + FinalWeight);
            AllInformation.AppendLine("There Is A Total Of $" + FinalCost + " In the Bag");

            rtxtSolution.Text = AllInformation.ToString();
        }

    }
}