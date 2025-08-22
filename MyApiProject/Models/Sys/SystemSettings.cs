using System;
namespace MyApiProject.Models.Sys
{
	public class SystemSettings
	{
        public string ApiKey { get; set; }
        public string HeaderName { get; set; }
        public List<string> WithOrigins { get; set; }
    }
}

