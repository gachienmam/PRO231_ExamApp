using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApp
{
    public class ApplicationSettings : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        [DefaultSettingValue("http://localhost:5000")]
        public string ServerAddress
        {
            get
            {
                return ((string)this["ServerAddress"]);
            }
            set
            {
                this["ServerAddress"] = value;
            }
        }
    }
}
