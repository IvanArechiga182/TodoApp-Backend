namespace TodoApp.Domain
{
    public enum Priority
    {
        Low,
        Medium,
        High
    };

    public enum Status
    {
        JustCreated,
        InProgress,
        WithDependency,
        Canceled,
        Closed
    };
}
