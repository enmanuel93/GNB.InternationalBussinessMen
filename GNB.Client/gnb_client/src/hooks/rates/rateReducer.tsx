import { GET_RATES } from "../../types/types";
import { RateModule, RateProp } from "../../modules/interfaces";

type ActionType = {
  type: "GET_RATES";
  payload: RateModule[];
};

const RateReducer = (state: RateProp, action: ActionType): RateProp => {
  switch (action.type) {
    case GET_RATES:
      return { ...state, rates: [...action.payload] };
    default:
      return state;
  }
};

export default RateReducer;
