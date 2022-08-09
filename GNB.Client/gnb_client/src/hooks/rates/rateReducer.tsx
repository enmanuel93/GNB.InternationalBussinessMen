import { useReducer } from "react";
import { GET_RATES } from "../../types/types";
import { RateModule, RateProp } from "../../modules/interfaces";

const initialState: RateModule[] = [
  {
    id: 0,
    from: "",
    to: "",
    rate: 0,
  },
];

type ActionType = {
  type: "GET_RATES";
  payload: RateModule[];
};

const rtReducer = (state: typeof initialState, action: ActionType) => {
  switch (action.type) {
    case GET_RATES:
      // console.log('example')
      // console.log(action.payload)
      return {
        ...state,
        rate: action.payload
      };
    default:
      return state;
  }
};

const RateReducer = () => {
  return useReducer(rtReducer, initialState);
};

export default RateReducer;
