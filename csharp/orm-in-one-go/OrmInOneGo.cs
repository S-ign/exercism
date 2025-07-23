public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        try {
            database.BeginTransaction();
            database.Write(data);
            database.EndTransaction();
        }
        catch (InvalidOperationException ex) {
            database.Dispose();
            throw new InvalidOperationException(ex.Message);
        }
    }

    public bool WriteSafely(string data)
    {
        try {
            database.BeginTransaction();
            database.Write(data);
            database.EndTransaction();
            return true;
        }
        catch (InvalidOperationException) {
            database.Dispose();
            return false;
        }

    }
}
