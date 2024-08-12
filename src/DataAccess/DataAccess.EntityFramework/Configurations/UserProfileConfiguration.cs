using DataAccess.Entities;
using DataAccess.Entities.ValueObjects;
using DataAccess.Entities.ValueObjects.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Email)
            .HasConversion(email => email.Value, value => new Email(value))
            .IsRequired()
            .HasMaxLength(Email.MaximumValueLength);
        builder.Property(x => x.Username)
            .HasConversion(username => username.Value, value => new Username(value))
            .IsRequired()
            .HasMaxLength(Username.MaximumValueLength);
        builder.Property(x => x.LastName)
            .HasConversion(lastName => ConvertNullableValueObject(lastName), value => value == null ? null : new LastName(value))
            .HasMaxLength(LastName.MaximumValueLength);
        builder.Property(x => x.PhoneNumber)
            .HasConversion(phoneNumber => ConvertNullableValueObject(phoneNumber), value => value == null ? null : new PhoneNumber(value))
            .HasMaxLength(PhoneNumber.MaximumValueLength);
        builder.Property(x => x.PhotoUrl)
            .HasConversion(photoUrl => ConvertNullableValueObject(photoUrl), value => value == null ? null : new PhotoUrl(value));
        builder.Property(x => x.DataPublicityState)
            .HasConversion(dataPublicityState => dataPublicityState.Value, value => new DataPublicityState(value))
            .IsRequired();
    }

    private T? ConvertNullableValueObject<T>(ValueObject<T>? valueObject)
    {
        if (valueObject is null)
            return default(T);
        return valueObject.Value;
    }
}
