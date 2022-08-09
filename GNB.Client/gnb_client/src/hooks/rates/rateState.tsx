import React, { useReducer, useState } from "react";
import { rateContext } from "./rateContext";
import RateReducer from "./rateReducer";

import { GET_RATES } from "../../types/types";
import { axiosConnection } from "../../config/axiosConnection";

interface props {
  children: JSX.Element | JSX.Element[];
}

function RateState({ children }: props) {
  const [state, dispatch] = RateReducer();

  const [players, setPlayers] = useState([]);
  const [loading, setLoading] = useState(false);

  const getPlayerDate = async () => {
    try {
      const data = await axiosConnection.get(
        "https://nba-players.herokuapp.com/players-stats"
      );
      setPlayers(data.data);
    } catch (error) {
      console.log(error);
    }
  };

  const getAllRates = async () => {
    //const resultado = await axiosConnection.get("/api/proyectos");
    const data = await axiosConnection.get(
      "https://nba-players.herokuapp.com/players-stats"
    );
    setPlayers(data.data);

    console.log(players);

    try {
    //   dispatch({
    //     type: GET_RATES,
    //     payload: resultado.data,
    //   });
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <rateContext.Provider
      value={{
        rateSt: state,
        getAllRates: getAllRates,
      }}
    >
      {children}
    </rateContext.Provider>
  );
}

export default RateState;
