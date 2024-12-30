namespace Cycles.Patterns.Contracts.BusinessObjects.Items
{
    #region IItem
    public interface IItem
    {
        #region State
        List<object[]> Data { get; set; }
        #endregion
    }
    #endregion
}