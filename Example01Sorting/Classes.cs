namespace Example01Sorting;

// 1. Define the strategy interface
public interface ISortStrategy
{
    List<int> Sort(List<int> dataset);
}

// 2. Implement concrete strategies
public class BubbleSortStrategy : ISortStrategy
{
    public List<int> Sort(List<int> dataset)
    {
        // Bubble sort implementation
        for (int i = 0; i < dataset.Count - 1; i++)
        {
            for (int j = 0; j < dataset.Count - i - 1; j++)
            {
                if (dataset[j] > dataset[j + 1])
                {
                    // Swap
                    var temp = dataset[j];
                    dataset[j] = dataset[j + 1];
                    dataset[j + 1] = temp;
                }
            }
        }
        return dataset;
    }
}

public class QuickSortStrategy : ISortStrategy
{
    public List<int> Sort(List<int> dataset)
    {
        // Quick sort implementation
        if (dataset.Count <= 1)
            return dataset;
        var pivot = dataset[dataset.Count / 2];
        var left = dataset.Where(x => x < pivot).ToList();
        var right = dataset.Where(x => x > pivot).ToList();
        return Sort(left).Concat(new List<int> { pivot }).Concat(Sort(right)).ToList();
    }
}

// 3. Context class that uses a strategy
public class SortContext
{
    private ISortStrategy _sortStrategy;

    public void SetSortStrategy(ISortStrategy sortStrategy)
    {
        _sortStrategy = sortStrategy;
    }

    public List<int> SortData(List<int> dataset)
    {
        return _sortStrategy.Sort(dataset);
    }
}