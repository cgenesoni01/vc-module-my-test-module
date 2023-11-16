using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Settings;

namespace MyCoolCompany.MyTestModule.Core;

public static class ModuleConstants
{
    public static class Security
    {
        public static class Permissions
        {
            public const string Access = "MyTestModule:access";
            public const string Create = "MyTestModule:create";
            public const string Read = "MyTestModule:read";
            public const string Update = "MyTestModule:update";
            public const string Delete = "MyTestModule:delete";

            public static string[] AllPermissions { get; } =
            {
                Access,
                Create,
                Read,
                Update,
                Delete,
            };
        }
    }

    public static class Settings
    {
        public static class General
        {
            public static SettingDescriptor MyTestModuleEnabled { get; } = new SettingDescriptor
            {
                Name = "MyTestModule.MyTestModuleEnabled",
                GroupName = "MyTestModule|General",
                ValueType = SettingValueType.Boolean,
                DefaultValue = false,
            };

            public static SettingDescriptor MyTestModulePassword { get; } = new SettingDescriptor
            {
                Name = "MyTestModule.MyTestModulePassword",
                GroupName = "MyTestModule|Advanced",
                ValueType = SettingValueType.SecureString,
                DefaultValue = "qwerty",
            };

            public static IEnumerable<SettingDescriptor> AllGeneralSettings
            {
                get
                {
                    yield return MyTestModuleEnabled;
                    yield return MyTestModulePassword;
                }
            }
        }

        public static IEnumerable<SettingDescriptor> AllSettings
        {
            get
            {
                return General.AllGeneralSettings;
            }
        }
    }
}
