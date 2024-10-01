namespace domaren.realstate.Domain.Contracts
{
    public interface IPasswordHashProvider
    {
        string EncryptPassword(string password);
    }
}
