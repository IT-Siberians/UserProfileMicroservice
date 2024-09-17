using UserProfileMicroservice.Common.Validation;
using UserProfileMicroservice.DataAccess.Entities;
using UserProfileMicroservice.DataAccess.ValueObjects;
using UserProfileMicroservice.DataAccess.ValueObjects.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserProfileMicroservice.DataAccess.EntityFramework.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Email)
            .HasConversion(email => email.Value, value => new Email(value))
            .IsRequired()
            .HasMaxLength(EmailValidationHelper.EmailMaximumLength);
        builder.Property(x => x.Username)
            .HasConversion(username => username.Value, value => new Username(value))
            .IsRequired()
            .HasMaxLength(UsernameValidationHelper.UsernameMaximumLength);
        builder.Property(x => x.FirstName)
            .HasConversion(firstName => firstName.Value, value => new FirstName(value))
            .IsRequired()
            .HasMaxLength(FirstNameValidationHelper.FirstNameMaximumLength);
        builder.Property(x => x.LastName)
            .HasConversion(lastName => lastName.Value, value => new LastName(value))
            .IsRequired()
            .HasMaxLength(LastNameValidationHelper.LastNameMaximumLength);
        builder.Property(x => x.PhoneNumber)
            .HasConversion(phoneNumber => ConvertToNullableValueObject(phoneNumber), value => value == null ? null : new PhoneNumber(value))
            .HasMaxLength(PhoneNumberValidationHelper.PhoneNumberMaximumLength);
        builder.Property(x => x.PhotoUrl)
            .HasConversion(photoUrl => ConvertToNullableValueObject(photoUrl), value => value == null ? null : new PhotoUrl(value));
        builder.Property(x => x.DataPrivacyState)
            .IsRequired();
    }

    private T? ConvertToNullableValueObject<T>(ValueObject<T>? valueObject)
    {
        if (valueObject is null)
            return default(T);
        return valueObject.Value;
    }
}
