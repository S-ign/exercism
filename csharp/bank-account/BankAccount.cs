public class BankAccount
{
    private bool IsActive = false;
    private decimal _balance = 0m;

    public decimal Balance {
        get {
            try {
                if (!IsActive)
                    throw new InvalidOperationException("account is closed");

                return _balance;
            }
            catch (InvalidOperationException) {
                throw;
            }
        }

        set {
            try {
                if (!IsActive)
                    throw new InvalidOperationException("account is closed");

                _balance = value;
            }

            catch (InvalidOperationException) {
                throw;
            }
        }
    }

    public void Open() {
        try {
            if (IsActive)
                throw new InvalidOperationException("account is already open");

            IsActive = false;
        }

        catch (InvalidOperationException) {
            throw;
        }
        IsActive = true;
    }

    public void Close()
    {
        try {
            if (!IsActive)
                throw new InvalidOperationException("account is closed");

            Balance = 0m;
            IsActive = false;
        }

        catch (InvalidOperationException) {
            throw;
        }
    }

    public void Deposit(decimal change) {
        try {
            if (change <= 0)
                throw new InvalidOperationException("can not deposit a negative number");

            Balance += change;
        }

        catch (InvalidOperationException) {
            throw;
        }
    }

    public void Withdraw(decimal change) {
        try {
            if (change <= 0)
                throw new InvalidOperationException("can not withdraw a negative number");
            if (change > Balance)
                throw new InvalidOperationException("insufficient funds");

            Balance -= change;
        }

        catch (InvalidOperationException) {
            throw;
        }
    }
}
