namespace PokerScore.MyData;


[ExtendObjectType(OperationTypeNames.Query)]
public sealed class MyDataQueries
{
    public Task<MyData> GetMeAsync(
         [Service] MyDataService myDataSerice,
        CancellationToken cancellationToken) => myDataSerice.GetMyData(cancellationToken);
}