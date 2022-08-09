import { useReducer } from "react";
import { CALCULATE_PRODUCTS } from "../types/types";
import { RateModule, ProductProp } from "../modules/interfaces";

const initialState: ProductProp = {
    productP: [{
        id: 0,
        sku: '',
        currency: '',
        amount: 0
    }]
};

type ActionType = {
  type: "CALCULATE_PRODUCTS";
  payload: ProductProp;
};

const prodReducer = (state: typeof initialState, action: ActionType) => {
  switch (action.type) {
    case CALCULATE_PRODUCTS:
      return {
        ...state,
        rates: [...state.productP, action.payload]
      };
    default:
      return state;
  }
};

const ProductReducer = () => {
  return useReducer(prodReducer, initialState);
};

export default ProductReducer;
