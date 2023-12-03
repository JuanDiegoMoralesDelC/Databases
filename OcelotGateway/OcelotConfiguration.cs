namespace OcelotGateway
{
    public class OcelotConfiguration
    {
        public string GatewayUrl { get; set; }
        public string GatewayHost { get; set; }
        public int GatewayPort { get; set; }
    }

    public class OcelotFileBuilder
    {
        public static void CreateOcelotConfigurationFile(string ocelotFileName)
        {
            var currentDirectory = Environment.CurrentDirectory;
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var appsettings = !string.IsNullOrEmpty(environment) ? $"appsettings.{environment}.json" : "appsettings.json";
            var configuration = new ConfigurationBuilder().AddJsonFile(appsettings,false).Build();
            var ocelotConfiguration = configuration.GetSection(nameof(OcelotConfiguration)).Get<OcelotConfiguration>();

            var replaceData = new List<Tuple<string, object>>();
            foreach (var property in ocelotConfiguration.GetType().GetProperties())
            {
                var name = "**{" + $"{property.Name}" + "}**";
                var value = property.GetValue(ocelotConfiguration);
                replaceData.Add(new Tuple<string, object>(name, value));
            }

            var filePath = Path.Combine(currentDirectory, "ocelot.json");

            string body;
            using(var reader = new StreamReader(filePath))
            {
                body = reader.ReadToEnd();
            }

            foreach (var item in replaceData)
            {
                body = body.Replace(item.Item1,item.Item2?.ToString());
            }

            var ocelotFilePath = Path.Combine(currentDirectory, ocelotFileName);
            if(File.Exists(ocelotFilePath)) File.Delete(ocelotFilePath);
            using var streamWriter = new StreamWriter(ocelotFilePath,false);
            streamWriter.WriteLine(body);
            streamWriter.Dispose();
        }
    }
}
