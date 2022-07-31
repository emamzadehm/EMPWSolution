namespace _01_Framework.Domain
{
    public interface IUnitOfWork
    {
        void BeginTran();
        void CommitTran();
        void RollBack();
    }
}
