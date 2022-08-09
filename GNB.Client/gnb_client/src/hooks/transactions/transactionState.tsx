import React, { useReducer, useState } from "react";
import { transactionContext } from "./transactionContext";
import TransactionReducer from "./transactionReducer";

import { GET_TRANSACTIONS } from "../../types/types";
import axiosConnection from "../../config/axiosConnection";
import { TransactionProp } from "../../modules/interfaces";
import axios from "axios";

interface props {
  children: JSX.Element | JSX.Element[];
}

const initialState: TransactionProp = {
  transactions: [
    {
      id: 0,
      sku: '',
      currency: '',
      amount: 0
    }
  ]
};

function TransactionState({ children }: props) {
  const [transactionsState, dispatch] = useReducer(TransactionReducer, initialState);

  const getAllTransactions = async () => {
    const data = await axios.get(`${process.env.REACT_APP_API_CONNECTION}Transaction`);
    try {
        dispatch({
          type: GET_TRANSACTIONS,
          payload: data.data,
        });
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <transactionContext.Provider
      value={{
        transactionsState,
        getAllTransactions,
      }}
    >
      {children}
    </transactionContext.Provider>
  );
}

export default TransactionState;
