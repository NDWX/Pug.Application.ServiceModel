
using System;
using System.Collections.Generic;
using System.Transactions;
using Pug.Application.Data;

namespace Pug.Application.ServiceModel
{
	public abstract class ApplicationService<TDataSession> : IDisposable
		where TDataSession : class, IApplicationDataSession
	{
		private readonly IApplicationData<TDataSession> _applicationDataProvider;
		private readonly IUserSessionProvider _sessionProvider;

		protected ApplicationService( IApplicationData<TDataSession> applicationDataProvider, IUserSessionProvider sessionProvider )
		{
			_applicationDataProvider = applicationDataProvider;
			_sessionProvider = sessionProvider;

			sessionProvider.SessionStarted += SessionProvider_SessionStarted;
		}

		private void SessionProvider_SessionStarted(IUserSession session)
		{
			session.Ending += UserSession_Ending;
		}

		private void UserSession_Ending(object sender, EventArgs e)
		{
			((IUserSession) sender).Ending -= UserSession_Ending;

			ApplicationTransaction<TDataSession> transaction = Transaction;

			if(transaction != null)
			{
				foreach(ApplicationTransaction<TDataSession> tx in UserTransactions.Values)
				{
					tx.Dispose();
				}
			}

		}

		private IDictionary<string, ApplicationTransaction<TDataSession>> UserTransactions
		{
			get
			{
				IUserSession userSession = _sessionProvider.CurrentSession;

				IDictionary<string, ApplicationTransaction<TDataSession>> userTransactions = userSession.Get<IDictionary<string, ApplicationTransaction<TDataSession>>>();

				if (userTransactions == null)
				{
					userTransactions = new Dictionary<string, ApplicationTransaction<TDataSession>>(1);

					userSession.Set(string.Empty, userTransactions);
				}

				return userTransactions;
			}
		}

		private void Register(ApplicationTransaction<TDataSession> transaction)
		{
			UserTransactions.Add(transaction.Identifier, transaction);

			Transaction = transaction;
		}

		private ApplicationTransaction<TDataSession> Transaction
		{
			get
			{
				IUserSession userSession = _sessionProvider.CurrentSession;

				return userSession?.Get<ApplicationTransaction<TDataSession>>("CURRENT");
			}
			set
			{
				IUserSession userSession = _sessionProvider.CurrentSession;

				userSession.Set("CURRENT", value);
			}
		}

		public IApplicationTransaction<TDataSession> CurrentTransaction
		{
			get
			{
				return Transaction;
			}
		}

		public IApplicationTransaction<TDataSession> BeginTransaction()
		{
			ApplicationTransaction<TDataSession> transaction = null;

			transaction = new ApplicationTransaction<TDataSession>();
			Register(transaction);

			return transaction;
		}

		public IApplicationTransaction<TDataSession> BeginTransaction(Transaction tx)
		{
			ApplicationTransaction<TDataSession> transaction = new ApplicationTransaction<TDataSession>(tx);
			Register(transaction);

			return transaction;
		}
		public IApplicationTransaction<TDataSession> BeginTransaction(Transaction tx, TimeSpan timeout)
		{
			ApplicationTransaction<TDataSession> transaction = new ApplicationTransaction<TDataSession>(tx);
			Register(transaction);

			return transaction;
		}

		public IApplicationTransaction<TDataSession> BeginTransaction(Transaction tx, TransactionScopeAsyncFlowOption asyncFlowOption)
		{
			ApplicationTransaction<TDataSession> transaction = new ApplicationTransaction<TDataSession>(tx, asyncFlowOption);
			Register(transaction);

			return transaction;
		}

		public IApplicationTransaction<TDataSession> BeginTransaction(Transaction tx, TimeSpan timeout, TransactionScopeAsyncFlowOption asyncFlowOption)
		{
			ApplicationTransaction<TDataSession> transaction = new ApplicationTransaction<TDataSession>(tx, timeout, asyncFlowOption);
			Register(transaction);

			return transaction;
		}

		public IApplicationTransaction<TDataSession> BeginTransaction(TransactionScopeOption option)
		{
			ApplicationTransaction<TDataSession> transaction = new ApplicationTransaction<TDataSession>(option);
			Register(transaction);

			return transaction;
		}

		public IApplicationTransaction<TDataSession> BeginTransaction(TransactionScopeOption option, TimeSpan timeout)
		{
			ApplicationTransaction<TDataSession> transaction = new ApplicationTransaction<TDataSession>(option, timeout);
			Register(transaction);

			return transaction;
		}

		public IApplicationTransaction<TDataSession> BeginTransaction(TransactionScopeOption option, TransactionScopeAsyncFlowOption asyncFlowOption)
		{
			ApplicationTransaction<TDataSession> transaction = new ApplicationTransaction<TDataSession>(option, asyncFlowOption);
			Register(transaction);

			return transaction;
		}

		public IApplicationTransaction<TDataSession> BeginTransaction(TransactionScopeOption option, TimeSpan timeout, TransactionScopeAsyncFlowOption asyncFlowOption)
		{
			ApplicationTransaction<TDataSession> transaction = new ApplicationTransaction<TDataSession>(option, timeout, asyncFlowOption);
			Register(transaction);

			return transaction;
		}

		public IApplicationTransaction<TDataSession> BeginTransaction(TransactionScopeOption option, TransactionOptions options, TransactionScopeAsyncFlowOption asyncFlowOption)
		{
			ApplicationTransaction<TDataSession> transaction  = new ApplicationTransaction<TDataSession>(option, options, asyncFlowOption);
			Register(transaction);

			return transaction;
		}

		public abstract void Dispose();
	}
}