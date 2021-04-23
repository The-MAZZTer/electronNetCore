using System.Threading.Tasks;
using System;

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