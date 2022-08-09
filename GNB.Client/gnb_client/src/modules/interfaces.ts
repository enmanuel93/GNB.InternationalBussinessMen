export interface RateModule {
    from: string;
    to: string;
    rate: number
}

export interface TransactionModule {
    sku: string;
    currency: string;
    amount: number
}

export interface ProductModule {
    total: number;
}


export interface RateProp {
    rateP: RateModule[];
}

export interface TransactionProp {
    transactionP: TransactionModule[];
}

export interface ProductProp {
    productP: TransactionModule[];
}