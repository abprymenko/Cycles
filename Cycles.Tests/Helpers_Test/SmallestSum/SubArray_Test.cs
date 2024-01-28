﻿namespace Cycles.Tests.Helpers_Test.SmallestSum;

#region SubArray_Test
internal class SubArray_Test
{
    #region Private : Fields
    private readonly int _expected0 = 0;
    private readonly int _expected2 = 2;
    private readonly int _expected3 = 3;
    #endregion

    #region Setup
    [SetUp]
    public void Setup()
    {
    }
    #endregion

    #region Test : Methods
    [Test]
    [TestCase(new int[]{ 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 2, 4, -2, 6, -9, 7, -3 })]
    [TestCase(new int[] { 0, 0, 0, 0, 0 })]
    public void MinLength0_Test(int[] array)
    {
        var act = SubArray.MinLength(array);
        Assert.That(act, Is.EqualTo(_expected0));
    }
    [Test]
    [TestCase(new int[] { 4, 3, 2, -3, 0, -2, 1, -1, -2 })]
    [TestCase(new int[] { 1, 2, -2, 4, -1, 0 })]
    public void MinLength2_Test(int[] array)
    {
        var act = SubArray.MinLength(array);
        Assert.That(act, Is.EqualTo(_expected2));
    }
    [Test]
    [TestCase(new int[] { 4, 2, 2, -3, 1, 0, 4 })]
    public void MinLength3_Test(int[] array)
    {
        var act = SubArray.MinLength(array);
        Assert.That(act, Is.EqualTo(_expected3));
    }
    #endregion
}
#endregion