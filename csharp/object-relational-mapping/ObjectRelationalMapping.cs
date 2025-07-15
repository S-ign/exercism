public class Orm : IDisposable
{
    private Database database;
    private bool disposed = false;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
       if (database.DbState != Database.State.Closed) {
           throw new InvalidOperationException(
                   "Database State Must be Closed before starting a new transaction.");
       }
       database.BeginTransaction();
    }

    public void Write(string data)
    {
       try {
           database.Write(data);
           }
       catch {
           database.Dispose();
       }
    }

    public void Commit()
    {
        try {
            if (database.DbState != Database.State.DataWritten) {
               throw new InvalidOperationException(
                       "Database State Must be DataWritten before commit.");
            }
            database.Dispose();
        }
        catch {
            database.Dispose();
        }
    }

    public void Dispose() {
        if (!disposed) {
            database.Dispose();
            disposed = true;
        }
    }
}
