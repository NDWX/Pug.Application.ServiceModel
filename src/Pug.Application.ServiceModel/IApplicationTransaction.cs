using System;
using Pug.Application.Data;

namespace Pug.Application.ServiceModel
{
	public interface IApplicationTransaction<TDataSession> : IDisposable
		where TDataSession : class, IApplicationDataSession
	{
		string Identifier { get; }

		void Commit();

		void Rollback();
	}
}