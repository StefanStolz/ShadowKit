using System.Threading;

namespace ShadowKit.Threading;

internal sealed class ThreadSynchronisationContext : SynchronizationContext
{
    private readonly ThreadWorker threadWorker;

    public ThreadSynchronisationContext(ThreadWorker threadWorker)
    {
        this.threadWorker = threadWorker;

        this.threadWorker.Post(() => SetSynchronizationContext(this));
    }

    public override void Post(SendOrPostCallback d, object? state)
    {
        this.threadWorker.Post(() => d(state));
    }

    public override void Send(SendOrPostCallback d, object? state)
    {
        this.threadWorker.Send(() => d(state));
    }

    public override SynchronizationContext CreateCopy()
    {
        return new ThreadSynchronisationContext(this.threadWorker);
    }
}