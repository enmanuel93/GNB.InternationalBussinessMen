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
    total: number;
}


export interface RateProp {
    rates: RateModule[];
}

export interface TransactionProp {
    transactionP: TransactionModule[];
}

export interface ProductProp {
    productP: TransactionModule[];
}