import React, { useContext, useReducer, useState } from "react";
import { transactionContext } from "./transactionContext";
import TransactionReducer from "./transactionReducer";

import { GET_TRANSACTIONS } from "../../types/types";
import axiosConnection from "../../config/axiosConnection";
import { TransactionProp } from "../../modules/interfaces";
import axios from "axios";
import { sidebarContext } from "../sidebar/sidebarContext";

interface props {
  children: JSX.Element | JSX.Element[];
}

const initialState: TransactionProp = {
  transactions: [
    {
      id: 0,
      sku: "",
      currency: "",
      amount: 0,
    },
  ],
};

function TransactionState({ children }: props) {
  const [showfields, setShowFields] = useState<boolean>(false);
  const [transactionsState, dispatch] = useReducer(
    TransactionReducer,
    initialState
  );
  const { setLoading } = useContext(sidebarContext);

  const getAllTransactions = async () => {
    setLoading(true);
    const data = await axios.get(
      `${process.env.REACT_APP_API_CONNECTION}Transaction`
    );
    try {
      dispatch({
        type: GET_TRANSACTIONS,
        payload: data.data,
      });
      setShowFields(true);
      setLoading(false);
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <transactionContext.Provider
      value={{
        transactionsState,
        getAllTransactions,
        showFields: showfields,
      }}
    >
      {children}
    </transactionContext.Provider>
  );
}

export default TransactionState;
