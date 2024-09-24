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
    // Step 1: Create an array of doubles with the specified length
    double[] multiplesArray = new double[length];
    
    // Step 2: Loop through the array to populate it with multiples of the number
    for (int i = 0; i < length; i++)
    {
        // Calculate the multiple & assign it to the array
        multiplesArray[i] = number * (i + 1);
    }
    
    // Step 3: Return the array
    return multiplesArray;
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
        // Step 1: Check the amount inputed
        if (amount < 1 || amount > data.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be between 1 and data.Count inclusive.");
        }
    
        // Step 2: Calculate needed rotations
        int effectiveAmount = amount % data.Count;

        // Step 3: Create a temporary list to hold the elements to rotate
        List<int> temp = data.GetRange(data.Count - effectiveAmount, effectiveAmount);

        // Step 4: Get the remaining elements
        List<int> remaining = data.GetRange(0, data.Count - effectiveAmount);
    
        // Step 5: Clear the original list and add back the rotated elements
        data.Clear();
        data.AddRange(temp);
        data.AddRange(remaining);
    }

}
