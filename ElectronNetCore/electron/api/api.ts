export type SignalRApi = {
	send(method: string, ...args: any[]): Promise<void>,
	invoke<T>(method: string, ...args: any[]): Promise<T>,

	store(obj: any): number,
	get<T>(id: number): T,
	delete(id: number): void 
};

export type ElectronApi = {
	init(api: SignalRApi): void,
	type: string,
	fromId?(id: any): any,
	toId?(x: any): any,
	instanceOf?(x: any): boolean,
	onStore?(x: any, id: number): void,
	handlers: Record<string, (...args: any[]) => any>
};
