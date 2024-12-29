using System;
using System.Diagnostics;
using Core.Enums;
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
		string deployBackEnd =  "/home/frodo/Documents/Arrendamiento/backEnd.sh";
		string deployFrontEnd = "/home/frodo/Documents/Arrendamiento/frontEnd.sh";

		await DeployTarget(deployBackEnd);
		await DeployTarget(deployFrontEnd);

		return new Deploy();
	}

    public async Task<Deploy> Deploy(TypeDeployEnum target)
    {
		string pathToRun = "";
		switch (target)
		{
			case TypeDeployEnum.backEnd:
				pathToRun = "/home/frodo/Documents/Arrendamiento/backEnd.sh";
			break;	

			case TypeDeployEnum.frontEnd:
				pathToRun = "/home/frodo/Documents/Arrendamiento/backEnd.sh";
			break;
		}

		await DeployTarget(pathToRun);

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
