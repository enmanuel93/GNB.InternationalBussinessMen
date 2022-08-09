import { useReducer } from "react";
import { GET_RATES } from "../../types/types";
import { RateModule, RateProp } from "../../modules/interfaces";

const initialState: RateProp = {
  rateP: [
    {
      from: "",
      to: "",
      rate: 0,
    },
  ],
};

type ActionType = {
  type: "GET_RATES";
  payload: RateProp;
};

const rtReducer = (state: typeof initialState, action: ActionType) => {
  switch (action.type) {
    case GET_RATES:
      return {
        ...state,
        rates: [...state.rateP, action.payload]
      };
    default:
      return state;
  }
};

const RateReducer = () => {
  return useReducer(rtReducer, initialState);
};

export default RateReducer;
