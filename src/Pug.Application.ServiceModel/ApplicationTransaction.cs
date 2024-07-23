
using System;
using System.Transactions;
using Pug.Application.Data;

namespace Pug.Application.ServiceModel
{
	internal class ApplicationTransaction<TDataSession> : IApplicationTransaction<TDataSession>
		where TDataSession : class, IApplicationDataSession
	{
		private readonly object _sync = new object();

		// ReSharper disable RedundantDefaultMemberInitializer
		private bool _transactionEnded = false;
		// ReSharper restore RedundantDefaultMemberInitializer

		public string Identifier { get; }

		private readonly TransactionScope _transaction;

		private ApplicationTransaction(TransactionScope transactionScope)
		{
			Identifier = Guid.NewGuid().ToString();

			_transaction = transactionScope;
		}

		public ApplicationTransaction()
			: this(new TransactionScope())
		{
		}

		public ApplicationTransaction(TransactionScopeOption transactionScopeOption)
			: this(new TransactionScope(transactionScopeOption))
		{

		}

		public ApplicationTransaction(TransactionScopeAsyncFlowOption asyncFlowOption)
			: this(new TransactionScope(asyncFlowOption))
		{

		}

		public ApplicationTransaction(TransactionScopeOption transactionScopeOption,
									TransactionOptions transactionOptions)
			: this(new TransactionScope(transactionScopeOption, transactionOptions))
		{

		}

		public ApplicationTransaction(TransactionScopeOption transactionScopeOption, TimeSpan timeout)
			: this(new TransactionScope(transactionScopeOption, timeout))
		{

		}

		public ApplicationTransaction(TransactionScopeOption transactionScopeOption,
									TransactionScopeAsyncFlowOption asyncFlowOption)
			: this(new TransactionScope(transactionScopeOption, asyncFlowOption))
		{

		}

		public ApplicationTransaction(TransactionScopeOption transactionScopeOption, TimeSpan timeout,
									TransactionScopeAsyncFlowOption asyncFlowOption)
			: this(new TransactionScope(transactionScopeOption, timeout, asyncFlowOption))
		{

		}

		public ApplicationTransaction(TransactionScopeOption transactionScopeOption,
									TransactionOptions transactionOptions,
									TransactionScopeAsyncFlowOption asyncFlowOption)
			: this(new TransactionScope(transactionScopeOption, transactionOptions, asyncFlowOption))
		{

		}

		public ApplicationTransaction(Transaction transaction)
			: this(new TransactionScope(transaction))
		{

		}

		public ApplicationTransaction(Transaction transaction,
									TransactionScopeAsyncFlowOption asyncFlowOption)
			: this(new TransactionScope(transaction, asyncFlowOption))
		{

		}

		public ApplicationTransaction(Transaction transaction, TimeSpan timeout,
									TransactionScopeAsyncFlowOption asyncFlowOption)
			: this(new TransactionScope(transaction, timeout, asyncFlowOption))
		{

		}

		public void Commit()
		{
			lock(_sync)
			{
				if(_transactionEnded)
					throw new InvalidTransactionState();

				try
				{
					_transaction.Complete();
				}
				finally
				{
					_transactionEnded = true;
				}

			}
		}

		public void Rollback()
		{
			lock(_sync)
			{
				if(_transactionEnded)
					throw new InvalidTransactionState();

				try
				{
					_transaction.Dispose();
				}
				finally
				{
					_transactionEnded = true;
				}
			}
		}

		public void Dispose()
		{
			lock(_sync)
			{
				if(!_transactionEnded)
				{
					_transaction.Dispose();
				}
			}
		}
	}
}