import { useReducer } from "react";
import { CALCULATE_PRODUCTS } from "../types/types";
import { RateModule, ProductProp, ProductModule } from "../modules/interfaces";

type ActionType = {
  type: "CALCULATE_PRODUCTS";
  payload: ProductModule;
};

const ProductReducer = (state: ProductModule, action: ActionType): ProductModule => {
  switch (action.type) {
    case CALCULATE_PRODUCTS:
      console.log(action.payload)
      return {   
        ...state,
        totalAmount: action.payload.totalAmount,
        transactions: [...action.payload.transactions]
      };
    default:
      return state;
  }
};

export default ProductReducer;
