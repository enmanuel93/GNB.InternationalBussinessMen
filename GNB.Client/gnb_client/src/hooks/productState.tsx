import React, { useContext, useReducer, useState } from "react";
import { ProductContext } from "./ProductContext";
import ProductReducer from "./productReducer";

import { CALCULATE_PRODUCTS } from "../types/types";
import { ProductProp, ProductModule } from "../modules/interfaces";
import axios from "axios";
import { sidebarContext } from "./sidebar/sidebarContext";
import { modalMessageContext } from "./usefulContexts/modalMessageContext";

interface props {
  children: JSX.Element | JSX.Element[];
}

const initialState: ProductModule = {
    totalAmount: 0,
    transactions: [
      {
        id: 0,
        sku: "",
        currency: "",
        amount: 0,
      },
    ],
};

function ProductState({ children }: props) {
  const{setModalMsg} = useContext(modalMessageContext);
  const [showfields, setShowFields] = useState<boolean>(false);
  const [productsState, dispatch] = useReducer(ProductReducer, initialState);
  const { setLoading } = useContext(sidebarContext);

  const getAllProducts = async (id: string) => {
    if(id === ''){
      console.log('Modal')
      setModalMsg(true);
      return;
    }      

    setLoading(true);
    const data = await axios.get(`${process.env.REACT_APP_API_CONNECTION}ProductsTransactions/${id}`);
    console.log(data.data);
    try {
      dispatch({
        type: CALCULATE_PRODUCTS,
        payload: data.data,
      });

      setShowFields(false);
      setLoading(false);
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <ProductContext.Provider
      value={{
        productsState,
        getAllProducts,
        showFields: showfields
      }}
    >
      {children}
    </ProductContext.Provider>
  );
}

export default ProductState;
