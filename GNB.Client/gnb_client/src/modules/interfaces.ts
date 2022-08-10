export interface RateModule {
    id: number;
    from: string;
    to: string;
    rate: number
}

export interface TransactionModule {
    id: number;
    sku: string;
    currency: string;
    amount: number
}

export interface ProductModule {
    totalAmount: number;
    transactions: TransactionModule[];
}


export interface RateProp {
    rates: RateModule[];
}

export interface TransactionProp {
    transactions: TransactionModule[];
}

export interface ProductProp {
    products: ProductModule
}