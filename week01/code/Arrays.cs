public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
       //Plan (step-by-step):
       //validate input: 'length' muat be >0 (as per problem statement).If not, throw an exception.
       //Create a result array of size 'length'
       //Fill the array so that position i (0-based) contains number * (i + 1)
       //  - i = 0 => number * 1
       //  - i = 1 => number * 2
       //   - ...
       //   - i = length - 1 => number * length
       // Return the filled array.

       if (length <= 0)
        throw new ArgumentOutOfRangeException(nameof(length), "length must be greater than 0.");
        var result = new double[length];
        for (int i = 0; i < length; i++)
        { 
            result[i] = number * (i + 1); 
        } 
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN (step-by-step) — segmentation approach using GetRange/RemoveRange/InsertRange: 
        // 1) Validate input: if 'data' is null => throw; if data.Count == 0 => nothing to do; if amount == 0 => nothing to do. 
        // 2) Normalize 'amount' with modulo: amount %= data.Count. Full rotations leave the list unchanged. 
        // If after normalization amount == 0 => return. 
        // 3) Compute split index: split = data.Count - amount. 
        // This split separates the list into:
        // - tail = last 'amount' elements (to move to the front) 
        // - head = the rest (to remain after the tail)
        // 4) Extract tail with data.GetRange(split, amount).
        // 5) Remove that tail from the end using data.RemoveRange(split, amount). 
        // 6) Insert the tail at the beginning using data.InsertRange(0, tail).
        // 7) The list 'data' is modified in place as required. 

        
        if (data == null) throw new ArgumentNullException(nameof(data)); 
        int n = data.Count;
        if (n == 0 || amount == 0) return;
        amount %= n; 
        if (amount == 0) return;
        int split = n - amount;
        var tail = data.GetRange(split, amount);
        data.RemoveRange(split, amount);
        data.InsertRange(0, tail);
    }
}
