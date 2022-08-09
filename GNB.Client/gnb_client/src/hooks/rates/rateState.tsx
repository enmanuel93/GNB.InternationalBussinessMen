import React, { useReducer, useState } from "react";
import { rateContext } from "./rateContext";
import RateReducer from "./rateReducer";

import { GET_RATES } from "../../types/types";
import axiosConnection from "../../config/axiosConnection";
import axios from "axios";

interface props {
  children: JSX.Element | JSX.Element[];
}

function RateState({ children }: props) {
  const [state, dispatch] = RateReducer();

  const [players, setPlayers] = useState([]);
  const [loading, setLoading] = useState(false);

  const getAllRates = async () => {
    console.log(`${process.env.REACT_APP_API_CONNECTION}Rate`);
    const data = await axios.get(`${process.env.REACT_APP_API_CONNECTION}Rate`);
    
    //console.log(data.data);
    try {
        dispatch({
          type: GET_RATES,
          payload: data.data,
        });

        console.log(state);
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <rateContext.Provider
      value={{
        rates: state,
        getAllRates: getAllRates,
      }}
    >
      {children}
    </rateContext.Provider>
  );
}

export default RateState;
