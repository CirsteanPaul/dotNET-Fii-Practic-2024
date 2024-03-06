namespace RepositoryPattern.Database.UnitOfWork
{
	public interface IUnitOfWork
	{
        int SaveChanges();
	}
}