namespace Aspire.Hosting.ApplicationModel;

public sealed class SymXchangeInfoResource(string name) : ContainerResource(name), IResourceWithConnectionString
{


    public ReferenceExpression ConnectionStringExpression
    {
        get
        {
            return ReferenceExpression.Create(new ReferenceExpression.ExpressionInterpolatedStringHandler(100,6));
        }
    }

    private string GetConnectionString()
    {
        return Environment.GetEnvironmentVariable("SymXchangeConnectionString") ?? 
            throw new InvalidOperationException("SymXchange Connection string not found.");
    }
}
