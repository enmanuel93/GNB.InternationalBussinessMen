import React, { useReducer, useState } from "react";
import { transactionContext } from "./transactionContext";
import TransactionReducer from "./transactionReducer";

import { GET_TRANSACTIONS } from "../../types/types";
import axiosConnection from "../../config/axiosConnection";

interface props {
  children: JSX.Element | JSX.Element[];
}

function TransactionState({ children }: props) {
  const [state, dispatch] = TransactionReducer();

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

  const getAllTransactions = async () => {
    //const resultado = await axiosConnection.get("/api/proyectos");
    const data = await axiosConnection.get(
      "https://nba-players.herokuapp.com/players-stats"
    );
    setPlayers(data.data);

    console.log(players);

    try {
    //   dispatch({
    //     type: GET_TRANSACTIONS,
    //     payload: resultado.data,
    //   });
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <transactionContext.Provider
      value={{
        transactionSt: state,
        getAllTransactions: getAllTransactions,
      }}
    >
      {children}
    </transactionContext.Provider>
  );
}

export default TransactionState;
