using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ReferenceAnalyzer
{
    /// <summary>
    /// Concrete implementation of <see cref="BaseAnalyzer"/> to analyze references found
    /// in packages.config (NuGet) files.
    /// </summary>
    public class NuGetPackageAnalyzer : BaseAnalyzer
    {
        /// <summary>
        /// Get a list of <see cref="Reference"/> objects representing references discoverd 
        /// in the packages.config files for the specified project root directory and all sub-directories.
        /// </summary>
        /// <param name="rootPath">The project root directory path.</param>
        /// <returns>List of <see cref="NuGetReference"/> for the entire project.</returns>
        public override List<Reference> GetReferences(string rootPath)
        {
            var references = new List<Reference>();

            // Validate the directory.
            var sourceDirectory = new DirectoryInfo(rootPath);
            if (sourceDirectory == null || !Directory.Exists(sourceDirectory.FullName)) { return references; }

            // Find and read NuGet packages.config files and return reference information by project name.
            sourceDirectory
                .GetFiles("packages.config", SearchOption.AllDirectories)
                .ToList()
                .ForEach(f =>
                {
                    using (StreamReader reader = new StreamReader(f.FullName))
                    {
                        references.AddRange(XDocument.Load(reader).Descendants()
                                                    .Where(d => d.Name.LocalName == "package")
                                                    .Select(d => new Reference()
                                                    {
                                                        Name = d.Attribute(XName.Get("id")).Value,
                                                        NetVersion = TargetFrameworkToVersion(d.Attribute(XName.Get("targetFramework")).Value),
                                                        Project = f.Directory.Name,
                                                        Version = new Version(d.Attribute(XName.Get("version")).Value)
                                                    })
                                                    .ToList());
                        }
                });
            return references.OrderBy(r => r.Name).ToList();
        }

        /// <summary>
        /// Return the target framework value as a <see cref="Version"/>.
        /// </summary>
        private static Version TargetFrameworkToVersion(string targetFramework)
        {
            string[] versionParts = { "0", "0", "0", "0" };
            int partIndex = 0;

            targetFramework
                .Replace("net", String.Empty)
                .Select(c => c.ToString())
                .ToList()
                .ForEach(v => 
                {
                    versionParts[partIndex++] = v;
                });

            return new Version(String.Join(".", versionParts));
        }
    }
}
