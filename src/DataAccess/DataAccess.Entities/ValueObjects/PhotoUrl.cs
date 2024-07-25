using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public class PhotoUrl(string photoUrl) : ValueObject<string>(new PhotoUrlValidator(), photoUrl);
