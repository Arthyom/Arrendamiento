using System;
using System.Diagnostics;
using Core.Models.Entities;
using Core.Services.Base.Implementations;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Interfaces;

namespace Core.Services.Common.Implementations;

public class DeployService : ServiceBase<Deploy>, IDeployService
{
    public DeployService(IRepoBase<Deploy> repoGenerico) : base(repoGenerico)
    {
    }

    public  new async Task<Deploy?> CreateAsync(Deploy toCreate)
	{
		string deployBackEnd =  "/var/www/html/ArrendamientoGit/backEnd.sh";
		string deployFrontEnd = "/var/www/html/ArrendamientosFrontoGit/frontEnd.sh";

		await DeployTarget(deployBackEnd);
		await DeployTarget(deployFrontEnd);

		return new Deploy();
	}

	private async Task DeployTarget( string targetPath )
	{
		Process p = new Process();

		p.StartInfo.FileName = "sh";
		p.StartInfo.Arguments = targetPath;

		p.StartInfo.UseShellExecute = false;
    	p.StartInfo.RedirectStandardOutput = true;

		p.Start();
		string output = p.StandardOutput.ReadToEnd();

		await p.WaitForExitAsync();

		Console.WriteLine(output);
	}
}
