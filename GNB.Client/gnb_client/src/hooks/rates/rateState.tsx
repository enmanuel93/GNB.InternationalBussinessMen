import React, { useEffect, useReducer, useState } from "react";
import { rateContext } from "./rateContext";
import RateReducer from "./rateReducer";

import { GET_RATES } from "../../types/types";
import axiosConnection from "../../config/axiosConnection";
import axios from "axios";
import { RateModule, RateProp } from "../../modules/interfaces";

interface props {
  children: JSX.Element | JSX.Element[];
}

const initialState: RateProp = {
  rates: [
    {
      id: 0,
      from: "",
      to: "",
      rate: 0,
    },
  ],
};

function RateState({ children }: props) {
  const [ratesState, dispatch] = useReducer(RateReducer, initialState);

  const getAllRates = async () => {
    const data = await axios.get(`${process.env.REACT_APP_API_CONNECTION}Rate`);
    try {
        dispatch({
          type: GET_RATES,
          payload: data.data,
        });
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <rateContext.Provider
      value={{
        ratesState,
        getAllRates,
      }}
    >
      {children}
    </rateContext.Provider>
  );
}

export default RateState;
