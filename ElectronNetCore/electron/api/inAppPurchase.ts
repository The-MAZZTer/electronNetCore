import { inAppPurchase, Transaction } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronInAppPurchase: ElectronApi = {
	type: "InAppPurchase",
	init: x => {
		api = x;

		inAppPurchase.on("transactions-updated", (_: Event, transactions: Transaction[]) =>
			api.send("TransactionsUpdated_Event", transactions));
	},
	handlers: {
		"PurchaseProduct": (productId, quantity) => inAppPurchase.purchaseProduct(productId, quantity),
		"GetProducts": productIds => inAppPurchase.getProducts(productIds),
		"CanMakePayments": () => inAppPurchase.canMakePayments(),
		"RestoreCompletedTransactions": () => inAppPurchase.restoreCompletedTransactions(),
		"GetReceiptUrl": () => inAppPurchase.getReceiptURL(),
		"FinishAllTransactions": () => inAppPurchase.finishAllTransactions(),
		"FinishTransactionByDate": date => inAppPurchase.finishTransactionByDate(date)
	}
};
