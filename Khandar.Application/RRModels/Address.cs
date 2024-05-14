using Khandar.Domain.Enums;

namespace Khandar.Application.RRModels;

public class AddressRequest
{
    public string State { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string AddressLine { get; set; } = string.Empty;

    public string Landmark { get; set; } = string.Empty;

    public int PinCode { get; set; }

    public bool IsNative { get; set; }

    public Module Module { get; set; }


    public Guid? EntityId { get; set; }
}

public class AddressResponse 
{
    public Guid Id { get; set; }

    public string State { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string AddressLine { get; set; } = string.Empty;

    public string Landmark { get; set; } = string.Empty;

    public int PinCode { get; set; }

    public bool IsNative { get; set; }


}


public class AddressUpdateRequest : AddressRequest
{
    public Guid Id { get; set; }
}