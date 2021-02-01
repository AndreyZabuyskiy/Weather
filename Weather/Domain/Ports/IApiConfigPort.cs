namespace Weather.Domain.Ports
{
    public interface IApiConfigPort
    {
        string Url { get; set; }
        string Key { get; set; }
    }
}
