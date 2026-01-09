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
        // step 1: create a new array with the required length
        double[] multiples = new double[length];
        // step 2: loop through each position in the array
        for (int i = 0; i < length; i++)
        {
            // step3: calculate the multiple 
            //(i + 1) is used so the first value is number * 1, not number * 0
            multiples[i] = number * (i + 1);
        }

        return multiples; 
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
        // step 1: determine how many elements are in the list
        int count = data.Count;
        // step 2: get the last 'amount' of elements (which will be moved to the front)
        List<int> rightpart = data.GetRange(count - amount, amount);
        // step 3: get the  remeining elements at the beginning of the list
        List<int> leftpart = data.GetRange(0, count - amount);
        // step 4: clear the original list so we can rebuild it
        data.Clear();
        // step 5: add the right part first, then the left part
        data.AddRange(rightpart);
        data.AddRange(leftpart);
    }
}
