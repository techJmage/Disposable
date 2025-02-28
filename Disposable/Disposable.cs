namespace Utility;

public abstract class Disposable : IDisposable
{
    protected bool disposed = false;

    /// <summary>
    /// <seealso href="https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose"/>
    /// </summary>
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
    /// <summary>
    /// Releases the resources. Override this method to releasing resources.
    /// </summary>
    public abstract void ReleaseResources();
}