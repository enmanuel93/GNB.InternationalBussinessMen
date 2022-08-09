import React, { useReducer, useState } from "react";
import { ProductContext } from "./ProductContext";
import ProductReducer from "./productReducer";

import { CALCULATE_PRODUCTS } from "../types/types";
import { ProductProp } from "../modules/interfaces";
import axios from "axios";

interface props {
  children: JSX.Element | JSX.Element[];
}

const initialState: ProductProp = {
  totalAmount: 0,
  products: [
      {
        id: 0,
        sku: '',
        currency: '',
        amount: 0
      }
    ] 
};

function ProductState({ children }: props) {
  const [productsState, dispatch] = useReducer(ProductReducer, initialState);

  const getAllProducts = async () => {
    const data = await axios.get(`${process.env.REACT_APP_API_CONNECTION}Rate`);
    try {
        dispatch({
          type: CALCULATE_PRODUCTS,
          payload: data.data,
        });
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <ProductContext.Provider
      value={{
        productsState,
        getAllProducts,
      }}
    >
      {children}
    </ProductContext.Provider>
  );
}

export default ProductState;
