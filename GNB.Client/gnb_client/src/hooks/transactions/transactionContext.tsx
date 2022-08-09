import {createContext} from 'react';
import { TransactionProp } from '../../modules/interfaces';

type TransactionContextProp = {
    transactionSt: TransactionProp;
    getAllTransactions: () => void
}

export const transactionContext = createContext({} as TransactionContextProp);