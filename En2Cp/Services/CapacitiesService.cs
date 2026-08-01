namespace En2Cp.Services;

public class CapacitiesService
{
    private readonly HttpClient _httpClient;

    public CapacitiesService()
    {
        _httpClient = new HttpClient();
    }

}