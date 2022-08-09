import React, { useReducer, useState } from "react";
import { ProductContext } from "./ProductContext";
import ProductReducer from "./productReducer";

import { GET_TRANSACTIONS } from "../types/types";
import axiosConnection from "../config/axiosConnection";

interface props {
  children: JSX.Element | JSX.Element[];
}

function ProductState({ children }: props) {
  const [state, dispatch] = ProductReducer();

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

  const getAllProducts = async () => {
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
    <ProductContext.Provider
      value={{
        productSt: state,
        getAllProducts: getAllProducts,
      }}
    >
      {children}
    </ProductContext.Provider>
  );
}

export default ProductState;
