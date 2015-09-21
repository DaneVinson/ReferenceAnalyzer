using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReferenceAnalyzer
{
    public abstract class BaseAnalyzer
    {
        /// <summary>
        /// Get a list of all referneces for the project found in the specified root directory.
        /// </summary>
        /// <param name="rootPath"></param>
        /// <returns></returns>
        public abstract List<Reference> GetReferences(string rootPath);

        /// <summary>
        /// Get all references grouping by reference name and then by reference version.
        /// </summary>
        /// <param name="rootPath"></param>
        /// <returns></returns>
        public Dictionary<string, Dictionary<Version, List<Reference>>> GetReferencesByNameThenVersion(string rootPath)
        {
            var projects = GetReferences(rootPath);
            var references = new Dictionary<string, Dictionary<Version, List<Reference>>>();

            projects.GroupBy(p => p.Name)
                        .Select(p => new
                        {
                            Name = p.Key,
                            Versions = p.GroupBy(x => x.Version).ToList()
                        })
                        .ToList()
                        .ForEach(r =>
                        {
                            if (!references.ContainsKey(r.Name)) { references.Add(r.Name, new Dictionary<Version, List<Reference>>()); }
                            r.Versions.ForEach(v =>
                            {
                                if (!references[r.Name].ContainsKey(v.Key)) { references[r.Name].Add(v.Key, new List<Reference>()); }
                                references[r.Name][v.Key].AddRange(v.ToList());
                            });
                        });

            return references;
        }
    }
}
