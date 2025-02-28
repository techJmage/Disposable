namespace Utility;
/// <summary>
/// Async version of Disposable
/// </summary>
/// <seealso cref="System.IAsyncDisposable" />
/// <seealso cref="System.IDisposable" />
public class DisposableAsync : IAsyncDisposable, IDisposable
{
    protected bool disposed = false;

    protected virtual async ValueTask DisposeAsync(bool disposing)
    {
        if (disposed)
            return;
        if (disposing)
            await ReleaseResourcesAsync();
        disposed = true;
    }

    public virtual ValueTask ReleaseResourcesAsync() => ValueTask.CompletedTask;

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;
        if (disposing)
            ReleaseResources();
        disposed = true;
    }

    public virtual void ReleaseResources()
    {

    }
}