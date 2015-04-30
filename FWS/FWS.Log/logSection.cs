using System;
using System.Configuration;

namespace FWS.Log
{
    public class logSection : ConfigurationSection
    {

        [ConfigurationProperty("logType")]
        public logType Provider
        {
            get { return (logType)this["logType"]; }
        }

        [ConfigurationProperty("connectionString")]
        public connectionString Connection
        {
            get { return (connectionString) this["connectionString"]; }
        }

        [ConfigurationProperty("textFile")]
        public textFile Text
        {
            get { return (textFile) this["textFile"]; }
        }

    }

    // Define the "logType" element
    public class logType : ConfigurationElement
    {
        [ConfigurationProperty("Provider", IsRequired = true)]
        public provider ProviderName
        {
            get { return (provider)this["Provider"]; }
        }
    }

    // Define the "ConnectionString" element
    public class connectionString : ConfigurationElement
    {
        [ConfigurationProperty("Name", DefaultValue = "", IsRequired = true)]
        public String Name
        {
            get { return (String) this["Name"]; }
        }
    }

    // Define the "textFileLog" element 
    public class textFile : ConfigurationElement
    {
        [ConfigurationProperty("Name", DefaultValue = "log.text", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 0, MaxLength = 50)]
        public String Name
        {
            get { return (String) this["Name"]; }
            //set{this["Name"] = value;}
        }

        [ConfigurationProperty("Path", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|", MinLength = 0, MaxLength = 100)]
        public String Path
        {
            get { return (String) this["Path"]; }
            //set{this["Path"] = value;}
        }

        [ConfigurationProperty("MaxByte", DefaultValue = "1024")]
        public int MaxByte
        {
            get { return (int)(this["MaxByte"].Equals("") ? "0" : this["MaxByte"]); }
            //set { this["MaxByte"] = value; }
        }
    }

}
