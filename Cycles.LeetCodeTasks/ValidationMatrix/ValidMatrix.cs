namespace Cycles.LeetCodeTasks.ValidationMatrix;

#region ValidMatrix
public static class ValidMatrix
{
    #region Public : Methods
    /// <summary>
    ///     Checks if every row and column contains all numbers.
    /// </summary>
    /// <param name="array">Multidimensional array.</param>
    /// <returns>Given an n x n integer matrix <paramref name="array"/>, return true if the matrix is valid.
    /// Otherwise, return false.</returns>
    public static bool CheckMatrix(int[,] array)
    {
        var rows = array.GetUpperBound(0);
        var columns = array.GetUpperBound(1) + 1;
        for (var i = 0; i < rows; i++)
        {
            for (var k = i + 1; k <= rows; k++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (array[i, j] == array[k, j])
                        return false;
                }
            }
        }
        return true;
    }
    #endregion
}
#endregion