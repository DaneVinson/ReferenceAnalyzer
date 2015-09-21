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
    /// in .csproj (Visual Studio C# project) files.
    /// </summary>
    public class CsprojAnalyzer : BaseAnalyzer
    {
        /// <summary>
        /// Get a list of <see cref="Reference"/> objects representing references discoverd 
        /// in .csproj files for the specified project root directory and all sub-directories.
        /// </summary>
        /// <param name="rootPath">The project root directory path.</param>
        /// <returns>List of <see cref="Reference"/> for the entire project.</returns>
        public override List<Reference> GetReferences(string rootPath)
        {
            var references = new List<Reference>();

            // Validate the directory.
            var sourceDirectory = new DirectoryInfo(rootPath);
            if (sourceDirectory == null || !Directory.Exists(sourceDirectory.FullName))
            {
                // return projects;
            }
            sourceDirectory
                .GetFiles("*.csproj", SearchOption.AllDirectories)
                .ToList()
                .ForEach(f =>
                {
                    // Read the document
                    XDocument document = null;
                    using (StreamReader reader = new StreamReader(f.FullName)) { document = XDocument.Load(reader); }

                    // TargetFrameworkVersion for default version on version-less references
                    string netVersion = document.Descendants()
                                                .Where(d => d.Name.LocalName == "TargetFrameworkVersion")
                                                .First()
                                                .Value.Replace("v", String.Empty);

                    // Add all references found in the project file.
                    var xmlReference = document.Descendants()
                                            .Where(d => d.Name.LocalName == "Reference" &&
                                                        d.Attribute(XName.Get("Include")).Value != null)
                                            .ToList();
                    xmlReference.ForEach(r =>
                    {
                        // The Include attribute contains all assembly reference information in a , delimited list.
                        string[] parts = r.Attribute(XName.Get("Include")).Value
                                            .Split(',')
                                            .Select(s => s.Trim())
                                            .ToArray();

                        var reference = new Reference()
                        {
                            Name = parts[0],
                            Project = f.Directory.Name,
                            NetVersion = new Version(netVersion)
                        };

                        // Default Version to NetVersion if it can't be set explicitly.
                        string versionPart = parts.FirstOrDefault(p => p.StartsWith("Version="));
                        if (versionPart != null) { reference.Version = new Version(versionPart.Split('=')[1].Trim()); }
                        reference.Version = reference.Version ?? reference.NetVersion;

                        references.Add(reference);
                    });
                });

            return references;
        }

        private static void ComeTestSome()
        {
            string rootPath = @"C:\Users\dane.vinson\Documents\Visual Studio 2015\Projects\NuGetPackagesSample";


            var references = new List<Reference>();

            // Validate the directory.
            var sourceDirectory = new DirectoryInfo(rootPath);
            if (sourceDirectory == null || !Directory.Exists(sourceDirectory.FullName))
            {
                // return projects;
            }
            sourceDirectory
                .GetFiles("*.csproj", SearchOption.AllDirectories)
                .ToList()
                .ForEach(f =>
                {
                    // Read the document
                    XDocument document = null;
                    using (StreamReader reader = new StreamReader(f.FullName)) { document = XDocument.Load(reader); }

                    // TargetFrameworkVersion for default version on version-less references
                    string versionString = document.Descendants()
                                                    .Where(d => d.Name.LocalName == "TargetFrameworkVersion")
                                                    .First()
                                                    .Value.Replace("v", String.Empty);

                    // Reference attribute Include
                    var xmlReference = document.Descendants()
                                            .Where(d => d.Name.LocalName == "Reference" &&
                                                        d.Attribute(XName.Get("Include")).Value != null)
                                            .ToList();
                    xmlReference.ForEach(r =>
                    {
                        string[] parts = r.Attribute(XName.Get("Include")).Value
                                            .Split(',')
                                            .Select(s => s.Trim())
                                            .ToArray();

                        var reference = new Reference()
                        {
                            Name = parts[0],
                            Project = f.Directory.Name,
                            NetVersion = new Version(versionString)
                        };

                        string versionPart = parts.FirstOrDefault(p => p.StartsWith("Version="));
                        if (versionPart != null) { reference.Version = new Version(versionPart.Split('=')[1].Trim()); }
                        reference.Version = reference.Version ?? reference.NetVersion;

                        references.Add(reference);
                    });
                });

            var x = references;
        }

    }
}
