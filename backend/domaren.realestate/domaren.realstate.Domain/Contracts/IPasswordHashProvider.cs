namespace domaren.realstate.Domain.Contracts
{
    public interface IPasswordHashProvider
    {
        string EncryptPassword(string password);
        bool DecryptPassword(string hash, string password);
    }
}
