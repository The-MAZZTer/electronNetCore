using MZZT.ElectronNetCore.Api;
using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task InAppPurchase_PurchaseProduct(int requestId, string productId, int quantity);
		Task InAppPurchase_GetProducts(int requestId, string[] productIds);
		Task InAppPurchase_CanMakePayments(int requestId);
		Task InAppPurchase_RestoreCompletedTransactions(int requestId);
		Task InAppPurchase_GetReceiptUrl(int requestId);
		Task InAppPurchase_FinishAllTransactions(int requestId);
		Task InAppPurchase_FinishTransactionByDate(int requestId, string date);
	}

	internal partial class ElectronHub {
		public Task InAppPurchase_TransactionsUpdated_Event(Transaction[] transactions) =>
			Api.Electron.InAppPurchase.OnTransactionsUpdated(transactions);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronInAppPurchase {
		internal ElectronInAppPurchase() { }

		public event EventHandler<TransactionsEventArgs> TransactionsUpdated;
		internal Task OnTransactionsUpdated(Transaction[] transactions) {
			this.TransactionsUpdated?.Invoke(this, new(transactions));
			return Task.CompletedTask;
		}

		public Task<bool> PurchaseProduct(string productId, int quantity = 1) =>
			Electron.FuncAsync<bool, string, int>(x => x.InAppPurchase_PurchaseProduct, productId, quantity);
		public Task<Product[]> GetProducts(string[] productIds) =>
			Electron.FuncAsync<Product[], string[]>(x => x.InAppPurchase_GetProducts, productIds);
		public Task<bool> CanMakePayments() =>
			Electron.FuncAsync<bool>(x => x.InAppPurchase_CanMakePayments);
		public Task RestoreCompletedTransactions() =>
			Electron.ActionAsync(x => x.InAppPurchase_RestoreCompletedTransactions);
		public Task<string> GetReceiptUrl() =>
			Electron.FuncAsync<string>(x => x.InAppPurchase_GetReceiptUrl);
		public Task FinishAllTransactions() =>
			Electron.ActionAsync(x => x.InAppPurchase_FinishAllTransactions);
		public Task FinishTransactionByDate(string date) =>
			Electron.ActionAsync(x => x.InAppPurchase_FinishTransactionByDate, date);
		public Task FinishTransactionByDate(DateTime date) =>
			this.FinishTransactionByDate(date.ToString("o"));
	}
}