using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReferenceAnalyzer
{
    public class Reference
    {
        public override string ToString()
        {
            return $"Name: {Name}, Project: {Project}, Version: {Version}, .Net: {NetVersion}";
        }


        /// <summary>
        /// The name of the reference component, e.g. System.Web or log4net.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Project's .Net version.
        /// </summary>
        public Version NetVersion { get; set; }

        /// <summary>
        /// The parent project the reference belongs to.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// The version of the referenced component.
        /// </summary>
        public Version Version { get; set; }
    }
}
