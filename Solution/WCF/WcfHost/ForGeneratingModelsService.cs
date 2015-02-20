using System;
using BLL;
using CommonModels.Models;
using CommonModels.Models.AccountModels;
using WcfInterfaces;

namespace WcfHost
{
	public class ForGeneratingModelsService : IForGeneratingModels
	{
		public void DoNothing(LoginModel a1, DetailedSearchVM a2)
		{
		}
	}
}
