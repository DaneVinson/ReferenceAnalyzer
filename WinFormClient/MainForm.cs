using ReferenceAnalyzer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            comboBoxAnalysisType.Items.AddRange(new string[] 
            {
                "NuGet references by package then version",
                "Csproj references by name then version"
            });
            comboBoxAnalysisType.SelectedIndex = 0;
            buttonAnalyze.Click += (o, e) => { Analyze(); };
        }


        private void Analyze()
        {
            if (!Directory.Exists(textBoxProjectDirectory.Text))
            {
                MessageBox.Show("Directory does not exist.");
                return;
            }

            treeView.Nodes.Clear();

            BaseAnalyzer analyzer = GetAnalyzer();
            if (analyzer == null) { return; }

            var references = analyzer.GetReferencesByNameThenVersion(textBoxProjectDirectory.Text);
            foreach (var reference in references)
            {
                var nameNode = new TreeNode($"{reference.Key} (Version count: {reference.Value.Count})");
                foreach (var version in reference.Value)
                {
                    var versionNode = new TreeNode($"{version.Key.ToString()} (Project count: {version.Value.Count})");
                    foreach (var r in version.Value)
                    {
                        versionNode.Nodes.Add($"{r.Project}");
                    }
                    nameNode.Nodes.Add(versionNode);
                }
                treeView.Nodes.Add(nameNode);
            }
        }

        private BaseAnalyzer GetAnalyzer()
        {
            switch (comboBoxAnalysisType.SelectedIndex)
            {
                case 0:
                    return new NuGetPackageAnalyzer();
                case 1:
                    return new CsprojAnalyzer();
                default:
                    return null;
            }
        }
    }
}
