using testef.Infrastructure.Data;

namespace testef.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        public DataContext Context { get; private set; }

        public BaseRepository(DataContext context)
        {
            Context = context;
        }
    }
}