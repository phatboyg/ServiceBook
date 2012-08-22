namespace ServiceBook.Registrations
{
    /// <summary>
    /// A reference to a dependency that has yet to be fully resolved
    /// </summary>
    public interface DependencyReference
    {
        Dependency Dependency { get; }
    }
}