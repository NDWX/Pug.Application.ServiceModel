using Pug.Application.Security;
using Pug.Application.Data;

namespace Pug.Application.ServiceModel
{
	public abstract class SecuredApplicationService<TDataSession> : ApplicationService<TDataSession>
		where TDataSession : class, IApplicationDataSession
	{
		private readonly ISecurityManager _securityManager;

		protected SecuredApplicationService( ISecurityManager securityManager, IApplicationData<TDataSession> applicationDataProvider, IUserSessionProvider userSessionProvider )
			: base( applicationDataProvider, userSessionProvider )
		{
			_securityManager = securityManager;
		}

		protected ISecurityManager SecurityManager => _securityManager;

		protected IUser User => SecurityManager.CurrentUser;
	}
}