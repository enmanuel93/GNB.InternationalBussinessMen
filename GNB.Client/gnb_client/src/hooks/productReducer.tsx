import { useReducer } from "react";
import { CALCULATE_PRODUCTS } from "../types/types";
import { RateModule, ProductProp, ProductModule } from "../modules/interfaces";

type ActionType = {
  type: "CALCULATE_PRODUCTS";
  payload: ProductProp;
};

const ProductReducer = (state: ProductProp, action: ActionType): ProductProp => {
  switch (action.type) {
    case CALCULATE_PRODUCTS:
      return {        
        products: {    
          ...state,      
          totalAmount: action.payload.products.totalAmount,
          transactions: [...action.payload.products.transactions]
        }
      };
    default:
      return state;
  }
};

export default ProductReducer;
