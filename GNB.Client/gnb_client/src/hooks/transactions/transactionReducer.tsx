import { useReducer } from 'react';
import { TransactionProp } from '../../modules/interfaces';
import {GET_TRANSACTIONS} from '../../types/types';

const initialState: TransactionProp = {
    transactionP: [{
        id: 0,
        sku: '',
        currency: '',
        amount: 0
    }]
};
  
  type ActionType = {
    type: "GET_TRANSACTIONS";
    payload: TransactionProp;
  };
  
  const trReducer = (state: typeof initialState, action: ActionType) => {
    switch (action.type) {
      case GET_TRANSACTIONS:
        return {
          ...state,
          rates: [...state.transactionP, action.payload]
        };
      default:
        return state;
    }
  };
  
  const TransactionReducer = () => {
    return useReducer(trReducer, initialState);
  };
  
  export default TransactionReducer;