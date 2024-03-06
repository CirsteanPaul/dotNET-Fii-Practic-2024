namespace RepositoryPattern.Database.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext context;

		public UnitOfWork(AppDbContext context)
		{
			this.context = context;
		}
		
		public int SaveChanges()
		{
			return context.SaveChanges();
		}
	}
}
