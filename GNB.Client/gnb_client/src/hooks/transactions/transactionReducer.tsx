import { useReducer } from "react";
import { TransactionModule, TransactionProp } from "../../modules/interfaces";
import { GET_TRANSACTIONS } from "../../types/types";

type ActionType = {
  type: "GET_TRANSACTIONS";
  payload: TransactionModule[];
};

const TransactionReducer = (
  state: TransactionProp,
  action: ActionType
): TransactionProp => {
  switch (action.type) {
    case GET_TRANSACTIONS:
      return {
        ...state,
        transactions: [...action.payload],
      };
    default:
      return state;
  }
};

export default TransactionReducer;
