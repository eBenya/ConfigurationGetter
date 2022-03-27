using Microsoft.Extensions.Configuration;

namespace ConfigurationGetter
{
    public static class ConfigurationGetter
    {
        private const int rootDepht = 0;
        private const int firstDepht = 0;

        private static int _depht;
        public static string GenerateConfigurationString(this IConfiguration configuration, int depht = int.MaxValue)
        {
            _depht = depht;
            return $"{{\n{GetSectionContent(configuration, 1)}}}";
        }
        private static string GetSectionContent(this IConfiguration configSection, int currentDepht = 1)
        {
            if (currentDepht == _depht)
                return string.Empty;

            var indent = new string('\t', currentDepht);

            string sectionContent = "";
            foreach (var section in configSection.GetChildren())
            {
                sectionContent += $"{indent}\"{section.Key}\":";
                if (section.Value == null)
                {
                    string subSectionContent = GetSectionContent(section, currentDepht + 1);
                    sectionContent += $"{{\n{subSectionContent}{indent}}},\n";
                }
                else
                {
                    sectionContent += $"\"{section.Value}\",\n";
                }
            }
            return sectionContent;
        }
    }
}