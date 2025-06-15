namespace ShadowKit.Threading.Tests;

[TestFixture]
[Parallelizable(ParallelScope.None)]
public class FakeUiTests
{
    [Test]
    public void ScheduleInFakeUi()
    {
        using FakeUi sut = new FakeUi();

        int i = 0;

        sut.SynchronizationContext.Send(_ => { i++; }, null);

        Assert.That(i, Is.EqualTo(1));
    }

    [Test]
    public void ExceptionsInFakeUiAreCaught()
    {
        using FakeUi sut = new FakeUi();

        sut.SynchronizationContext.Send(_ => throw new InvalidOperationException("Some Exception"), null);

        ExceptionHistory exceptionHistory = sut.TakeOverExceptions();

        Assert.That(exceptionHistory.Count, Is.EqualTo(1));
        InvalidOperationException? exception =
            Assert.Throws<InvalidOperationException>(() => exceptionHistory.Throw());

        Assert.That(exception.Message, Is.EqualTo("Some Exception"));
    }

    [Test]
    public void MultipleExceptionsAreThrownAsAggregateException()
    {
        using FakeUi sut = new FakeUi();

        sut.SynchronizationContext.Send(_ => throw new InvalidOperationException("Some Exception"), null);
        sut.SynchronizationContext.Send(_ => throw new ArgumentException("Some ArgumentException"), null);

        ExceptionHistory exceptionHistory = sut.TakeOverExceptions();

        Assert.That(exceptionHistory.Count, Is.EqualTo(2));
        exceptionHistory[0].ShouldBeOfType<InvalidOperationException>();
        exceptionHistory[1].ShouldBeOfType<ArgumentException>();

        Assert.Throws<AggregateException>(() => exceptionHistory.Throw());
    }
}