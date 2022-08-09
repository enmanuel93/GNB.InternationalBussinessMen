import { useReducer } from "react";
import { CALCULATE_PRODUCTS } from "../types/types";
import { RateModule, ProductProp } from "../modules/interfaces";

type ActionType = {
  type: "CALCULATE_PRODUCTS";
  payload: ProductProp;
};

const ProductReducer = (state: ProductProp, action: ActionType) => {
  switch (action.type) {
    case CALCULATE_PRODUCTS:
      return {
        ...state,
        totalAmount: action.payload.totalAmount,
        products: [...state.products, action.payload]
      };
    default:
      return state;
  }
};

export default ProductReducer;
