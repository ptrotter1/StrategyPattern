using Example01Sorting;

var dataset = new List<int> { 5, 2, 9, 1, 3 };
    
var context = new SortContext();
    
// Use bubble sort
context.SetSortStrategy(new BubbleSortStrategy());
var result1 = context.SortData(dataset);
Console.WriteLine("result1: " + string.Join(", ", result1));

// Switch to quick sort
context.SetSortStrategy(new QuickSortStrategy());
var result2 = context.SortData(dataset);
Console.WriteLine("result2: " + string.Join(", ", result2));