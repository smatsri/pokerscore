namespace PokerScore.MyData;

public class MyDataService
{
    public Task<MyData> GetMyData(CancellationToken cancellationToken)
    {
        return Task.FromResult(new MyData("just my data"));
    }
}

