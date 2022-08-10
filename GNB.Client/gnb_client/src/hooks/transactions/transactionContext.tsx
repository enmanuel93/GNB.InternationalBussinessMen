import {createContext} from 'react';
import { TransactionProp } from '../../modules/interfaces';

type TransactionContextProp = {
    transactionsState: TransactionProp;
    getAllTransactions: () => void;
    showFields: boolean;
}

export const transactionContext = createContext({} as TransactionContextProp);