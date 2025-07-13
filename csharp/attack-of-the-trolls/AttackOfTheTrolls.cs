// TODO: define the 'AccountType' enum
enum AccountType {
    Guest,
    User,
    Moderator
} 

// TODO: define the 'Permission' enum
[Flags]
enum Permission {
    None   = 0b0000,
    Read   = 0b0001,
    Write  = 0b0010,
    Delete = 0b0100,
    All    = Read | Write | Delete // 0b0111
} 

static class Permissions
{
    public static Permission Default(AccountType accountType) =>
        accountType switch {
            AccountType.Guest     => Permission.Read,
            AccountType.User      =>  Permission.Read | Permission.Write,
            AccountType.Moderator =>  Permission.All,
            _ => Permission.None,
        };

    public static Permission Grant(Permission current, Permission grant) => current | grant;

    public static Permission Revoke(Permission current, Permission revoke) => current & ~revoke;

    public static bool Check(Permission current, Permission check) => current >= check;
}
