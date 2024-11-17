using UserProfileMicroservice.Common.Enumerations;

namespace UserProfileMicroservice.Common.Utils;

public class DataPrivacyConfigurator
{
    private DataPrivacyControlFlags _dataPrivacyState;

    public bool IsEmailPublished
    {
        get => _dataPrivacyState.HasFlag(DataPrivacyControlFlags.Email);
        set
        {
            if (value != IsEmailPublished)
                _dataPrivacyState ^= DataPrivacyControlFlags.Email;
        }
    }

    public bool IsNamePublished
    {
        get => _dataPrivacyState.HasFlag(DataPrivacyControlFlags.Name);
        set
        {
            if (value != IsNamePublished    )
                _dataPrivacyState ^= DataPrivacyControlFlags.Name;
        }
    }

    public bool IsPhoneNumberPublished
    {
        get => _dataPrivacyState.HasFlag(DataPrivacyControlFlags.PhoneNumber);
        set
        {
            if (value != IsPhoneNumberPublished)
                _dataPrivacyState ^= DataPrivacyControlFlags.PhoneNumber;
        }
    }

    public DataPrivacyConfigurator(DataPrivacyControlFlags dataPrivacyState = DataPrivacyControlFlags.CompletePrivacy)
    {
        _dataPrivacyState = dataPrivacyState;
    }

    public DataPrivacyControlFlags GetDataPrivacyState()
        => _dataPrivacyState;
}
