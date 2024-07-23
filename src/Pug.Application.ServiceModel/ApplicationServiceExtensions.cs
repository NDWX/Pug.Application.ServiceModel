using System;
using System.Transactions;
using Pug.Application.Data;

namespace Pug.Application.ServiceModel
{
	public static class ApplicationServiceExtensions
	{
		public static void BeginTransaction<TDataSession, TContext>(this ApplicationService<TDataSession> applicationService, Action<IApplicationTransaction<TDataSession>, TContext> action, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction())
			{
				action(tx, context);

				tx.Commit();
			}
		}

		public static TResult BeginTransaction<TDataSession, TContext, TResult>(this ApplicationService<TDataSession> applicationService, Func<IApplicationTransaction<TDataSession>, TContext, TResult> func, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction())
			{
				TResult result = func(tx, context);

				tx.Commit();

				return result;
			}
		}

		public static void BeginTransaction<TDataSession, TContext>(this ApplicationService<TDataSession> applicationService, Transaction tx, Action<IApplicationTransaction<TDataSession>, TContext> action, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> t = applicationService.BeginTransaction(tx))
			{
				action(t, context);

				t.Commit();
			}
		}

		public static void BeginTransaction<TDataSession, TContext>(this ApplicationService<TDataSession> applicationService, Transaction tx, TimeSpan timeout, Action<IApplicationTransaction<TDataSession>, TContext> action, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> t = applicationService.BeginTransaction(tx, timeout))
			{
				action(t, context);

				t.Commit();
			}
		}

		public static void BeginTransaction<TDataSession, TContext>(this ApplicationService<TDataSession> applicationService, Transaction tx, TransactionScopeAsyncFlowOption asyncFlowOption, Action<IApplicationTransaction<TDataSession>, TContext> action, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> t = applicationService.BeginTransaction(tx, asyncFlowOption))
			{
				action(t, context);

				t.Commit();
			}
		}

		public static void BeginTransaction<TDataSession, TContext>(this ApplicationService<TDataSession> applicationService, Transaction tx, TimeSpan timeout, TransactionScopeAsyncFlowOption asyncFlowOption, Action<IApplicationTransaction<TDataSession>, TContext> action, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> t = applicationService.BeginTransaction(tx, timeout, asyncFlowOption))
			{
				action(t, context);

				t.Commit();
			}
		}

		public static void BeginTransaction<TDataSession, TContext>(this ApplicationService<TDataSession> applicationService, TransactionScopeOption option, Action<IApplicationTransaction<TDataSession>, TContext> action, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction(option))
			{
				action(tx, context);

				tx.Commit();
			}
		}

		public static void BeginTransaction<TDataSession, TContext>(this ApplicationService<TDataSession> applicationService, TransactionScopeOption option, TimeSpan timeout, Action<IApplicationTransaction<TDataSession>, TContext> action, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction(option, timeout))
			{
				action(tx, context);

				tx.Commit();
			}
		}

		public static void BeginTransaction<TDataSession, TContext>(this ApplicationService<TDataSession> applicationService, TransactionScopeOption option, TransactionScopeAsyncFlowOption asyncFlowOption, Action<IApplicationTransaction<TDataSession>, TContext> action, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction(option, asyncFlowOption))
			{
				action(tx, context);

				tx.Commit();
			}
		}

		public static void BeginTransaction<TDataSession, TContext>(this ApplicationService<TDataSession> applicationService, TransactionScopeOption option, TimeSpan timeout, TransactionScopeAsyncFlowOption asyncFlowOption, Action<IApplicationTransaction<TDataSession>, TContext> action, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction(option, timeout, asyncFlowOption))
			{
				action(tx, context);

				tx.Commit();
			}
		}

		public static void BeginTransaction<TDataSession, TContext>(this ApplicationService<TDataSession> applicationService, TransactionScopeOption option, TransactionOptions options, TransactionScopeAsyncFlowOption asyncFlowOption, Action<IApplicationTransaction<TDataSession>, TContext> action, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction(option, options, asyncFlowOption))
			{
				action(tx, context);

				tx.Commit();
			}
		}

		public static TResult BeginTransaction<TDataSession, TContext, TResult>(this ApplicationService<TDataSession> applicationService, Transaction transaction, Func<IApplicationTransaction<TDataSession>, TContext, TResult> func, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction(transaction))
			{
				TResult result = func(tx, context);

				tx.Commit();

				return result;
			}
		}

		public static TResult BeginTransaction<TDataSession, TContext, TResult>(this ApplicationService<TDataSession> applicationService, Transaction transaction, TimeSpan timeout, Func<IApplicationTransaction<TDataSession>, TContext, TResult> func, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction(transaction, timeout))
			{
				TResult result = func(tx, context);

				tx.Commit();

				return result;
			}
		}

		public static TResult BeginTransaction<TDataSession, TContext, TResult>(this ApplicationService<TDataSession> applicationService, Transaction transaction, TransactionScopeAsyncFlowOption asyncFlowOption, Func<IApplicationTransaction<TDataSession>, TContext, TResult> func, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction(transaction, asyncFlowOption))
			{
				TResult result = func(tx, context);

				tx.Commit();

				return result;
			}
		}

		public static TResult BeginTransaction<TDataSession, TContext, TResult>(this ApplicationService<TDataSession> applicationService, Transaction transaction, TimeSpan timeout, TransactionScopeAsyncFlowOption asyncFlowOption, Func<IApplicationTransaction<TDataSession>, TContext, TResult> func, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction(transaction, timeout, asyncFlowOption))
			{
				TResult result = func(tx, context);

				tx.Commit();

				return result;
			}
		}

		public static TResult BeginTransaction<TDataSession, TContext, TResult>(this ApplicationService<TDataSession> applicationService, TransactionScopeOption option, Func<IApplicationTransaction<TDataSession>, TContext, TResult> func, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction(option))
			{
				TResult result = func(tx, context);

				tx.Commit();

				return result;
			}
		}

		public static TResult BeginTransaction<TDataSession, TContext, TResult>(this ApplicationService<TDataSession> applicationService, TransactionScopeOption option, TimeSpan timeout, Func<IApplicationTransaction<TDataSession>, TContext, TResult> func, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction(option, timeout))
			{
				TResult result = func(tx, context);

				tx.Commit();

				return result;
			}
		}

		public static TResult BeginTransaction<TDataSession, TContext, TResult>(this ApplicationService<TDataSession> applicationService, TransactionScopeOption option, TransactionScopeAsyncFlowOption asyncFlowOption, Func<IApplicationTransaction<TDataSession>, TContext, TResult> func, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction(option, asyncFlowOption))
			{
				TResult result = func(tx, context);

				tx.Commit();

				return result;
			}
		}

		public static TResult BeginTransaction<TDataSession, TContext, TResult>(this ApplicationService<TDataSession> applicationService, TransactionScopeOption option, TimeSpan timeout, TransactionScopeAsyncFlowOption asyncFlowOption, Func<IApplicationTransaction<TDataSession>, TContext, TResult> func, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction(option, timeout, asyncFlowOption))
			{
				TResult result = func(tx, context);

				tx.Commit();

				return result;
			}
		}

		public static TResult BeginTransaction<TDataSession, TContext, TResult>(this ApplicationService<TDataSession> applicationService, TransactionScopeOption option, TransactionOptions options, TransactionScopeAsyncFlowOption asyncFlowOption, Func<IApplicationTransaction<TDataSession>, TContext, TResult> func, TContext context)
			where TDataSession : class, IApplicationDataSession
		{
			using(IApplicationTransaction<TDataSession> tx = applicationService.BeginTransaction(option, options, asyncFlowOption))
			{
				TResult result = func(tx, context);

				tx.Commit();

				return result;
			}
		}
	}
}