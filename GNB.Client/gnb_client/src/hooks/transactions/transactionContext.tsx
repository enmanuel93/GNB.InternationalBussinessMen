import {createContext} from 'react';
import { TransactionProp } from '../../modules/interfaces';

type TransactionContextProp = {
    transactionsState: TransactionProp;
    getAllTransactions: () => void
}

export const transactionContext = createContext({} as TransactionContextProp);