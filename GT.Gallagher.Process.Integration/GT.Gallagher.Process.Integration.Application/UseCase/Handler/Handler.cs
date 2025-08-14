namespace GT.Gallagher.Process.Integration.Application.UseCase.Handler;

public abstract class Handler<T>
{
    protected Handler<T> sucessor;

    public Handler<T> SetSucessor(Handler<T> sucessor) =>
        this.sucessor = sucessor;

    public abstract Task ProcessRequest(T request);
}
