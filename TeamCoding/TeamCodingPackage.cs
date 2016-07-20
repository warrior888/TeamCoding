﻿using Microsoft.VisualStudio.Shell;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Runtime.InteropServices;
using TeamCoding.Documents;
using TeamCoding.IdentityManagement;
using TeamCoding.Options;
using TeamCoding.VisualStudio;
using TeamCoding.VisualStudio.Models;
using TeamCoding.VisualStudio.Models.ChangePersisters;
using TeamCoding.VisualStudio.Models.ChangePersisters.DebugPersister;
using TeamCoding.VisualStudio.Models.ChangePersisters.FileBasedPersister;

namespace TeamCoding
{
    // TODO: Add debugging output (to output window?)
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [Guid(PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideAutoLoad(Microsoft.VisualStudio.Shell.Interop.UIContextGuids80.SolutionExists)]
    [ProvideOptionPage(typeof(OptionPageGrid), "Team Coding", "General", 0, 0, true)]
    public sealed class TeamCodingPackage : Package
    {
        public const string PackageGuidString = "ac66efb2-fad5-442d-87e2-b9b4a206f14d";
        public static TeamCodingPackage Current { get; private set; }
        public readonly Settings Settings;
        public readonly LocalIDEModel LocalIdeModel;
        public readonly GitRepository SourceControlRepo = new GitRepository();
        public readonly HttpClient HttpClient;
        public ILocalModelPerisister LocalModelChangeManager { get; private set; }
        public IRemoteModelPersister RemoteModelChangeManager { get; private set; }
        public IDEWrapper IDEWrapper { get; private set; }
        public IIdentityProvider IdentityProvider { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamCodingPackage"/> class.
        /// </summary>
        public TeamCodingPackage()
        {
            Current = this;
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("User-Agent",
                                                 "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
            Settings = new Settings();
            LocalIdeModel = new LocalIDEModel();
    }
        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            IDEWrapper = new IDEWrapper((EnvDTE.DTE)GetService(typeof(EnvDTE.DTE)));
            IdentityProvider = new CachedFailoverIdentityProvider(new VSOptionsIdentityProvider(),
                                                                  new CredentialManagerIdentityProvider(new[] { "git:https://github.com", "https://github.com/" }),
                                                                  new VSIdentityProvider(),
                                                                  new MachineIdentityProvider());
            LocalModelChangeManager = new SharedFolderLocalModelPersister(LocalIdeModel);
            RemoteModelChangeManager = new SharedFolderRemoteModelPersister(IDEWrapper);
        }
        protected override void Dispose(bool disposing)
        {
            RemoteModelChangeManager.Dispose();
            LocalModelChangeManager.Dispose();
            HttpClient.Dispose();
            base.Dispose(disposing);
        }
    }
}